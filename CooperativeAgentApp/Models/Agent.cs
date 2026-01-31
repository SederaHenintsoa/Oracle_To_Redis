using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeAgentApp.Models
{
    public class Agent
    {
        public int id_agent { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool actif { get; set; }
        public bool isAdmin { get; set;  }
    }
}
