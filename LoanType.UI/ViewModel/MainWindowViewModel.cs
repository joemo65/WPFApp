using LoanType.DataService;
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
    public class MainWindowViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;
        private ILoanTypeService _service;
        public MainWindowViewModel(ILoanTypeService service, IEventAggregator eventAggregator)
        {
            _service = service;
            _eventAggregator = eventAggregator;
            FileControlViewModel = new FileControlViewModel(_service, _eventAggregator);
            LoanTypesListViewModel = new LoanTypesListViewModel(_service, _eventAggregator);
            LoanTypesDetailViewModel = new LoanTypesDetailViewModel(_service, _eventAggregator);
            LoanTypesAddViewModel = new LoanTypesAddViewModel(_service, _eventAggregator);
        }

        public FileControlViewModel FileControlViewModel { get; set; }

        public LoanTypesListViewModel LoanTypesListViewModel { get; set; }

        public LoanTypesDetailViewModel LoanTypesDetailViewModel { get; set; }

        public LoanTypesAddViewModel LoanTypesAddViewModel { get; set; }
    }
}
