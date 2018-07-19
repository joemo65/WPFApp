using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoanType.UI.ViewModel;
using LoanType.DataService;
using Moq;
using Prism.Events;
using LoanType.UI.Event;

namespace LoanType.UI.Test
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void MainWindowViewModel_Initialize_IsNotNull()
        {
            var mockLoanTypeService = new Mock<ILoanTypeService>();
            var mockEventAggregator = new Mock<IEventAggregator>();
            var afterImport = new Mock<AfterImportFileEvent>();
            var afterUpdate = new Mock<AfterUpdateLoanTypeDetailViewEvent>();
            var afterCreate = new Mock<AfterCreateLoanTypeEvent>();
            var afterDelete = new Mock<AfterDeleteLoanTypeDetailViewEvent>();
            var openLoanType = new Mock<OpenLoanTypeDetailViewEvent>();

            mockEventAggregator.Setup(e => e.GetEvent<AfterImportFileEvent>()).Returns(afterImport.Object);
            mockEventAggregator.Setup(e => e.GetEvent<AfterUpdateLoanTypeDetailViewEvent>()).Returns(afterUpdate.Object);
            mockEventAggregator.Setup(e => e.GetEvent<AfterCreateLoanTypeEvent>()).Returns(afterCreate.Object);
            mockEventAggregator.Setup(e => e.GetEvent<AfterDeleteLoanTypeDetailViewEvent>()).Returns(afterDelete.Object);
            mockEventAggregator.Setup(e => e.GetEvent<OpenLoanTypeDetailViewEvent>()).Returns(openLoanType.Object);

            var vm = new MainWindowViewModel(mockLoanTypeService.Object, mockEventAggregator.Object);

            Assert.IsNotNull(vm);
        }
    }
}
