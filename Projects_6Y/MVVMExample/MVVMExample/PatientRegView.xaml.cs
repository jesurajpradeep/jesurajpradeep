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
using System.Windows.Shapes;
using PressHoldButton.Model;

namespace MVVMExample
{
    /// <summary>
    /// Interaction logic for PatientRegView.xaml
    /// </summary>
    public partial class PatientRegView : Window
    {
        PatientRegistrationViewModel viewModelObj = null;
        public PatientRegView()
        {
            InitializeComponent();
            viewModelObj = new PatientRegistrationViewModel();
            this.DataContext = viewModelObj; // Binding view and View Model


            this.viewModelObj.PressCommand = new MVVMExample.PatientRegistrationViewModel.PressHoldCommand((param) => viewModelObj.OnBtnBodyPart(param));

        }

        

        
    }
}
