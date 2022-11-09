using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.Domain
{
    public interface ISerializer
    {
        IEnumerable<Factory> DeSerializeByLINQ(string filename);

        IEnumerable<Factory> DeSerializeXML(string filename);

        IEnumerable<Factory> DeSerializeJSON(string filename);

        void SerializeByLINQ(IEnumerable<Factory> xxx, string filename);

        void SerializeByXML(IEnumerable<Factory> xxx, string filename);

        void SerializeJSON(IEnumerable<Factory> xxx, string filename);
    }
}
