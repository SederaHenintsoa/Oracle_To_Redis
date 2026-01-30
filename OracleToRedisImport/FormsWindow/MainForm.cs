using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using OracleToRedisImport.Models;
using Oracle.ManagedDataAccess.Client;
using OracleToRedisImport.Services;

namespace OracleToRedisImport.FormsWindow
{
    public partial class MainForm : Form
    {
        private string migrationResult = "";
        private JsonToRedisService redisService;
        private OracleService oracleServices;
     //   private OracleToRedisMigrationService migrationService;

        private MigrationService migrationServices;
        
        private UtilisateurService utilisateurService;
        private TrajetMigrationService trajetService;
        private VoyageService voyageService;
        private ReservationService reservationService;

        private string JsonCourant = "";
        private string TableCourante = "";

        public MainForm()
        {
            InitializeComponent();

            oracleServices = new OracleService("User id=coop_user;Password=coop_bd_9006;Data Source=localhost/XE");

            redisService = new JsonToRedisService("localhost:6379");

            utilisateurService = new UtilisateurService(oracleServices, redisService);

            trajetService = new TrajetMigrationService(oracleServices, redisService);

            voyageService = new VoyageService(oracleServices, redisService);

            reservationService = new ReservationService(oracleServices, redisService);

            migrationServices = new MigrationService(utilisateurService, trajetService, voyageService, reservationService);

            bgMigrations.DoWork += bgMigrations_DoWork;
            bgMigrations.ProgressChanged += bgMigrations_ProgressChanged;
            bgMigrations.RunWorkerCompleted += bgMigrations_RunWorkerCompleted;
        }

        private void bgMigrations_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            worker.ReportProgress(10, "Migration des utilisateurs...");
            var users = utilisateurService.MigrationUsersToRedis();

            worker.ReportProgress(35, "Migration des trajets...");
            var trajets = trajetService.MigrationTrajetToRedis();

            worker.ReportProgress(60, "Migration des voyages...");
            var voyages = voyageService.MigrationVoyageToRedis();

            worker.ReportProgress(85, "Migration des réservations...");
            var reservations = reservationService.MigrationReservationToRedis();

            worker.ReportProgress(100, "Migration terminée");

            e.Result = new MigrationWorkerResult
            {
                Utilisateurs = users,
                Trajets = trajets,
                Voyages  = voyages,
                Reservations = reservations
            };
        }

