using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using StackExchange.Redis;
using Newtonsoft.Json;
using OracleToRedisImport.Models;

namespace OracleToRedisImport.Services
{
    class TrajetMigrationService
    {
        private OracleService oracle;
        private JsonToRedisService redis;
       
        public TrajetMigrationService(OracleService oracleServices, JsonToRedisService redisService)
        {
            oracle = oracleServices;
            redis = redisService;
        }

        public MigrationResult MigrationTrajetToRedis()
        {

            string sql = "SELECT ID_TRAJET, DEPART, DESTINATION, DATE_DEPART, PRIX, ID_VOITURE FROM TRAJET";

            var rows = oracle.ExecuteSelect(sql);
            if (rows == null || rows.Count == 0)
            {
                Console.WriteLine("Aucune DOnnee recuperer d'oracle");
                return new MigrationResult
                {
                    Table = "TRAJETS",
                    Count = 0,
                    Json = "[]"
                };
            }


            List<Trajet> trajets = new List<Trajet>();

            foreach (var row in rows)
            {
                Trajet t = new Trajet
                {
                    id_trajet = row["ID_TRAJET"] == DBNull.Value ? 0 : Convert.ToInt32(row["ID_TRAJET"]),
                    depart = row["DEPART"] == DBNull.Value ? "" : row["DEPART"].ToString(),
                    destionation = row["DESTINATION"] == DBNull.Value ? "" : row["DESTINATION"].ToString(),
                    date_depart = row["DATE_DEPART"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["DATE_DEPART"]),
                    prix = row["PRIX"] == DBNull.Value ? 0 : Convert.ToInt32(row["PRIX"]),
                    id_voiture = row["ID_VOITURE"] == DBNull.Value ? 0 : Convert.ToInt32(row["ID_VOITURE"]),
                };

                redis.SaveJsons("trajet:" + t.id_trajet, t);
                trajets.Add(t);

            }
            Console.WriteLine("Migration de " + rows.Count + " trajet terminée !");

            //return JsonConvert.SerializeObject(trajets, Formatting.Indented);
            return new MigrationResult
            {
                Table = "TRAJETS",
                Count = trajets.Count,
                Json = JsonConvert.SerializeObject(trajets, Formatting.Indented)
            };
        }
    }
}
