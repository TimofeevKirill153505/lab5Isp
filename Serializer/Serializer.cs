using lab5.Domain;
using System.Text.Json;

namespace Serializer
{
    public class Serializer :ISerializer
    {
        public IEnumerable<Factory> DeSerializeByLINQ(string filename)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Factory> DeSerializeJSON(string filename)
        {
                
        }

        public IEnumerable<Factory> DeSerializeXML(string filename)
        {
            throw new NotImplementedException();
        }

        public void SerializeByLINQ(IEnumerable<Factory> xxx, string filename)
        {
            throw new NotImplementedException();
        }

        public void SerializeByXML(IEnumerable<Factory> xxx, string filename)
        {

        }
        public void SerializeJSON(IEnumerable<Factory> xxx, string filename)
        {
            FileStream stream = new FileStream(filename, FileMode.Open);
            foreach (Factory factory in xxx) JsonSerializer.Serialize<Factory>(stream,factory);
        }
    }
}