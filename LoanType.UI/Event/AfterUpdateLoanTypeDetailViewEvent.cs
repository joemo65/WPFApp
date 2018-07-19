using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanType.UI.Event
{
    public class AfterUpdateLoanTypeDetailViewEvent: PubSubEvent<AfterUpdateLoanTypeDetailViewEventArgs>
    {
    }

    public class AfterUpdateLoanTypeDetailViewEventArgs
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
    }
}
