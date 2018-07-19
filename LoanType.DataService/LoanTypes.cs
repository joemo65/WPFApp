using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanType.DataService
{
    public class LoanTypes
    {
        public LoanTypes()
        {
            Types = new List<LoanType>();
        }

        public List<LoanType> Types { get; set; }
    }
}
