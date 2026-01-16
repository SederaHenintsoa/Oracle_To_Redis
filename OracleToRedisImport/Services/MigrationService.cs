using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OracleToRedisImport.Services;

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

        public void MigrerTout()
        {
            utilisateurService.MigrationUsersToRedis();
            trajetService.MigrationTrajetToRedis();
            voyageService.MigrationVoyageToRedis();
            reservationService.MigrationReservationToRedis();
        }
    }
}
