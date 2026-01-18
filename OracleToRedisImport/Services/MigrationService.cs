using System.Collections.Generic;
using OracleToRedisImport.Models;

namespace OracleToRedisImport.Services
{
    class MigrationService
    {
        private UtilisateurService utilisateurService;
        private TrajetMigrationService trajetService;
        private VoyageService voyageService;
        private ReservationService reservationService;

        public MigrationService(
            UtilisateurService u,
            TrajetMigrationService t,
            VoyageService v,
            ReservationService r)
        {
            utilisateurService = u;
            trajetService = t;
            voyageService = v;
            reservationService = r;
        }

        public Dictionary<string, MigrationResult> MigrerTout()
        {
            var result = new Dictionary<string, MigrationResult>();

            result.Add(
                "Oracle:utilisateur",
                utilisateurService.MigrationUsersToRedis()
            );

            result.Add(
                "Oracle:trajet",
                trajetService.MigrationTrajetToRedis()
            );

            result.Add(
                "Oracle:voyage",
                voyageService.MigrationVoyageToRedis()
            );

            result.Add(
                "Oracle:reservation",
                reservationService.MigrationReservationToRedis()
            );

            return result;
        }
    }
}