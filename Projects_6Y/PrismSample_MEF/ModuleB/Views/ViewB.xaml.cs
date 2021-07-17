using System.Windows.Controls;
using System.ComponentModel.Composition;

namespace ModuleB.Views
{
    [Export(typeof(ViewB))]
    /// <summary>
    /// Interaction logic for ViewB.xaml
    /// </summary>
    public partial class ViewB : UserControl
    {
        public ViewB()
        {
            InitializeComponent();
        }
    }
}
