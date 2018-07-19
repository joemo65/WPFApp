using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoanType.DataService.Test
{
    [TestClass]
    public class LoanTypeServiceTests
    {
        [Ignore]
        [DeploymentItem("LoanTypes.xml")]
        [TestMethod]
        public void ImportLoanTypes_ValidFile_NotNull()
        {
            LoanTypeService lts = new LoanTypeService();
            var types = lts.ImportLoanTypes("LoanTypes.xml");
            Assert.IsNotNull(types);
        }

        [TestMethod]
        public void SaveLoanTypes_EmptyLoanTypes_AreEqual()
        {
            LoanTypeService lts = new LoanTypeService();

            LoanTypes lt = new LoanTypes();
            lts.SaveLoanTypes(lt);

            Assert.AreEqual(lts.GetLoanTypes(), lt);
        }

        [TestMethod]
        public void GetLoanTypes_EmptyLoanTypes_AreEqual()
        {
            LoanTypeService lts = new LoanTypeService();

            LoanTypes lt = new LoanTypes();
            LoanTypes getLT = lts.GetLoanTypes();

            Assert.AreEqual(getLT.Types.Count, lt.Types.Count);
        }

        [Ignore]
        [DeploymentItem("ExportLoanTypes.xml")]
        [TestMethod]
        public void ExportToFile_EmptyLoanTypes_IsNotNull(string file)
        {
            LoanTypeService lts = new LoanTypeService();
            lts.ExportToFile("ExportLoanTypes.xml");
            var types = lts.ImportLoanTypes("ExportLoanTypes.xml");

            Assert.IsNotNull(types);
        }

        [TestMethod]
        public void UpdateLoanType_ChangeOneName_AreSame()
        {
            LoanTypeService lts = new LoanTypeService();
            lts.AddLoanType(1, "test");
            lts.UpdateLoanType(new LoanType(1, "updated"));
            var types = lts.GetLoanTypes();

            Assert.AreSame(types.Types[0].TypeName, "updated");
        }

        [TestMethod]
        public void RemoveLoanType_RemoveIdOne_AreSame()
        {
            LoanTypeService lts = new LoanTypeService();
            lts.AddLoanType(1, "test");
            lts.AddLoanType(2, "test2");
            lts.RemoveLoanType(new LoanType(1, "test"));

            var types = lts.GetLoanTypes();

            Assert.AreEqual(types.Types[0].TypeName, "test2");
        }

        [TestMethod]
        public void AddLoanType_AddToEmpty_AreSame()
        {
            LoanTypeService lts = new LoanTypeService();
            lts.AddLoanType(1, "test");

            var types = lts.GetLoanTypes();

            Assert.AreEqual(types.Types[0].TypeName, "test");
        }
    }
}
