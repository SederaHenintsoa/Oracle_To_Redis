using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OracleToRedisImport.Models;
using Newtonsoft.Json;


namespace OracleToRedisImport.Services
{
    class ReservationService
    {
        private OracleService oracle;
        private JsonToRedisService redis;

        public ReservationService(OracleService ORS, JsonToRedisService RS)
        {
            oracle = ORS;
            redis = RS;
        }

        public MigrationResult MigrationReservationToRedis()
        {
            string sql = "SELECT ID_RESERVATION, ID_CLIENT, ID_VOYAGE ,DATE_RESERVATION, NB_PLACES , ETAT_RESERVATION, ETAT_PAIEMENT FROM RESERVATION";
            var rows = oracle.ExecuteSelect(sql);
            if (rows == null || rows.Count == 0)
            {
                Console.WriteLine("Aucune DOnnee recuperer d'oracle");
                return new MigrationResult
                {
                    Table = "RESERVATION",
                    Count = 0,
                    Json = "[]"
                };
            }


            List<Reservation> reservations = new List<Reservation>();

            foreach (var row in rows)
            {
                 Reservation r = new Reservation
                {
                    id_reservation = row["ID_RESERVATION"] == DBNull.Value ? 0 : Convert.ToInt32(row["ID_RESERVATION"]),
                    id_client = row["ID_CLIENT"] == DBNull.Value ? 0 : Convert.ToInt32(row["ID_CLIENT"]),
                    id_voyage = row["ID_VOYAGE"] == DBNull.Value ? 0 : Convert.ToInt32(row["ID_VOYAGE"]),
                    date_reservation = row["DATE_RESERVATION"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["DATE_RESERVATION"]),
                    nb_places = row["NB_PLACES"] == DBNull.Value ? 0 : Convert.ToInt32(row["NB_PLACES"]),
                    etat_reservation = row["ETAT_RESERVATION"] == DBNull.Value ? "" : row["ETAT_RESERVATION"].ToString(),
                    etat_paiement = row["ETAT_PAIEMENT"] == DBNull.Value ? "" : row["ETAT_PAIEMENT"].ToString(), 
                };

                redis.SaveJsons("Reservartion : "+ r.id_reservation, r);
                reservations.Add(r);
            }
            Console.WriteLine("Migration de "+ rows.Count + " reservation terminée !");

            //return JsonConvert.SerializeObject(reservations, Formatting.Indented);
            return new MigrationResult
            {
                Table = "RESERVATION",
                Count = reservations.Count,
                Json = JsonConvert.SerializeObject(reservations, Formatting.Indented)
            };
        }
    }
}
