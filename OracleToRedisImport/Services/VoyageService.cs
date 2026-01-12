using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OracleToRedisImport.Models;

namespace OracleToRedisImport.Services
{
    class VoyageService
    {
        private OracleService oracle;
        private RedisService redis;

        public VoyageService(OracleService ORS, RedisService RS)
        {
            oracle = ORS;
            redis = RS;
        }

        public void MigrationVoyageToRedis()
        {

            string sql = "SELECT ID_VOYAGE, ID_TRAJET, ID_VOITURE, DATE_DEPART, HEURE_DEPART, PLACES_RESTANTES, ETAT_VOYAGE, PLACES_TOTALES FROM VOYAGE";

            var rows = oracle.ExecuteSelect(sql);

            foreach (var row in rows)
            {
                Voyage v = new Voyage
                {
                    id_voyage = row["ID_VOYAGE"] == DBNull.Value ? 0 : Convert.ToInt32(row["ID_VOYAGE"]),
                    id_trajet = row["ID_TRAJET"] == DBNull.Value ? 0 : Convert.ToInt32(row["ID_TRAJET"]),
                    id_voiture = row["ID_VOITURE"] == DBNull.Value ? 0 : Convert.ToInt32(row["ID_VOITURE"]),
                    date_depart = row["DATE_DEPART"] == DBNull.Value ? DateTime.MinValue: Convert.ToDateTime(row["DATE_DEPART"]),
                    heure_depart = row["HEURE_DEPART"] == DBNull.Value ? "" : row["HEURE_DEPART"].ToString(),
                    places_restantes = row["PLACES_RESTANTES"] == DBNull.Value ? 0 : Convert.ToInt32(row["PLACES_RESTANTES"]),
                    etat_voyage = row["ETAT_VOYAGE"] == DBNull.Value ? "" :row["ETAT_VOYAGE"].ToString(),
                    places_totales = row["PLACES_TOTALES"] == DBNull.Value ? 0 : Convert.ToInt32(row["PLACES_TOTALES"])
                };

                redis.SaveObjectsTables("voyage:" + v.id_voyage, v);
            }
            Console.WriteLine("Migration de " + rows.Count + " Voyage terminée !");
        }
    }
}
