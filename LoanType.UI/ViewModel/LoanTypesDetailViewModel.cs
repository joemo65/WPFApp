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
    public class LoanTypesDetailViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;
        private ILoanTypeService _service;

        public LoanTypesDetailViewModel(ILoanTypeService service, IEventAggregator eventAggregator)
        {
            _service = service;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenLoanTypeDetailViewEvent>()
                .Subscribe(OnOpenLoanTypeDetailView);

            UpdateCommand = new DelegateCommand(OnUpdateExecute);
            DeleteCommand = new DelegateCommand(OnDeleteExecute);
        }

        private void OnUpdateExecute()
        {
            _service.UpdateLoanType(new DataService.LoanType(LoanTypeItem.Id, LoanTypeItem.TypeName));
            _eventAggregator.GetEvent<AfterUpdateLoanTypeDetailViewEvent>().Publish(
                new AfterUpdateLoanTypeDetailViewEventArgs
                {
                    Id = LoanTypeItem.Id,
                    TypeName = LoanTypeItem.TypeName
                });
        }

        private void OnDeleteExecute()
        {
            _service.RemoveLoanType(new DataService.LoanType(LoanTypeItem.Id, LoanTypeItem.TypeName));
            _eventAggregator.GetEvent<AfterDeleteLoanTypeDetailViewEvent>().Publish(new AfterDeleteLoanTypeDetailViewEventArgs());
            LoanTypeItem = null;
        }

        private void OnOpenLoanTypeDetailView(OpenLoanTypeDetailViewEventArgs obj)
        {
            LoanTypeItem = new LoanTypeItem(obj.Id, obj.TypeName);
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

        public ICommand UpdateCommand { get; set; }

        public ICommand DeleteCommand { get; set; }
    }
}
