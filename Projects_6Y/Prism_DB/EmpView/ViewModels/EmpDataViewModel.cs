using Employee.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FactoryDAL;
using InterfaceDAL;

namespace EmpView.ViewModels
{
    public class EmpDataViewModel : BindableBase
    {
        IEventAggregator eventAggregator;
        private SubscriptionToken subscriptionToken;

        public ObservableCollection<EmployeeDetails> EmployeeDetailsColl
        {
            get
            {
                return _empDetailsColl;
            }

            set
            {
                _empDetailsColl = value;
            }
        }

        private ObservableCollection<EmployeeDetails> _empDetailsColl = new ObservableCollection<EmployeeDetails>();

        private DelegateCommand _refreshCommand = null;

        public DelegateCommand RefreshCommand
        {
            get
            {
                if (_refreshCommand == null)
                {
                    _refreshCommand = new DelegateCommand(OnRefreshGridCommand, ValidateRefresh);
                }
                return _refreshCommand;
            }
        }

        public EmpDataViewModel(IEventAggregator aggr)
        {
            eventAggregator = aggr;

            MsgAddedEvent msgEvent = eventAggregator.GetEvent<MsgAddedEvent>();
            if (subscriptionToken != null)
            {
                msgEvent.Unsubscribe(subscriptionToken);
            }

            //Subscriber
            subscriptionToken = msgEvent.Subscribe(ReceivedEmployeeDetails, ThreadOption.UIThread, false, CanExecuteEvent);
            // ReceiveMessage -- Action delegate
        }

        //Validation
        public bool CanExecuteEvent(EmployeeDetails receivedMsg)
        {
            // Validation on the received event can be done here. 
            return true;
        }

        private void ReceivedEmployeeDetails(EmployeeDetails details)
        {
            EmployeeDetailsColl.Add(details);
        }

        private bool ValidateRefresh()
        {
            return true;
        }


        private void OnRefreshGridCommand()
        {
            EmployeeDetailsColl.Clear();
            LoadGrid();

        }

        private void LoadGrid()
        {
            IDal<EmployeeDetails> dal = FactoryDAL.FactoryDalLayer<IDal<EmployeeDetails>>
                  .Create("ADODal");
            List<EmployeeDetails> custList = dal.Search();
            foreach(EmployeeDetails details in custList)
            {
                EmployeeDetailsColl.Add(details);
            }
        }

    }
}
