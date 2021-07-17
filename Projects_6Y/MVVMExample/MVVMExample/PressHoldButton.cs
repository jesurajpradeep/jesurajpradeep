using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace PressHoldButton.Model
{
    /// <summary>
    /// 長押しボタンクラス
    /// </summary>
    public class PressHoldButton : RepeatButton
    {
        #region 内部フィールド

        /// <summary>
        /// 初期化フラグ
        /// </summary>
        private bool _isInitialized;

        /// <summary>
        /// カウンタ
        /// </summary>
        private int _commandCount = 0;

        #endregion

        /// <summary>
        /// Dependency property: long press time
        /// </summary>
        public static readonly DependencyProperty PressHoldTimeProperty =
            DependencyProperty.Register("PressHoldTime", typeof(int), typeof(PressHoldButton),
            new FrameworkPropertyMetadata(   // Metadata                   
                4000,
                new PropertyChangedCallback(OnPressHoldTimeChanged)));

        /// <summary>
        /// Dependency property: command
        /// </summary>
        public static readonly DependencyProperty PressHoldCommandProperty =
            DependencyProperty.Register("PressHoldCommand", typeof(ICommand), typeof(PressHoldButton),
                new FrameworkPropertyMetadata(   // Metadata                   
                null,
                new PropertyChangedCallback(OnPressHoldTimeChanged)));
        /*
        WITHOUT DP, HOW TO DO THIS?
        */

        /// <summary>
        /// Dependent property change event
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnPressHoldTimeChanged(
        DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var control = obj as PressHoldButton;
            if (control != null)
            {
                control.InitializeControlForce();
            }
        }

        /// <summary>
        /// Initializing process
        /// </summary>
        internal void InitializeControlForce()
        {
            DebugTrace("InitializeControlForce");

            _isInitialized = false;
            InitializeControl();
        }

        /// <summary>
        /// Initializing process
        /// </summary>
        private void InitializeControl()
        {
            DebugTrace("InitializeControl");

            if (_isInitialized == false)
            {
                if (this.PressHoldCommand != null)
                {
                    if (this.PressHoldTime > 0)
                    {
                        this.Command = new InternalCommand(
                            param => ExecuteCommand(),
                            param => this.PressHoldCommand.CanExecute(param));


                        this.Delay = this.PressHoldTime; // Repeat Button property
                        this.Interval = this.PressHoldTime; // Repeat Button property

                        _isInitialized = true;
                        DebugTrace("initialized.({0})", this.PressHoldTime);
                    }
                }
            }
        }


        private void InitializeControl2()
        {
            DebugTrace("InitializeControl");

            if (_isInitialized == false)
            {
                if (this.PressHoldCommand != null)
                {
                    if (this.PressHoldTime > 0)
                    {
                        this.Command = new InternalCommand(
                            param => ExecuteCommand(),
                            param => this.PressHoldCommand.CanExecute(param));

                        this.Delay = 3000; // Repeat Button property
                        this.Interval = 3000; // Repeat Button property
                        _isInitialized = true;
                        DebugTrace("initialized.({0})", this.PressHoldTime);
                    }
                }
            }
        }

        /// <summary>
        /// Internal class: command delegate
        /// </summary>
        private class InternalCommand : ICommand
        {
            #region 内部フィールド

            /// <summary>
            /// 実行デリゲート
            /// </summary>
            private Action<object> _action;

            /// <summary>
            /// 実行可否
            /// </summary>
            private Predicate<object> _canAction;

            #endregion

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="action"></param>
            /// <param name="canAction"></param>
            public InternalCommand(Action<object> action, Predicate<object> canAction)
            {
                _action = action;
                _canAction = canAction;
            }

            /// <summary>
            /// 実行可否
            /// </summary>
            /// <param name="parameter"></param>
            /// <returns></returns>
            public bool CanExecute(object parameter)
            {
                if (_canAction != null)
                {
                    return _canAction(parameter);
                }

                return true;
            }

            /// <summary>
            /// 実行可否変化イベント
            /// </summary>
            public event EventHandler CanExecuteChanged;

            /// <summary>
            /// 実行
            /// </summary>
            /// <param name="parameter"></param>
            public void Execute(object parameter)
            {
                _action(parameter);
            }
        }

        /// <summary>
        /// 長押し時間プロパティ
        /// </summary>
        public int PressHoldTime
        {
            get { return (int)base.GetValue(PressHoldTimeProperty); }
            set { base.SetValue(PressHoldTimeProperty, value); }
        }

        /// <summary>
        /// 長押しコマンドプロパティ
        /// </summary>
        /// <remarks>
        /// 短押しは"short"、長押しは"long"のパラメータが付与される。
        /// </remarks>
        public ICommand PressHoldCommand
        {
            get { return base.GetValue(PressHoldCommandProperty) as ICommand; }
            set { base.SetValue(PressHoldCommandProperty, value); }
        }

        /// <summary>
        /// フォーカスが失われた（Prismy V1.07-520 マウスアップ・長押しコマンド終了時での状態クリアを止め、このイベントで状態クリアを行う）
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLostMouseCapture(MouseEventArgs e)
        {
            base.OnLostMouseCapture(e);

            _commandCount = 0;
        }

        /// <summary>
        /// マウスアップ
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonUp(e);

            EndPress();
        }

        /// <summary>
        /// 押下終了
        /// </summary>
        private void EndPress()
        {
            if (_commandCount > 1)
            {
                return;
            }

            // ボタンがアクティブでなければ実行しない
            if (!this.IsPressed)
            {
                return;
            }

            DebugTrace("EndPress:{0}", _commandCount);

            // execute short command
            ExecuteShortCommand();
        }

        /// <summary>
        /// コマンド実行
        /// </summary>
        private void ExecuteCommand()
        {
            _commandCount++;
            DebugTrace("ExecuteCommand:{0}", _commandCount);

            if (_commandCount > 1)
            {
                ExecuteLongCommand();
            }
        }

        /// <summary>
        /// 短押しコマンド発火
        /// </summary>
        private void ExecuteShortCommand()
        {
            if (this.PressHoldCommand != null)
            {
                if (this.PressHoldCommand.CanExecute("short"))
                {
                    DebugTrace("Fire ExecuteShortCommand");
                    this.PressHoldCommand.Execute("short");
                }
            }
        }

        /// <summary>
        /// 長押しコマンド発火
        /// </summary>
        private void ExecuteLongCommand()
        {
            if (this.PressHoldCommand != null)
            {
                if (this.PressHoldCommand.CanExecute("long"))
                {
                    DebugTrace("Fire ExecuteLongCommand");
                    this.PressHoldCommand.Execute("long");
                }
            }
        }

        /// <summary>
        /// 診断
        /// </summary>
        /// <param name="message"></param>
        /// <param name="rep"></param>
        private void DebugTrace(string message, params object[] rep)
        {

            //#if USE_DEBUG
            System.Diagnostics.Trace.WriteLine("PressHoldButton:" + String.Format(message, rep));
            //#endif
        }
    }
}
