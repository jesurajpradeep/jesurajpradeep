using System.Windows;
using System.ComponentModel.Composition;

namespace HelloWorld.Views
{
    [Export(typeof(MainWindow))]
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