        private void bgMigrations_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressMigration.Value = e.ProgressPercentage;
            lblProgress.Text = e.UserState.ToString();
        }


        private void bgMigrations_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EnableMigrationButtons();
            if (e.Cancelled)
            {
                lblProgress.Text = "Migration Annulée";
                return;
            }
            var result = e.Result as MigrationWorkerResult;

            richTextBox2.Clear();

            richTextBox2.AppendText("=== UTILISATEURS (" + result.Utilisateurs.Count + ") ===\n");
            richTextBox2.AppendText(result.Utilisateurs.Json + "\n\n");

            richTextBox2.AppendText("=== TRAJETS (" + result.Trajets.Count + ") ===\n");
            richTextBox2.AppendText(result.Trajets.Json + "\n\n");

            richTextBox2.AppendText("=== VOYAGES (" + result.Voyages.Count + ") ===\n");
            richTextBox2.AppendText(result.Voyages.Json + "\n\n");

            richTextBox2.AppendText("=== RESERVATIONS (" + result.Reservations.Count + ") ===\n");
            richTextBox2.AppendText(result.Reservations.Json);

            ColorizeJson(richTextBox2);
            EnableMigrationButtons();

            MessageBox.Show(
                "Migration complète terminée avec succès",
                "Succès",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

       
       
        private void ResetProgress()
        {
            progressMigration.Value = 0;
            lblProgress.Text = "Démarrage de la migration...";
            Application.DoEvents();
        }

        private void UpdateProgres(int value, string message)
        {
            progressMigration.Value = value;
            lblProgress.Text = message;
            Application.DoEvents();
        }

        private void DisableMigrationButtons()
        {
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            MgrTout.Enabled = false;
        }
        private void EnableMigrationButtons()
        {
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            MgrTout.Enabled = true;
        }
        private string JsonStyle(string json)
        {
            JToken JsonParser = JToken.Parse(json);
            return JsonParser.ToString(Formatting.Indented);
        }

        public void ColorizeJson(RichTextBox box)
        {
            box.SelectAll();
            box.SelectionColor = System.Drawing.Color.Black;

            string text = box.Text;
            
            //coloration de Clé
            Colorize(box, "\"[^\"]+\"(?=\\s*:)", System.Drawing.Color.Blue);

            // Valeurs string
            Colorize(box, ":\\s*\"[^\"]*\"", System.Drawing.Color.DarkGreen);

            // Nombres
            Colorize(box, ":\\s*[0-9]+(\\.[0-9]+)?", System.Drawing.Color.Purple);

            // Booléens / null
            Colorize(box, ":\\s*(true|false|null)", System.Drawing.Color.Brown);

            // Accolades
            Colorize(box, "[\\{\\}\\[\\]]", System.Drawing.Color.Gray);

            box.SelectionStart = 0;
            box.SelectionLength = 0;

            box.ResumeLayout();
            
        }

        public void LoadJsonToTree(string json)
        {
            treeJson.Nodes.Clear();

            if (string.IsNullOrWhiteSpace(json))
            {
                return;
            }

            JToken token = JToken.Parse(json);

            TreeNode root = new TreeNode("JSON");
            treeJson.Nodes.Add(root);

            AddNode(token, root);
            treeJson.ExpandAll();
        }

        private void AddNode(JToken token, TreeNode node)
        {
            if (token == null)
            {
                return;
            }
                if(token.Type == JTokenType.Object){
                
                    JObject obj = (JObject)token;

                    foreach (JProperty props in obj.Properties())
                    {
                        TreeNode child = new TreeNode(props.Name);
                        node.Nodes.Add(child);

                        AddNode(props.Value, child);
                    }
            }

            else if (token.Type == JTokenType.Array)
            {
                JArray array = (JArray)token;
                int index = 0;

                foreach (JToken item in array)
                {
                    TreeNode child = new TreeNode("[" + index + " ]");
                    node.Nodes.Add(child);

                    AddNode(item, child);
                    index++;
                }
            }
            else
            {
                //node.Nodes.Add(new TreeNode(token.ToString()));

                string value = token.ToString();
                node.Nodes.Add(new TreeNode("Value: " + value));
            }
        }
        private void Colorize(RichTextBox box, string pattern, System.Drawing.Color color)
        {
            System.Text.RegularExpressions.MatchCollection matches = System.Text.RegularExpressions.Regex.Matches(box.Text, pattern);

            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                box.Select(match.Index, match.Length);
                box.SelectionColor = color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "SELECT id_utilisateur, nom, email, telephone, password , roles, date_creation FROM utilisateur";

            string json = OracleJsonProcess.GetJsonFormOracle(sql);
            rtbJson.Text = JsonStyle(json);
            JsonCourant = json;
            TableCourante = "Utilisateur";

            ColorizeJson(rtbJson);

            //string formattedJson = JsonStyle(json);
            LoadJsonToTree(json);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "SELECT id_trajet, depart, destination, date_depart, prix , id_voiture FROM trajet";

            string json = OracleJsonProcess.GetJsonFormOracle(sql);
            rtbJson.Text = JsonStyle(json);
            JsonCourant = json;
            TableCourante = "trajet";

            ColorizeJson(rtbJson);

            //string formattedJson = JsonStyle(json);
            LoadJsonToTree(json);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "SELECT id_voyage, id_trajet, id_voiture, date_depart, heure_depart, places_restantes, places_totales, etat_voyage FROM voyage";

            string json = OracleJsonProcess.GetJsonFormOracle(sql);
            rtbJson.Text = JsonStyle(json);
            JsonCourant = json;
            TableCourante = "voyage";

            ColorizeJson(rtbJson);

//            string formattedJson = JsonStyle(json);
            LoadJsonToTree(json);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql = "SELECT id_reservation, id_client, id_voyage, date_reservation, nb_places, etat_reservation, etat_paiement FROM reservation";

            string json = OracleJsonProcess.GetJsonFormOracle(sql);
            rtbJson.Text = JsonStyle(json);
            JsonCourant = json;
            TableCourante = "reservation";

            ColorizeJson(rtbJson);

            //string formattedJson = JsonStyle(json);
            LoadJsonToTree(json);

        }


        private void btnExporteJson_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbJson.Text))
            {
                MessageBox.Show(
                "Aucun Json à exporter", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning
               );
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = " FIchier JSON (*.json)|*.json";
            saveDialog.Title = "Exporter le JSON";
            saveDialog.FileName = "Export.json";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveDialog.FileName, rtbJson.Text);

                MessageBox.Show("JSON exporté avec succès", "Succès",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
            }
        }

    
        private void btnImportCles_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (migrationServices == null)
                {
                    MessageBox.Show("Migration Service non initialisé!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var results = migrationServices.MigrerTout();

                if (results == null || results.Count == 0)
                {
                    MessageBox.Show("Aucune Donnée migrée!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                rtbRedis.Clear();

                foreach (var item in results)
                {
                 //   string json = item.Value;

                    MigrationResult migration = item.Value;

                    string json = string.IsNullOrWhiteSpace(migration.Json) ? "[]" : migration.Json;

                    if (string.IsNullOrWhiteSpace(json) || !json.Trim().StartsWith("{") && !json.Trim().StartsWith("["))
                        json = "[]"; 
                    rtbRedis.AppendText("CLE REDIS :" + item.Key + "\n" +
                        "TABLE :"+ migration.Table+ "\n"+
                        JsonStyle(json)+ "\n\n---------------\n\n");
                }
                ColorizeJson(rtbRedis);

                MessageBox.Show(
                    "Migration complète Oracle → Redis terminée",
                    "Succès",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur Redis : "+ ex.Message ,"Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
        }

        
        private void btnVoirCles_Click_1(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Clés Redis :\n\n" + "Oracle.utilisateur\n" + "Oracle:trajet\n" + "Oracle:voyage\n" + "Oracle:reservation", "Redis",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur Redis : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            List<string> keys = redisService.GetAllkeys();

            if (keys.Count == 0)
            {
                MessageBox.Show("Aucune clé Redis Trouvée ");
                return;
            }

            rtbRedis.Clear();
            rtbRedis.AppendText("CLES REDIS DISPONIBLES:\n\n:");

                foreach(string key in keys){
                    rtbRedis.AppendText("-"+ key + "\n");
                    Console.WriteLine("REDIS KEY => [" + key + "]");
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                ResetProgress();
                UpdateProgres(30, "Migration des Utilisateurs...");
                UpdateProgres(100, "Migrations terminées");

                if (utilisateurService == null)
                {
                    throw new Exception("Utilisateur null");
                }
                if(oracleServices == null)
                    throw new Exception("OracleService null");
                if(redisService == null)
                    throw new Exception("redisService null");
                if(migrationServices == null)
                    throw new Exception("migrationService null");

              //  string json = utilisateurService.MigrationUsersToRedis();
                MigrationResult result = utilisateurService.MigrationUsersToRedis();

                MessageBox.Show("Migration des utilisateurs terminée", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MessageBox.Show(
                    "Migration terminée\n" +
                    "Table :"+ result.Table+"\n" +
                    "Lignes :"+ result.Count+"\n" +
                    "Temps :"+ result.DurationsMs +" ms",
                    "Succès",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                richTextBox2.Clear();
                richTextBox2.AppendText(
                    "===="+ result.Table+ "====\n"+
                    "Lignes : " +result.Count +"\n"+
                    "Temps : " + result.DurationsMs + "\n\n"+
                    JsonStyle(result.Json)
                    );
                //richTextBox2.AppendText(JsonStyle(result.Json));

                ColorizeJson(richTextBox2);
                LoadJsonToTree(result.Json);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message,"Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                ResetProgress();
                UpdateProgres(30, "Migration des trajets...");

                UpdateProgres(100, "Migrations terminées");

                //string json = trajetService.MigrationTrajetToRedis();

                MigrationResult result = trajetService.MigrationTrajetToRedis();

                MessageBox.Show( "Migration des Trajets terminée", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MessageBox.Show(
                   "Migration terminée\n" +
                   "Table :" + result.Table + "\n" +
                   "Lignes :" + result.Count + "\n" +
                   "Temps :" + result.DurationsMs + " ms",
                   "Succès",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information
               );

                richTextBox2.Clear();
                richTextBox2.AppendText(
                    "====" + result.Table + "====\n" +
                    "Lignes : " + result.Count + "\n" +
                    "Temps : " + result.DurationsMs + "\n\n" +
                    JsonStyle(result.Json)
                    );


                ColorizeJson(richTextBox2);
                LoadJsonToTree(result.Json);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ResetProgress();
            UpdateProgres(30, "Migration des Voyages...");

            UpdateProgres(100, "Migrations terminées");

            //string json = voyageService.MigrationVoyageToRedis();
            MigrationResult result = voyageService.MigrationVoyageToRedis();

            MessageBox.Show("Migration des Voyages terminée", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);


            MessageBox.Show(
               "Migration terminée\n" +
               "Table :" + result.Table + "\n" +
               "Lignes :" + result.Count + "\n" +
               "Temps :" + result.DurationsMs + " ms",
               "Succès",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information
           );

            richTextBox2.Clear();
            richTextBox2.AppendText(
                "====" + result.Table + "====\n" +
                "Lignes : " + result.Count + "\n" +
                "Temps : " + result.DurationsMs + "\n\n" +
                JsonStyle(result.Json)
                );


            ColorizeJson(richTextBox2);
            LoadJsonToTree(result.Json);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ResetProgress();
            UpdateProgres(30, "Migration des Reservations...");

            UpdateProgres(100, "Migrations terminées");

           // string json = reservationService.MigrationReservationToRedis();
            MigrationResult result = reservationService.MigrationReservationToRedis();

            MessageBox.Show("Migration des Reservations terminée", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);


            MessageBox.Show(
               "Migration terminée\n" +
               "Table :" + result.Table + "\n" +
               "Lignes :" + result.Count + "\n" +
               "Temps :" + result.DurationsMs + " ms",
               "Succès",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information
           );

            richTextBox2.Clear();
            richTextBox2.AppendText(
                "====" + result.Table + "====\n" +
                "Lignes : " + result.Count + "\n" +
                "Temps : " + result.DurationsMs + "\n\n" +
                JsonStyle(result.Json)
                );


            ColorizeJson(richTextBox2);
            LoadJsonToTree(result.Json);
        }

        private void MgrTout_Click(object sender, EventArgs e)
        {

        }
        private void btnMigrerTout_Click(object sender, EventArgs e)
        {
            if (!bgMigrations.IsBusy)
            {
                DisableMigrationButtons();

                progressMigration.Value = 0;
                lblProgress.Text = "Démarrage de la migration...";
                richTextBox2.Clear();

                bgMigrations.RunWorkerAsync();
            }
        }

        private void bgMigrations_DoWork_1(object sender, DoWorkEventArgs e)
        {
            Stopwatch total = Stopwatch.StartNew();

            total.Stop();
            lblProgress.Text = "Temps total : " + total.ElapsedMilliseconds + "ms";
        }
    }
}
