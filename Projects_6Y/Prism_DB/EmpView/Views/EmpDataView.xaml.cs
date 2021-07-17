using Employee.Infrastructure;
using System.Collections.Generic;
using System.Windows.Controls;

namespace EmpView.Views
{
    /// <summary>
    /// Interaction logic for EmpDataView
    /// </summary>
    public partial class EmpDataView : UserControl
    {
        public EmpDataView()
        {
            InitializeComponent();
            //EmployeeDataGrid.ItemsSource = LoadCollectionData();
        }
    }
}
