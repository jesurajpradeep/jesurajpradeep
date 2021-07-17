using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMExample
{
    /// <summary>
    /// Interaction logic for PopUpUserControl.xaml
    /// </summary>
    public partial class PopUpUserControl : UserControl
    {
        public PopUpUserControl()
        {
            InitializeComponent();
        }

        #region  Name Update to POP UP window

        public static readonly DependencyProperty SetNameProperty =
       DependencyProperty.Register("SetNameText", typeof(string), typeof(PopUpUserControl), new
        PropertyMetadata("", new PropertyChangedCallback(OnSetTextChanged)));

        public string SetNameText
        {
            get { return (string)GetValue(SetNameProperty); }
            set { SetValue(SetNameProperty, value); }
        }

        private static void OnSetTextChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            PopUpUserControl UserControl1Control = d as PopUpUserControl;
            UserControl1Control.OnSetTextChanged(e);
        }

        private void OnSetTextChanged(DependencyPropertyChangedEventArgs e)
        {
            txtname.Text = e.NewValue.ToString();
        }

        #endregion
        



        public static readonly DependencyProperty SetNameIDProperty =
      DependencyProperty.Register("SetNameID", typeof(string), typeof(PopUpUserControl), new
       PropertyMetadata("", new PropertyChangedCallback(OnSetTextIDChanged)));

        public string SetNameID
        {
            get { return (string)GetValue(SetNameIDProperty); }
            set { SetValue(SetNameIDProperty, value); }
        }

        private static void OnSetTextIDChanged(DependencyObject d,
          DependencyPropertyChangedEventArgs e)
        {
            PopUpUserControl UserControl1Control = d as PopUpUserControl;
            UserControl1Control.OnSetTextIDChanged(e);
        }

        private void OnSetTextIDChanged(DependencyPropertyChangedEventArgs e)
        {
            txtID.Text = e.NewValue.ToString();
        }

    }
}
