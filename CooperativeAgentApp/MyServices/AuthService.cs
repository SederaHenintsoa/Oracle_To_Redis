using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using CooperativeAgentApp.Models;
using System.Collections.Generic;

namespace CooperativeAgentApp.Services
{
    public class AuthService
    {
        private string filePath;

        public AuthService()
        {
            // Chemin réel à l'exécution (bin/Debug/)
            filePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "auth",
                "agent_auth.json"
            );
        }

        public Agent Login(string username, string password)
        {
            var json = File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<AuthData>(json);

            if (data == null || data.agents == null)
                throw new Exception("Fichier JSON invalide");

            foreach (var a in data.agents)
            {
                Console.WriteLine("AGENT JSON: " + a.username + " / " + a.password);
            }

            return data.agents.FirstOrDefault(a =>
                a.username.Trim().Equals(username.Trim(), StringComparison.OrdinalIgnoreCase) &&
                a.password.Trim() == password.Trim() &&
                a.actif);
        }

    }

    public class AuthData
    {
        public List<Agent> agents { get; set; }
    }
}
