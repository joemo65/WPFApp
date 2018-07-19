using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoanType.Serializer
{
    public class GenericSerializer
    {
        public T DeserializeFile<T>(string filePath) where T : class
        {
            var ser = new XmlSerializer(typeof(T));

            using (var sr = new StreamReader(filePath))
            {
                return (T)ser.Deserialize(sr);
            }
        }

        public T Deserialize<T>(string input) where T : class
        {
            var ser = new XmlSerializer(typeof(T));

            using (var sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }

        public string Serialize<T>(T ObjectToSerialize)
        {
            var xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

            using (var textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, ObjectToSerialize);
                return textWriter.ToString();
            }
        }

        public void SerializeToFile<T>(T ObjectToSerialize, string filePath) where T : class
        {
            var ser = Serialize(ObjectToSerialize);

            using (var sr = new StreamWriter(filePath))
            {
                sr.WriteLine(ser);
            }
        }
    }
}
