using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Newtonsoft.Json;
using System.Data;

namespace OracleToRedisImport.Services
{
    class OracleJsonProcess
    {
		public static string GetJsonFormOracle(string sql){
            DataTable dt = new DataTable();

            string connex = "User id=coop_user;Password=coop_bd_9006;Data Source=localhost/XE";

            using (OracleConnection conn = new OracleConnection(connex))
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand(sql, conn);

                OracleDataAdapter da = new OracleDataAdapter(cmd);

                da.Fill(dt);
            }

            return JsonConvert.SerializeObject(dt, Formatting.Indented);
        }
    }
}
