using Prism.Commands;
using Prism.Mvvm;
using HelloWorld.Infrastructure;
using Prism.Events;
using System.ComponentModel.Composition;
namespace ModuleA.ViewModels
{
    [Export(typeof(ViewAViewModel))]
    public class ViewAViewModel : BindableBase
    {
        IEventAggregator eventAggregator;

        [ImportingConstructor]
        public ViewAViewModel(IEventAggregator agg)
        {
            eventAggregator = agg;
            _CommunicateCommand = new DelegateCommand(CommunicateToModuleB, CanCommunicate);
        } 
        private string _title = "ModuleAView";
        public string Title
        {
            get { return _title; }
            set
            {
                SetProperty(ref _title, value);
            }
        }

        private string _enteredText;
        public string EnteredText
        {
            get { return _enteredText; }
            set
            {
                SetProperty(ref _enteredText, value);
                if(CommunicateCommand != null)
                {
                    CommunicateCommand.RaiseCanExecuteChanged();
                }
                
            }
        }

        public DelegateCommand CommunicateCommand
        {
            get
            {
                return _CommunicateCommand;
            }
            

        }

        private DelegateCommand _CommunicateCommand;

        

        private void CommunicateToModuleB()
        {
            MessageStructure msg = new MessageStructure();
            msg.MessageData = EnteredText;
            // Event Aggregator - Publisher
            eventAggregator.GetEvent<MsgAddedEvent>().Publish(msg);
        }

        private bool CanCommunicate()
        {
            if(string.IsNullOrEmpty(EnteredText))
            {
                return false;
            }
            return true;
        }


    }
}
