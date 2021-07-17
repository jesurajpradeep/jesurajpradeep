using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Events;
using HelloWorld.Infrastructure;
namespace ModuleB.ViewModels
{
    public class ViewBViewModel : BindableBase
    {
        IEventAggregator eventAggregator;

        private SubscriptionToken subscriptionToken;

        private string _ModuleBContent;

        public string ModuleBContent
        {
            get
            {
                return _ModuleBContent;
            }

            set
            {
                _ModuleBContent = value;
                OnPropertyChanged("ModuleBContent");
            }
        }


        public ViewBViewModel(IEventAggregator aggr)
        {
            eventAggregator = aggr;

            MsgAddedEvent msgEvent = eventAggregator.GetEvent<MsgAddedEvent>();
            if (subscriptionToken != null)
            {
                msgEvent.Unsubscribe(subscriptionToken);
            }

            //Subscriber
            subscriptionToken = msgEvent.Subscribe(ReceiveMessage, ThreadOption.UIThread, false, CanExecuteEvent);
            // ReceiveMessage -- Action delegate
        }

        //Validation
        public bool CanExecuteEvent(MessageStructure receivedMsg)
        {
            // Validation on the received event can be done here. 
            return true;
        }

        //Receiver
        public void ReceiveMessage(MessageStructure receivedMsg)
        {
            ModuleBContent = receivedMsg.MessageData;
        }

       
    }
}
