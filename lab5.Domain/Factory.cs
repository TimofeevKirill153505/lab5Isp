using System.Collections;

namespace lab5.Domain
{
    public class Factory
    {
        public string Adress
        { get; set; }

        private List<Stock> stocks = new List<Stock>();

        public List<Stock> Stocks
        {
            get => stocks;
            set => stocks = value;
        }

        public Factory(string adress, List<Stock> stocks)
        {
            this.Adress = adress;
            this.stocks = new List<Stock>(stocks);
        }

        public Factory() { }

        override public string ToString()
        {
            string f = string.Empty;
            foreach (Stock stock in stocks) f += stock + "\n";
            string text = "Адрес: " + Adress + "{\n" + f + "}";

            return text;
        }
    }
}