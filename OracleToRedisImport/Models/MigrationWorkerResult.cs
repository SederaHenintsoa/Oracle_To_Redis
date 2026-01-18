using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleToRedisImport.Models
{
    class MigrationWorkerResult
    {
        public MigrationResult Utilisateurs { get; set; }
        public MigrationResult Trajets { get; set; }
        public MigrationResult Voyages { get; set; }
        public MigrationResult Reservations { get; set; }
    }
}
