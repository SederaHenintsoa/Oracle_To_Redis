using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleToRedisImport.Models
{
    class Reservation
    {
        public int id_reservation { get; set; }
        public int id_client { get; set; }
        public int id_voyage { get; set; }
        //public string date_reservation  { get; set; }
        public DateTime date_reservation { get; set; }
        public int nb_places { get; set; }
        public string etat_reservation { get; set; }
        public string etat_paiement { get; set; }
    }
}
