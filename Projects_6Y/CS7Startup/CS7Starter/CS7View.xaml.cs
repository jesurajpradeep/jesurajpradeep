using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace CS7Starter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CS7ViewModel viewModel = new CS7ViewModel();
            this.DataContext = viewModel;

            viewModel.CloseEvent += () =>
                {
                    Close();
                };

            viewModel.MinimizeEvent += () =>
            {
                this.WindowState = WindowState.Minimized;
                TrayMinimizerForm_Resize();
            };
            this.ShowInTaskbar = false;
        }

        
        NotifyIcon nIcon = new NotifyIcon();


        private void TrayMinimizerForm_Resize()
        {

            nIcon.DoubleClick -= NIcon_DoubleClick;
            nIcon.DoubleClick += NIcon_DoubleClick;
            nIcon.Click -= NIcon_Click;
            nIcon.Click += NIcon_Click;

            if (WindowState.Minimized == this.WindowState)
            {
                this.nIcon.Visible = true;
                this.nIcon.Icon = new Icon(@"PerfCenterCpl.ico");
                this.nIcon.ShowBalloonTip(5, "CS7 ConfigurationTool", "CS7 Configuration Tool is minimized to Tray", ToolTipIcon.Info);
                this.Hide();
            }
            else if (WindowState.Normal == this.WindowState)
            {
                this.nIcon.Visible = false;
            }
        }


        private void NIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            Topmost = true;
            this.WindowState = WindowState.Normal;
            this.nIcon.Visible = false;
        }

        private void NIcon_Click(object sender, EventArgs e)
        {
            Show();
            Topmost = true;
            this.WindowState = WindowState.Normal;
            this.nIcon.Visible = false;
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            // Begin dragging the window 
            this.DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;
        }
    }
}
