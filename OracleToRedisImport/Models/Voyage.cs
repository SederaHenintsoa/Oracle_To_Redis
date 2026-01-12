using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleToRedisImport.Models
{
    class Voyage
    {
        public int id_voyage { get; set; }
        public int id_trajet { get; set; }
        public int id_voiture { get; set; }
        //public string date_depart { get; set; }
        public DateTime date_depart { get; set; }
        public string heure_depart { get; set; }
        public int places_restantes { get; set; }
        public string etat_voyage { get; set; }
        public int places_totales { get; set; }
    }
}
