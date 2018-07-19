using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanType.UI
{
    public class LoanTypeItem
    {
        public LoanTypeItem()
        {

        }

        public LoanTypeItem(int id, string typeName)
        {
            Id = id;
            TypeName = typeName;
        }

        public int Id { get; set; }
        public string TypeName { get; set; }
    }
}
