using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace OracleToRedisImport.Services
{
    class OracleToRedisMigrationService
    {
        private OracleService oracle;
        private JsonToRedisService redis;

        public OracleToRedisMigrationService(
            OracleService oracleServices,
            JsonToRedisService redisService)
        {
            oracle = oracleServices;
            redis = redisService;
        }

        private void MigrerTable(string sql, string redisKey)
        {
            List<Dictionary<string, object>> data =
                oracle.ExecuteSelect(sql);

            string json = JsonConvert.SerializeObject(
                data, Formatting.Indented);

            redis.SaveJsons(redisKey, json);
        }

        public void MigrerTout()
        {
            MigrerTable(
                "SELECT id_utilisateur, nom, email, telephone, password, roles, date_creation FROM utilisateur",
                "oracle:utilisateur");

            MigrerTable(
                "SELECT id_trajet, depart, destination, date_depart, prix, id_voiture FROM trajet",
                "oracle:trajet");

            MigrerTable(
                "SELECT id_voyage, id_trajet, id_voiture, date_depart, heure_depart, places_restantes, places_totales, etat_voyage FROM voyage",
                "oracle:voyage");

            MigrerTable(
                "SELECT id_reservation, id_client, id_voyage, date_reservation, nb_places, etat_reservation FROM reservation",
                "oracle:reservation");
            
        }
    }
}