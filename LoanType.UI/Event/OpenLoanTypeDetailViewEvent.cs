using LoanType.UI.ViewModel;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanType.UI.Event
{
    public class OpenLoanTypeDetailViewEvent : PubSubEvent<OpenLoanTypeDetailViewEventArgs>
    {
    }
    public class OpenLoanTypeDetailViewEventArgs
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
    }
}
