using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StackExchange.Redis;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using OracleToRedisImport.Services;
using OracleToRedisImport.FormsWindow;
namespace OracleToRedisImport
{
    class Program
    {
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);

         //   Application.Run(new LoginForm());
            Application.Run(new MainForm());
        }
    }
}
