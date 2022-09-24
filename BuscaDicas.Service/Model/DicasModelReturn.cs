using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaDicas.Service.Model
{
    public class DicasModelReturn
    {
       public Slip Slip { get; set; }
    }


    public class Slip
    {
        public int id { get; set; }
        public string advice { get; set; }
    }
}
