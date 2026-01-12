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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using OracleToRedisImport.Services;

namespace OracleToRedisImport.FormsWindow
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            //serviceRedis = new JsonToRedis();
           
        }

        private string currentRedisKey = "";

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
            ColorizeJson(rtbJson);

            string formattedJson = JsonStyle(json);
            LoadJsonToTree(formattedJson);

            currentRedisKey = "utilisateur:json";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "SELECT id_trajet, depart, destination, date_depart, prix , id_voiture FROM trajet";

            string json = OracleJsonProcess.GetJsonFormOracle(sql);
            rtbJson.Text = JsonStyle(json);
            ColorizeJson(rtbJson);

            currentRedisKey = "trajet:json";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "SELECT id_voyage, id_trajet, id_voiture, date_depart, heure_depart, places_restantes, places_totales, etat_voyage FROM voyage";

            string json = OracleJsonProcess.GetJsonFormOracle(sql);
            rtbJson.Text = JsonStyle(json);
            ColorizeJson(rtbJson);

            currentRedisKey = "voyage:json";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql = "SELECT id_reservation, id_client, id_voyage, date_reservation, nb_places, etat_reservation FROM reservation";

            string json = OracleJsonProcess.GetJsonFormOracle(sql);
            rtbJson.Text = JsonStyle(json);
            ColorizeJson(rtbJson);

            currentRedisKey = "reservation:json";
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
            if (string.IsNullOrWhiteSpace(rtbJson2.Text))
            {
                MessageBox.Show("Aucun JSON à Importer", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                    
            string redisKey = currentRedisKey; 
            // ex: "utilisateur:json"

            JsonToRedisService redisService = new JsonToRedisService("localhost:6379");

            redisService.SaveJson(redisKey, rtbJson2.Text);

            MessageBox.Show(
                "JSON importé avec succès dans Redis",
                "Succès",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnVoirCles_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbJson2.Text))
            {
                MessageBox.Show("Aucune Clé existante", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
