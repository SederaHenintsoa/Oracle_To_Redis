using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OracleToRedisImport.Models;

namespace OracleToRedisImport.Services
{
    class UtilisateurService
    {
        private OracleService oracle;
        private JsonToRedisService redis;

        public UtilisateurService(OracleService oracleServices, JsonToRedisService redisService)
        {


            if (oracleServices == null)
                throw new ArgumentNullException("oracleServices");
            if (redisService == null)
                throw new ArgumentNullException("redisService");

            oracle = oracleServices;
            redis = redisService;

        }


        public MigrationResult MigrationUsersToRedis()
        {

            Stopwatch sw = Stopwatch.StartNew();


            if (oracle == null)
            {
                throw new Exception("OracleService non initialisé");
            }
            if (redis == null)
            {
                throw new Exception("RedisService non initialisé");
            }
            string sql = "SELECT ID_UTILISATEUR, NOM, EMAIL, TELEPHONE, PASSWORD , ROLES, DATE_CREATION FROM UTILISATEUR";
            var rows = oracle.ExecuteSelect(sql);

            if (rows == null || rows.Count == 0)
            {
                Console.WriteLine("Aucune DOnnee recuperer d'oracle");
                return new MigrationResult
                {
                    Table = "UTILISATEUR",
                    Count= 0 ,
                    Json="[]"
                };
            }

            List<Utilisateur> utilisateurs = new List<Utilisateur>();

            foreach (var row in rows)
            {
             //   Console.WriteLine("Row: "+ string.Join(", ", row.Select(kv => kv.Key + "=" + kv.Value)));
                Utilisateur u = new Utilisateur
                {
                    id_utilisateur = row["ID_UTILISATEUR"] == DBNull.Value ? 0 : Convert.ToInt32(row["ID_UTILISATEUR"]),
                    nom = row["NOM"] == DBNull.Value ? "" : row["NOM"].ToString(),
                    email = row["EMAIL"] == DBNull.Value ? "" : row["EMAIL"].ToString(),
                    telephone = row["TELEPHONE"] == DBNull.Value ? 0 : Convert.ToInt32(row["TELEPHONE"]),
                    password = row["PASSWORD"] == DBNull.Value ? "" : row["PASSWORD"].ToString(),
                    roles = row["ROLES"] == DBNull.Value ? "" : row["ROLES"].ToString(),
                    date_creation = row["DATE_CREATION"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["DATE_CREATION"]),

                };

                redis.SaveJsons("utilisateur:"+ u.id_utilisateur, u);
                utilisateurs.Add(u);
            }
            Console.WriteLine("Migration de "+ rows.Count + " Utilisateur terminée !");

            //return JsonConvert.SerializeObject(utilisateurs, Formatting.Indented);
            return new MigrationResult
            {
                Table = "UTILISATEUR",
                Count = utilisateurs.Count,
                Json = JsonConvert.SerializeObject(utilisateurs, Formatting.Indented),

                DurationsMs = sw.ElapsedMilliseconds
            };
        }
    }

}
