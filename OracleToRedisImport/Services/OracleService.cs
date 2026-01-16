using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace OracleToRedisImport.Services
{
    class OracleService
    {
        public string ConnectionString {get; private set;}

        public OracleService(string conn)
        {
            ConnectionString = conn;
        }

        public List<Dictionary<string, object>> ExecuteSelect(string sql)
        {
            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
           
            using (OracleConnection conn = new OracleConnection(ConnectionString)) 
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand(sql, conn);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Dictionary<string, object> row = new Dictionary<string, object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[reader.GetName(i)] = reader.IsDBNull(i)? null : reader.GetValue(i);
                    }
                    results.Add(row);
                }
                conn.Close();
            }

            return results;
        }

    }
}
