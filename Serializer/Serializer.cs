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
            FileStream stream = new FileStream(filename, FileMode.Open);
            Factory[] xxx = JsonSerializer.Deserialize<Factory[]>(stream);

            if (xxx == null) throw new Exception("нуль");
            stream.Close();

            return xxx;
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
            JsonSerializer.Serialize(stream, xxx.ToArray());
            stream.Close();
        }
    }
}