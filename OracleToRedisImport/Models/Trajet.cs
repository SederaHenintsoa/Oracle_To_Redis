using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleToRedisImport.Models
{
    class Trajet
    {
        public int id_trajet { get; set; }
        public string depart { get; set; }
        public string destionation { get; set; }
        public string date_depart { get; set; }
        public decimal prix { get; set; }
        public int id_voiture { get; set; }
    }
}
