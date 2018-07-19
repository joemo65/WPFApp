using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanType.UI.Event
{
    public class AfterCreateLoanTypeEvent : PubSubEvent<AfterCreateLoanTypeEventArgs>
    {
    }

    public class AfterCreateLoanTypeEventArgs
    {
    }
}
