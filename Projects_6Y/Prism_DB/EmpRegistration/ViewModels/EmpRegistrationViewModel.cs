using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Employee.Infrastructure;
using Prism.Events;
using InterfaceDAL;

namespace EmpRegistration.ViewModels
{
    public class EmpRegistrationViewModel : BindableBase
    {
        IEventAggregator eventAggregator;

        public string VMEmployeeName // Corresponding View Model Entities
        {
            get
            {
                return _empName;
            }
            set
            {
                _empName = value;
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public string VMEmployeeID // Corresponding View Model Entities
        {
            get
            {
                return _empID;
            }
            set
            {
                _empID = value;
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public string VMEmployeeSex // Corresponding View Model Entities
        {
            get
            {
                return _empSex;
            }
            set
            {
                _empSex = value;
                SaveCommand.RaiseCanExecuteChanged();
            }
        }


        private string _empID;

        private string _empName;

        private string _empSex;

        private DelegateCommand _saveCommand = null;

        public DelegateCommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new DelegateCommand(OnSaveCommand, ValidateSave);
                }
                return _saveCommand;
            }
        }


        private bool ValidateSave() // Canexecute
        {
            bool result = true;

            if (string.IsNullOrEmpty(VMEmployeeID) && string.IsNullOrEmpty(VMEmployeeName) &&
                string.IsNullOrEmpty(VMEmployeeSex))
            {
                result = false;
            }

            if (string.IsNullOrWhiteSpace(VMEmployeeID) &&
                string.IsNullOrWhiteSpace(VMEmployeeName) && string.IsNullOrWhiteSpace(VMEmployeeSex))
            {
                result = false;
            }
            return result;
            //return true;
        }

        private void OnSaveCommand() // Execute
        {
            EmployeeDetails details = new EmployeeDetails();
            details.EmployeeID = VMEmployeeID;
            details.EmployeeName = VMEmployeeName;
            details.Sex = VMEmployeeSex;
            SaveToDB(details);

            eventAggregator.GetEvent<MsgAddedEvent>().Publish(details);  // Event Aggregator - Publisher


        }

        private void SaveToDB(EmployeeDetails details)
        {
            IDal<EmployeeDetails> dal = FactoryDAL.FactoryDalLayer<IDal<EmployeeDetails>>
                                 .Create("ADODal");
            dal.Add(details); // In memory
            dal.Save(); // Physical committ
            //LoadGrid();
            //ClearCustomer();
        }


        public EmpRegistrationViewModel(IEventAggregator agg)
        {
            eventAggregator = agg;
        }

        
    }
}
