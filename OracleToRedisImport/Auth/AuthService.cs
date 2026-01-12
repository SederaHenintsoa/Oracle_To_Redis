using System;
using System.IO;

namespace OracleToRedisImport.Auth
{
    class AuthService
    {
        private string username;
        private string password;

        public AuthService()
        {
            ChargerConfig();
        }

        private void ChargerConfig()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(basePath, "ConfigAdmin","admin.config");

            if (!File.Exists(path))
                throw new Exception("Fichier de configuration introuvable : " + path);

            string[] rows = File.ReadAllLines(path);

            foreach (string row in rows)
            {
                if (row.StartsWith("username"))
                    username = row.Split('=')[1].Trim();

                if (row.StartsWith("password"))
                    password = row.Split('=')[1].Trim();
            }
        }

        public bool Authentifier(string user, string pass)
        {
            return user == username && pass == password;
        }
    }
}