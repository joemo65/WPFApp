using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoanType.Serializer
{
    [XmlRoot("LoanTypes")]
    public class LoanTypesSerializable
    {
        public LoanTypesSerializable()
        {
            LoanTypes = new List<LoanTypeSerializable>();
        }

        [XmlElement("LoanType")]
        public List<LoanTypeSerializable> LoanTypes { get; set; }
    }
}
