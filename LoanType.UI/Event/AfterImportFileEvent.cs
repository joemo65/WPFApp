using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanType.UI.Event
{
    public class AfterImportFileEvent : PubSubEvent<AfterImportFileEventArgs>
    {
    }

    public class AfterImportFileEventArgs
    {
        public AfterImportFileEventArgs()
        {
            LoanTypeItems = new List<LoanTypeItem>();
        }
        public List<LoanTypeItem> LoanTypeItems { get; set; }
    }
}
