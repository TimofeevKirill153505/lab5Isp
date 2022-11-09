using lab5.Domain;
using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Serializer
{
    public class Serializer :ISerializer
    {
        public IEnumerable<Factory> DeSerializeByLINQ(string filename)
        {
            XDocument xDocument = XDocument.Load(filename);
            XElement? el = xDocument.Root;
            if (el == null) throw new Exception();
            return el.Elements("Factory").Select((f) =>
                                          {
                                              var adress = f.Element("Adress").Value;
                                              var ls = f.Element("Stocks").Elements("Stock").Select((s) =>
                                                                          {
                                                                              int numb = Convert.ToInt32(s.Element("number").Value);
                                                                              var l = s.Element("details").Elements("string").Select((str) => str.Value).ToList();
                                                                              return new Stock(numb, l);
                                                                          }
                                              ).ToList();

                                              return new Factory(adress, ls);
                                          }
            ).ToArray();
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
            XmlSerializer serializer = new XmlSerializer(typeof(Factory[]));
            var stream = new FileStream(filename, FileMode.Open);
            Factory[] f = serializer.Deserialize(stream) as Factory[];
            if (f == null) throw new Exception("нуль");
            stream.Close();
            return f;
        }

        public void SerializeByLINQ(IEnumerable<Factory> xxx, string filename)
        {
            XDocument doc = XDocument.Load(filename);
            doc.Root.RemoveAll();

            foreach(Factory factory in xxx)
            {
                XElement fact = new XElement("Factory");
                fact.Add(new XElement("Adress", factory.Adress));
                XElement stocks = new XElement("Stocks");
                foreach(Stock stock in factory.Stocks)
                {
                    XElement st = new XElement("Stock");
                    st.Add(new XElement("number", stock.number));
                    var strings = new XElement("details");
                    foreach(string detail in stock.details)
                    {
                        strings.Add(new XElement("string", detail));
                    }
                    st.Add(strings);
                    stocks.Add(st);
                }

                fact.Add(stocks);
                doc.Root.Add(fact);
            }
            doc.Save(filename);
        }

        public void SerializeByXML(IEnumerable<Factory> xxx, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Factory[]));
            var stream = new FileStream(filename, FileMode.Open);
            serializer.Serialize(stream, xxx.ToArray());
            stream.Close();
        }
        public void SerializeJSON(IEnumerable<Factory> xxx, string filename)
        {
            FileStream stream = new FileStream(filename, FileMode.Open);
            JsonSerializer.Serialize(stream, xxx.ToArray());
            stream.Close();
        }
    }
}