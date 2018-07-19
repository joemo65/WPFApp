using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanType.DataService
{
    public interface ILoanTypeService
    {
        LoanTypes ImportLoanTypes(string file);
        void SaveLoanTypes(LoanTypes loanTypes);
        LoanTypes GetLoanTypes();
        void ExportToFile(string file);
        void UpdateLoanType(LoanType loanType);
        void RemoveLoanType(LoanType loanType);
        void AddLoanType(int id, string typeName);
    }
}
