using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleToRedisImport
{
    class Utilisateur
    {
        public int id_utilisateur { get; set; }
        public string nom { get; set; }
        public string email { get; set; }
        public int telephone { get; set; }
        public string password { get; set; }
        public string roles { get; set; }
        //public string date_creation { get; set; }
        public DateTime date_creation { get; set; }
    }
}
