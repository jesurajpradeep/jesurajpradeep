using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel; //INotifyPropertyChanged
using System.Windows.Input; // ICommand
using MVVMExample.Commands;
using System.Collections.ObjectModel;
using System.Windows.Data; // IValueConverter
using System.Globalization; //  CultureInfo
using PressHoldButton.Model;
using System.Windows.Forms;
namespace MVVMExample
{
    /// <summary>
    /// ViewModelBase
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        public void RefreshUI(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));  // from UI to ViewModel
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    /// <summary>
    /// PatientRegistrationViewModel
    /// </summary>
    class PatientRegistrationViewModel : ViewModelBase, IDataErrorInfo
    {
        PatientRegistrationModel _model = null;

        public PatientRegistrationViewModel()
        {
            _model = new PatientRegistrationModel();
        }

        public string VMPatientID // Corresponding View Model Entities
        {
            get
            {
                return _patientID;
            }
            set
            {
                _patientID = value;
            }
        }

        public string VMPatientName // Corresponding View Model Entities
        {
            get
            {
                return _patientName;
            }
            set
            {
                _patientName = value;
            }
        }

        public string VMPatientSex // Corresponding View Model Entities
        {
            get
            {
                return _patientSex;
            }
            set
            {
                _patientSex = value;
            }
        }


        private string _patientID;

        private string _patientName;

        private string _patientSex;

        // SaveCommand
        private ICommand _SaveCommand = null;

        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new GenericCommand(param => OnSaveCommand(), param => ValidateSave());
                }
                return _SaveCommand;
            }
        }

        public ICommand PressCommand { get; set; }
        
        /// <summary>
        /// PatientDetailsColl
        /// </summary>
        public ObservableCollection<PatientDetails> PatientDetailsColl
        {
            get
            {
                return _patientDetailsColl;
            }

            set
            {
                _patientDetailsColl = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<PatientDetails> _patientDetailsColl = new ObservableCollection<PatientDetails>();

        /// <summary>
        /// LoadPatientDetails
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="sex"></param>
        public void LoadPatientDetails(string id, string name, string sex)
        {
            _patientDetailsColl.Add(new PatientDetails { PatientID = id, PatientName = name, PatientSex = sex });
            PatientDetailsColl = _patientDetailsColl;

        }

        /// <summary>
        /// OnSaveCommand
        /// </summary>
        private void OnSaveCommand() // Execute
        {
            LoadPatientDetails(VMPatientID, VMPatientName, VMPatientSex);

            PatientDetails details = new PatientDetails();
            details.PatientID = VMPatientID;
            details.PatientName = VMPatientName;
            details.PatientSex = VMPatientSex;

            
         //   _model.SaveToTextFile(details); // If required, save it to a DB for better understanding of model
        }

        /// <summary>
        /// ValidateSave
        /// </summary>
        /// <returns></returns>
        private bool ValidateSave() // Canexecute
        {
            bool result = true;

            if (string.IsNullOrEmpty(VMPatientID) && string.IsNullOrEmpty(VMPatientName) &&
                string.IsNullOrEmpty(VMPatientSex))
            {
                result = false;
            }

            if (string.IsNullOrWhiteSpace(VMPatientID) &&
                string.IsNullOrWhiteSpace(VMPatientName) && string.IsNullOrWhiteSpace(VMPatientSex))
            {
                result = false;
            }
            return result;
        }


        #region IDataErrorInfo
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                if ("VMPatientName" == columnName)
                {
                    if (String.IsNullOrEmpty(VMPatientName))
                    {
                        return "Please enter a Name"; // for tooltip
                    }
                }
                else if ("VMPatientSex" == columnName)
                {

                    if (String.IsNullOrEmpty(VMPatientSex))
                    {
                        return "specify an input";
                    }
                }
                else if ("VMPatientID" == columnName)
                {

                    if (String.IsNullOrEmpty(VMPatientID))
                    {
                        return "specify an input";
                    }
                }
                return "";
            }
        }

        #endregion
        public void OnBtnBodyPart(object parameter)
        {
            if (parameter.ToString() == "short")
            {
                MessageBox.Show("short press");
            }
            else if (parameter.ToString() == "long")
            {
                MessageBox.Show("long press");
            }
            else
            {
                MessageBox.Show("error");
            }
        }

        public class PressHoldCommand : ICommand
        {
            private Action<object> _handler;

            public PressHoldCommand(Action<object> handler)
            {
                _handler = handler;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                _handler(parameter);
            }
        }
    }

    public class PatientDetails : IValueConverter
    {
        public string PatientID { get; set; }

        public string PatientName { get; set; }

        public string PatientSex { get; set; }


        #region valueconverter
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var staff = (PatientDetails)value;
            if (string.IsNullOrEmpty(staff.PatientName) || string.IsNullOrEmpty(staff.PatientSex))
            {
                return "Red";
            }
            else
            {
                return "Green";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
        #endregion

       
    }
}
