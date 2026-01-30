using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CooperativeAgentApp.Models;


namespace CooperativeAgentApp.Services
{
    class AuthService
    {
        public string jsonPath = "Auth/agent_auth.json";

        public Agent Login(string username, string password)
        {
            if (!File.Exists(jsonPath))
            {
                return null;
            }

            string json = File.ReadAllText(jsonPath);

            AuthRoot data = JsonConvert.DeserializeObject<AuthRoot>(json);

            if (data == null || data.agents == null)
            {
                return null;
            }

            return data.agents.FirstOrDefault(a =>
                a.username == username &&
                a.password == password &&
                a.actif == true);
        }
    }
}
