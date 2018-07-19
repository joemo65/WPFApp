using LoanType.DataService;
using LoanType.UI.Event;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LoanType.UI
{
    public class FileControlViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;
        private ILoanTypeService _service;

        public FileControlViewModel(ILoanTypeService loanTypeService, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _service = loanTypeService;
            BrowseCommand = new DelegateCommand(BrowseForFile);
            ImportCommand = new DelegateCommand(ImportFromFile);
            ExportCommand = new DelegateCommand(ExportToFile);
        }

        private void BrowseForFile()
        {
            var dialog = new OpenFileDialog();

            // Set filter for file extension and default file extension 
            dialog.DefaultExt = ".xml";
            dialog.Filter = "XML Files (*.xml)|*.xml";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dialog.ShowDialog();

            if (result == true)
            {
                FileName = dialog.FileName;
            }
        }

        private void ImportFromFile()
        {
            if (string.IsNullOrWhiteSpace(FileName))
                return;

            var loanTypes = _service.ImportLoanTypes(FileName);

            var eventArgs = new AfterImportFileEventArgs();
            foreach (var loanType in loanTypes.Types)
            {
                eventArgs.LoanTypeItems.Add(new LoanTypeItem(loanType.Id, loanType.TypeName));
            }
            _eventAggregator.GetEvent<AfterImportFileEvent>().Publish(eventArgs);
        }

        private void ExportToFile()
        {
            _service.ExportToFile(FileName);
        }

        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                OnPropertyChanged(nameof(FileName));
            }
        }

        public ICommand BrowseCommand { get; set; }

        public ICommand ImportCommand { get; set; }

        public ICommand ExportCommand { get; set; }
    }
}
