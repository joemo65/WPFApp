using LoanType.DataService;
using LoanType.UI.Event;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LoanType.UI.ViewModel
{
    public class LoanTypesAddViewModel : ViewModelBase 
    {
        private IEventAggregator _eventAggregator;
        private ILoanTypeService _service;

        public LoanTypesAddViewModel(ILoanTypeService service, IEventAggregator eventAggregator)
        {
            _service = service;
            _eventAggregator = eventAggregator;
            LoanTypeItem = new LoanTypeItem();
            CreateCommand = new DelegateCommand(OnCreateExecute);
        }

        private void OnCreateExecute()
        {
            _service.AddLoanType(LoanTypeItem.Id, LoanTypeItem.TypeName);
            _eventAggregator.GetEvent<AfterCreateLoanTypeEvent>().Publish(new AfterCreateLoanTypeEventArgs());
            LoanTypeItem = new LoanTypeItem();
        }

        private LoanTypeItem _loanTypeItem;
        public LoanTypeItem LoanTypeItem
        {
            get { return _loanTypeItem; }
            private set
            {
                _loanTypeItem = value;
                OnPropertyChanged();
            }
        }

        public ICommand CreateCommand { get; }
    }
}
