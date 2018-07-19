using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoanType.Serializer
{
    public class LoanTypeSerializable
    {
        public LoanTypeSerializable()
        {

        }

        public LoanTypeSerializable(int id, string typeName)
        {
            Id = id;
            TypeName = typeName;
        }

        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("typeName")]
        public string TypeName { get; set; }
    }
}
