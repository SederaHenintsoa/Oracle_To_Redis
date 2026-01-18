using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleToRedisImport.Models
{
    public class MigrationResult
    {
        public string Table { get; set; }
        public int Count { get; set; }
        public string Json { get; set; }
        public long DurationsMs { get; set; }
    }
}