using lab5.Domain;

namespace lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Stock> stocks = new List<Stock>();
            Stock st = new Stock(1, new List<string> { "1", "2", "3"});
            stocks.Add(st);

            Factory f1 = new Factory("ул. Тимирязева 65", stocks);
            st = new Stock(2, new List<string> { "1", "4", "5"});
            stocks.Add(st);
            Factory f2 = new Factory("пр-т Независимости 1", stocks);
            List<Factory> f = new List<Factory> {f1,f2 };
            Serializer.Serializer serializer = new Serializer.Serializer();


            serializer.SerializeJSON(f, "D:/ИСП/Новая папка/File.json");
            var fs = serializer.DeSerializeJSON("D:/ИСП/Новая папка/File.json").ToArray();

            foreach(Factory factory in fs) Console.WriteLine(factory);
        }
    }
}