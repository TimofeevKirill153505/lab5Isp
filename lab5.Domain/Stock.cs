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
        public string[] details{ get; private set; }

        public Stock(int number, string[] details)
        {
            this.number = number;
            this.details = details;
        }

    }
}
