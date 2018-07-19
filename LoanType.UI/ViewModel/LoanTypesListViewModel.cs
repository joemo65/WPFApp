using LoanType.DataService;
using LoanType.UI.Event;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanType.UI.ViewModel
{
    public class LoanTypesListViewModel : ViewModelBase
    {
        public LoanTypesListViewModel(ILoanTypeService service, IEventAggregator eventAggregator)
        {
            _service = service;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<AfterImportFileEvent>().Subscribe(AfterImportFile);
            _eventAggregator.GetEvent<AfterUpdateLoanTypeDetailViewEvent>().Subscribe(AfterUpdateLoanType);
            _eventAggregator.GetEvent<AfterDeleteLoanTypeDetailViewEvent>().Subscribe(AfterDeleteLoanType);
            _eventAggregator.GetEvent<AfterCreateLoanTypeEvent>().Subscribe(AfterCreateLoanType);
            LoanTypes = new ObservableCollection<LoanTypesListItemViewModel>();

            //only here for now for testing purposes
            LoadList();
        }

        private void AfterCreateLoanType(AfterCreateLoanTypeEventArgs obj)
        {
            LoadList();
        }

        private void LoadList()
        {
            var loanTypes = _service.GetLoanTypes();

            LoanTypes.Clear();

            if(loanTypes != null)
            {
                foreach (var loanTypeItem in loanTypes.Types)
                {
                    LoanTypes.Add(new LoanTypesListItemViewModel(loanTypeItem.Id, loanTypeItem.TypeName, _eventAggregator));
                }
            }
        }

        private void AfterImportFile(AfterImportFileEventArgs obj)
        {
            LoadList();
        }

        private void AfterUpdateLoanType(AfterUpdateLoanTypeDetailViewEventArgs obj)
        {
            LoadList();
        }

        private void AfterDeleteLoanType(AfterDeleteLoanTypeDetailViewEventArgs obj)
        {
            LoadList();
        }

        public ObservableCollection<LoanTypesListItemViewModel> LoanTypes { get; }

        private LoanTypesListItemViewModel _selectedLoanType;
        public LoanTypesListItemViewModel SelectedLoanType
        {
            get { return _selectedLoanType; }
            set
            {
                _selectedLoanType = value;
                OnPropertyChanged();
                if (_selectedLoanType != null)
                {
                    _eventAggregator.GetEvent<OpenLoanTypeDetailViewEvent>()
                      .Publish(
                        new OpenLoanTypeDetailViewEventArgs()
                        {
                            Id = _selectedLoanType.Id,
                            TypeName = _selectedLoanType.TypeName
                        });
                }
            }
        }

        private ILoanTypeService _service;

        private IEventAggregator _eventAggregator;
    }
}
