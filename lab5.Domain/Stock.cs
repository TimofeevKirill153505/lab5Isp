using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.Domain
{
    public class Stock
    {
        public int number{ get; private set; }
        public List<string> details{ get; private set; }

        public Stock(int number, List<string> details)
        {
            this.number = number;
            this.details = new List<string>(details);
        }


        public override string ToString()
        {
            string text = "Номер: " + number + " Детали: ";
            foreach (string detail in details) text += detail + " ";

            return text;

        }
    }
}
