using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CS7Starter
{
    /// <summary>
    /// Interaction logic for NewBinarySetupUI.xaml
    /// </summary>
    public partial class NewBinarySetupUI : Window
    {
        public NewBinarySetupUI(CS7ViewModel viewModelObj)
        {
            InitializeComponent();
            DataContext = viewModelObj;
            viewModelObj.CloseEventNewBinaryUI += () =>
            {
                Close();
            };
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
            this.Left = desktopWorkingArea.Right - this.Width - 200;
            this.Top = desktopWorkingArea.Bottom - this.Height - 200;
        }
    }
}
