using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OracleToRedisImport.Services
{
    class UtilisateurService
    {
        private OracleService oracle;
        private RedisService redis;

        public UtilisateurService(OracleService ORS, RedisService RS)
        {
            oracle = ORS;
            redis = RS;
        }

        public void MigrationUsersToRedis()
        {
            string sql = "SELECT ID_UTILISATEUR, NOM, EMAIL, TELEPHONE, PASSWORD , ROLES, DATE_CREATION FROM UTILISATEUR";
            var rows = oracle.ExecuteSelect(sql);

            foreach (var row in rows)
            {
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
            }
            Console.WriteLine("Migration de "+ rows.Count + " Utilisateur terminée !");
        }
    }

}
