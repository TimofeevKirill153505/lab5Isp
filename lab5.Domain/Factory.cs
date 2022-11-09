namespace lab5.Domain
{
    public class Factory
    {
        public string Adress
        { get; private set; }

        List<Stock> Stocks = new List<Stock>();

        public Factory(string adress, List<Stock> stocks)
        {
            this.Adress = adress;
            this.Stocks = stocks;
        }
    }
}