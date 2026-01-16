using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OracleToRedisImport.Services
{
    class UtilisateurService
    {
        private OracleService oracle;
        private RedisService redis;
        private OracleService oracleServices;
        private JsonToRedisService redisService;

        /*
        public UtilisateurService(OracleService ORS, RedisService RS)
        {
            oracle = ORS;
            redis = RS;
        }*/

        public UtilisateurService(OracleService oracleServices, JsonToRedisService redisService)
        {
         
            this.oracleServices = oracleServices;
            this.redisService = redisService;
        }


        public string MigrationUsersToRedis()
        {
            string sql = "SELECT ID_UTILISATEUR, NOM, EMAIL, TELEPHONE, PASSWORD , ROLES, DATE_CREATION FROM UTILISATEUR";
            var rows = oracle.ExecuteSelect(sql);

            if (rows == null || rows.Count == 0)
            {
                Console.WriteLine("Aucune DOnnee recuperer d'oracle");
                return "Aucune donnee dans oracle";
            }

            List<Utilisateur> utilisateurs = new List<Utilisateur>();

            foreach (var row in rows)
            {
             //   Console.WriteLine("Row: "+ string.Join(", ", row.Select(kv => kv.Key + "=" + kv.Value)));
                Utilisateur u = new Utilisateur
                {
                    id_utilisateur = Convert.ToInt32(row["ID_UTILISATEUR"]),
                    nom = row["NOM"].ToString(),
                    email = row["EMAIL"].ToString(),
                    telephone = Convert.ToInt32(row["TELEPHONE"]),
                    password = row["PASSWORD"].ToString(),
                    roles = row["ROLES"].ToString(),
                    date_creation = Convert.ToDateTime(row["DATE_CREATION"])

                };

                redis.SaveObjectsTables("utilisateur:"+ u.id_utilisateur, u);
                utilisateurs.Add(u);
            }
            Console.WriteLine("Migration de "+ rows.Count + " Utilisateur terminée !");

            return JsonConvert.SerializeObject(utilisateurs, Formatting.Indented);
        }
    }

}
