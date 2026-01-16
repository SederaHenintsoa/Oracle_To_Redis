using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OracleToRedisImport.Models;

namespace OracleToRedisImport.Services
{
    class ReservationService
    {
        private OracleService oracle;
        private RedisService redis;

        public ReservationService(OracleService ORS, RedisService RS)
        {
            oracle = ORS;
            redis = RS;
        }

        public void MigrationReservationToRedis()
        {
            string sql = "SELECT ID_RESERVATION, ID_CLIENT, ID_VOYAGE ,DATE_RESERVATION, NB_PLACES , ETAT_RESERVATION, ETAT_PAIEMENT FROM RESERVATION";
            var rows = oracle.ExecuteSelect(sql);

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

                redis.SaveObjectsTables("Reservartion : "+ r.id_reservation, r);
            }
            Console.WriteLine("Migration de "+ rows.Count + " reservation terminée !");
        }
    }
}
