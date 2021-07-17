using System.Windows.Controls;
using System.ComponentModel.Composition;

namespace ModuleA.Views
{
    [Export(typeof(ViewA))]
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class ViewA : UserControl
    {
        
        public ViewA()
        {
            InitializeComponent();
        }
    }
}
