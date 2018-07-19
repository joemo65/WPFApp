using LoanType.Serializer;
using System.Linq;
using System;

namespace LoanType.DataService
{
    public class LoanTypeService : ILoanTypeService
    {
        public LoanTypeService()
        {
            _loanTypes = new LoanTypes();
        }

        //storing a set of the data to mock it being stored in a repository
        private LoanTypes _loanTypes;

        public LoanTypes ImportLoanTypes(string file)
        {
            var ser = new GenericSerializer();
            var lts = ser.DeserializeFile<LoanTypesSerializable>(file);

            _loanTypes = new LoanTypes();
            foreach (var type in lts.LoanTypes)
            {
                _loanTypes.Types.Add(new LoanType(type.Id, type.TypeName));
            }

            return _loanTypes;
        }

        public void SaveLoanTypes(LoanTypes loanTypes)
        {
            _loanTypes = loanTypes;
        }

        public LoanTypes GetLoanTypes()
        {
            return _loanTypes;
        }

        public void ExportToFile(string file)
        {
            var ser = new GenericSerializer();

            var lts = new LoanTypesSerializable();
            foreach(var type in _loanTypes.Types)
            {
                lts.LoanTypes.Add(new LoanTypeSerializable(type.Id, type.TypeName));
            }

            ser.SerializeToFile(lts, file);
        }

        public void UpdateLoanType(LoanType loanType)
        {
            var lt = _loanTypes.Types.FirstOrDefault(x => x.Id == loanType.Id);
            if (lt == null)
                _loanTypes.Types.Add(loanType);
            else
                lt.TypeName = loanType.TypeName;
        }

        public void RemoveLoanType(LoanType loanType)
        {
            if( _loanTypes.Types.Any(x => x.Id == loanType.Id))
            {
                _loanTypes.Types.RemoveAll(x => x.Id == loanType.Id);
            }
        }

        public void AddLoanType(int id, string typeName)
        {
            _loanTypes.Types.Add(new LoanType(id, typeName));

        }
    }
}
