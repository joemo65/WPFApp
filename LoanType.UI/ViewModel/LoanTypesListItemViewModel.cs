using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LoanType.UI.Event;
using Prism.Commands;

namespace LoanType.UI.ViewModel
{
    public class LoanTypesListItemViewModel : ViewModelBase
    {
        private string _typeName;
        private IEventAggregator _eventAggregator;

        public LoanTypesListItemViewModel(int id, string typeName,
          IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Id = id;
            TypeName = typeName;
            OpenDetailViewCommand = new DelegateCommand(OnOpenDetailViewExecute);
        }

        public int Id { get; }

        public string TypeName
        {
            get { return _typeName; }
            set
            {
                _typeName = value;
                OnPropertyChanged();
            }
        }

        public ICommand OpenDetailViewCommand { get; }

        private void OnOpenDetailViewExecute()
        {
            _eventAggregator.GetEvent<OpenLoanTypeDetailViewEvent>()
                  .Publish(
              new OpenLoanTypeDetailViewEventArgs()
              {
                  Id = Id,
                  TypeName = TypeName
              });
        }
    }
}
