using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBookTrading
{
    public class model
    {
        public int Stt { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public model(int id, int stt,string name)
        {
            this.Id = id;
            this.Stt = stt;
            this.Name = name;
        }

    }
}
