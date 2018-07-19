using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoanType.Serializer.Test
{
    [TestClass]
    public class GenericSerializerTests
    {
        [TestMethod]
        public void GenericSerializer_SerializeLoanTypesSerializable_IsNotNull()
        {
            GenericSerializer gs = new GenericSerializer();
            var lts = new LoanTypesSerializable();
            var str = gs.Serialize(lts);

            Assert.IsNotNull(str);
        }

        [Ignore]
        [DeploymentItem("LoanTypes.xml")]
        [TestMethod]
        public void GenericSerializer_DeSerializeLoanTypesSerializable_AreSame()
        {
            GenericSerializer gs = new GenericSerializer();
            var lts = gs.Deserialize<LoanTypesSerializable>("LoanTypes.xml");

            Assert.AreSame(lts, new LoanTypesSerializable());
        }
    }
}
