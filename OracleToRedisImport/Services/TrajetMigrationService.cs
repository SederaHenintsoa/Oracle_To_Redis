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
        private RedisService redis;

        public TrajetMigrationService(OracleService ORS, RedisService RS)
        {
            oracle = ORS;
            redis = RS;
        }

        public void MigrationTrajetToRedis()
        {

            string sql = "SELECT ID_TRAJET, DEPART, DESTINATION, DATE_DEPART, PRIX, ID_VOITURE FROM TRAJET";

            var rows = oracle.ExecuteSelect(sql);

            foreach (var row in rows)
            {
                Trajet t = new Trajet
                {
                    id_trajet = Convert.ToInt32(row["ID_TRAJET"]),
                    depart = row["DEPART"].ToString(),
                    destionation = row["DESTINATION"].ToString(),
                    date_depart = Convert.ToDateTime(row["DATE_DEPART"]).ToString("yyyy-MM-dd"),
                    prix = Convert.ToInt32(row["PRIX"]),
                    id_voiture = Convert.ToInt32(row["ID_VOITURE"])
                };

                redis.SaveObjectsTables("trajet:" + t.id_trajet, t);
            }
            Console.WriteLine("Migration de " + rows.Count + " trajet terminée !");
            
        }
    }
}
