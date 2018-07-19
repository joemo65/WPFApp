using LoanType.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanType.UI.Test
{
    public class MockLoanTypeService : ILoanTypeService
    {
        public void AddLoanType(int id, string typeName)
        {
            throw new NotImplementedException();
        }

        public void ExportToFile(string file)
        {
            throw new NotImplementedException();
        }

        public LoanTypes GetLoanTypes()
        {
            throw new NotImplementedException();
        }

        public LoanTypes ImportLoanTypes(string file)
        {
            throw new NotImplementedException();
        }

        public void RemoveLoanType(DataService.LoanType loanType)
        {
            throw new NotImplementedException();
        }

        public void SaveLoanTypes(LoanTypes loanTypes)
        {
            throw new NotImplementedException();
        }

        public void UpdateLoanType(DataService.LoanType loanType)
        {
            throw new NotImplementedException();
        }
    }
}
