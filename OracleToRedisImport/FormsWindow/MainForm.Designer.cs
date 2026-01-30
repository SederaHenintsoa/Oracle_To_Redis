namespace OracleToRedisImport.FormsWindow
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panelTop = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnExporteJson = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rtbJson = new System.Windows.Forms.RichTextBox();
            this.treeJson = new System.Windows.Forms.TreeView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.rtbRedis = new System.Windows.Forms.RichTextBox();
            this.btnVoirCles = new System.Windows.Forms.Button();
            this.btnImportCles = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lblProgress = new System.Windows.Forms.Label();
            this.progressMigration = new System.Windows.Forms.ProgressBar();
            this.MgrTout = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.bgMigrations = new System.ComponentModel.BackgroundWorker();
            this.btnDex = new System.Windows.Forms.Button();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Navy;
            this.textBox1.Location = new System.Drawing.Point(0, 685);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.Size = new System.Drawing.Size(1146, 27);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "MIGRATION ORACLE VERS REDIS";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Controls.Add(this.tabPage4);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.ItemSize = new System.Drawing.Size(50, 25);
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Multiline = true;
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1146, 685);
            this.tabMain.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.AliceBlue;
            this.tabPage1.BackgroundImage = global::OracleToRedisImport.Properties.Resources._76f3fd4fac046302a4cc208e053f258a11;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabPage1.Size = new System.Drawing.Size(1138, 652);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Accueil";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(306, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(522, 81);
            this.label2.TabIndex = 1;
            this.label2.Text = "Oracle Vers Redis";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MintCream;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(228, 24);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(667, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "BIENVENUE DANS L\'APPLICATION DE MIGRATION ";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.AliceBlue;
            this.tabPage2.Controls.Add(this.panelTop);
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1138, 652);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Oracle -> JSON";
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.button2);
            this.panelTop.Controls.Add(this.button3);
            this.panelTop.Controls.Add(this.btnExporteJson);
            this.panelTop.Controls.Add(this.button4);
            this.panelTop.Controls.Add(this.textBox4);
            this.panelTop.Controls.Add(this.button5);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1132, 364);
            this.panelTop.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(468, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(168, 37);
            this.button2.TabIndex = 0;
            this.button2.Text = "Utilisateurs";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button3.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(468, 152);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(168, 38);
            this.button3.TabIndex = 1;
            this.button3.Text = "Trajets";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnExporteJson
            // 
            this.btnExporteJson.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExporteJson.BackColor = System.Drawing.Color.SeaGreen;
            this.btnExporteJson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExporteJson.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExporteJson.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExporteJson.Location = new System.Drawing.Point(921, 269);
            this.btnExporteJson.Name = "btnExporteJson";
            this.btnExporteJson.Size = new System.Drawing.Size(133, 57);
            this.btnExporteJson.TabIndex = 6;
            this.btnExporteJson.Text = "Exporter Json";
            this.btnExporteJson.UseVisualStyleBackColor = false;
            this.btnExporteJson.Click += new System.EventHandler(this.btnExporteJson_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button4.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(468, 221);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(168, 35);
            this.button4.TabIndex = 2;
            this.button4.Text = "Voyages";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.SystemColors.InfoText;
            this.textBox4.Location = new System.Drawing.Point(372, 27);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(379, 24);
            this.textBox4.TabIndex = 5;
            this.textBox4.Text = "Séléctionner les données à Extraire :";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button5.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Location = new System.Drawing.Point(468, 289);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(168, 37);
            this.button5.TabIndex = 3;
            this.button5.Text = "Reservations";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(3, 431);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.rtbJson);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeJson);
            this.splitContainer1.Size = new System.Drawing.Size(1132, 218);
            this.splitContainer1.SplitterDistance = 557;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 9;
            // 
            // rtbJson
            // 
            this.rtbJson.BackColor = System.Drawing.Color.AliceBlue;
            this.rtbJson.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbJson.Font = new System.Drawing.Font("Consolas", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbJson.Location = new System.Drawing.Point(0, 0);
            this.rtbJson.Name = "rtbJson";
            this.rtbJson.ReadOnly = true;
            this.rtbJson.Size = new System.Drawing.Size(557, 218);
            this.rtbJson.TabIndex = 7;
            this.rtbJson.Text = "";
            this.rtbJson.WordWrap = false;
            // 
            // treeJson
            // 
            this.treeJson.BackColor = System.Drawing.Color.AliceBlue;
            this.treeJson.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeJson.HideSelection = false;
            this.treeJson.Location = new System.Drawing.Point(0, 0);
            this.treeJson.Name = "treeJson";
            this.treeJson.Size = new System.Drawing.Size(569, 218);
            this.treeJson.TabIndex = 8;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.AliceBlue;
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Controls.Add(this.richTextBox1);
            this.tabPage3.Controls.Add(this.rtbRedis);
            this.tabPage3.Controls.Add(this.btnVoirCles);
            this.tabPage3.Controls.Add(this.btnImportCles);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1138, 652);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "JSON -> Redis";
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.textBox2.Location = new System.Drawing.Point(3, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1132, 38);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "IMPORTER TOUTES LES DONNEES D\'ORACLE VERS REDIS ET VOIR LES CLES DANS REDIS";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(315, 274);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(528, 154);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // rtbRedis
            // 
            this.rtbRedis.Location = new System.Drawing.Point(315, 434);
            this.rtbRedis.Name = "rtbRedis";
            this.rtbRedis.Size = new System.Drawing.Size(528, 150);
            this.rtbRedis.TabIndex = 3;
            this.rtbRedis.Text = "";
            // 
            // btnVoirCles
            // 
            this.btnVoirCles.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnVoirCles.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoirCles.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnVoirCles.Location = new System.Drawing.Point(698, 141);
            this.btnVoirCles.Name = "btnVoirCles";
            this.btnVoirCles.Size = new System.Drawing.Size(285, 41);
            this.btnVoirCles.TabIndex = 1;
            this.btnVoirCles.Text = "Voir les Clés dans Redis";
            this.btnVoirCles.UseVisualStyleBackColor = false;
            this.btnVoirCles.Click += new System.EventHandler(this.btnVoirCles_Click_1);
            // 
            // btnImportCles
            // 
            this.btnImportCles.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnImportCles.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportCles.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnImportCles.Location = new System.Drawing.Point(151, 141);
            this.btnImportCles.Name = "btnImportCles";
            this.btnImportCles.Size = new System.Drawing.Size(294, 41);
            this.btnImportCles.TabIndex = 0;
            this.btnImportCles.Text = "Importer Vers Redis";
            this.btnImportCles.UseVisualStyleBackColor = false;
            this.btnImportCles.Click += new System.EventHandler(this.btnImportCles_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.AliceBlue;
            this.tabPage4.Controls.Add(this.lblProgress);
            this.tabPage4.Controls.Add(this.progressMigration);
            this.tabPage4.Controls.Add(this.MgrTout);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.richTextBox2);
            this.tabPage4.Controls.Add(this.button11);
            this.tabPage4.Controls.Add(this.button10);
            this.tabPage4.Controls.Add(this.button9);
            this.tabPage4.Controls.Add(this.button8);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1138, 652);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Migration Directe";
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(461, 579);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(98, 21);
            this.lblProgress.TabIndex = 9;
            this.lblProgress.Text = "En attente...";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // progressMigration
            // 
            this.progressMigration.BackColor = System.Drawing.Color.Azure;
            this.progressMigration.ForeColor = System.Drawing.Color.SeaGreen;
            this.progressMigration.Location = new System.Drawing.Point(281, 613);
            this.progressMigration.Name = "progressMigration";
            this.progressMigration.Size = new System.Drawing.Size(564, 16);
            this.progressMigration.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressMigration.TabIndex = 8;
            // 
            // MgrTout
            // 
            this.MgrTout.BackColor = System.Drawing.Color.LightSeaGreen;
            this.MgrTout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MgrTout.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MgrTout.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.MgrTout.Location = new System.Drawing.Point(456, 499);
            this.MgrTout.Name = "MgrTout";
            this.MgrTout.Size = new System.Drawing.Size(248, 47);
            this.MgrTout.TabIndex = 7;
            this.MgrTout.Text = "Migrer tout";
            this.MgrTout.UseVisualStyleBackColor = false;
            this.MgrTout.Click += new System.EventHandler(this.btnMigrerTout_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightCyan;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(473, 423);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5);
            this.label4.Size = new System.Drawing.Size(221, 38);
            this.label4.TabIndex = 6;
            this.label4.Text = "OU MIGRER TOUT ICI";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightCyan;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5);
            this.label3.Size = new System.Drawing.Size(1132, 42);
            this.label3.TabIndex = 5;
            this.label3.Text = "CLIQUEZ SUR LA MIGRATION SOUHAITER";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox2.Location = new System.Drawing.Point(776, 88);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(319, 458);
            this.richTextBox2.TabIndex = 4;
            this.richTextBox2.Text = "";
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button11.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button11.Location = new System.Drawing.Point(447, 345);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(272, 41);
            this.button11.TabIndex = 3;
            this.button11.Text = "Migrer Resérvations";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button10.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button10.Location = new System.Drawing.Point(447, 255);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(272, 42);
            this.button10.TabIndex = 2;
            this.button10.Text = "Migrer Voyages";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button9.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button9.Location = new System.Drawing.Point(447, 171);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(272, 46);
            this.button9.TabIndex = 1;
            this.button9.Text = "Migrer Trajets";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button8.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button8.Location = new System.Drawing.Point(447, 88);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(272, 42);
            this.button8.TabIndex = 0;
            this.button8.Text = "Migrer Utilisateurs";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // bgMigrations
            // 
            this.bgMigrations.WorkerReportsProgress = true;
            this.bgMigrations.WorkerSupportsCancellation = true;
            this.bgMigrations.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgMigrations_DoWork_1);
            // 
            // btnDex
            // 
            this.btnDex.BackColor = System.Drawing.Color.Crimson;
            this.btnDex.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDex.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDex.ForeColor = System.Drawing.Color.White;
            this.btnDex.Location = new System.Drawing.Point(1033, 685);
            this.btnDex.Name = "btnDex";
            this.btnDex.Size = new System.Drawing.Size(106, 27);
            this.btnDex.TabIndex = 10;
            this.btnDex.Text = "Déconnexion";
            this.btnDex.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1146, 712);
            this.Controls.Add(this.btnDex);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.textBox1);
            this.DoubleBuffered = true;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MigBD";
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnVoirCles;
        private System.Windows.Forms.Button btnImportCles;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.RichTextBox rtbRedis;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnExporteJson;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TreeView treeJson;
        private System.Windows.Forms.RichTextBox rtbJson;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button MgrTout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressMigration;
        private System.Windows.Forms.Label lblProgress;
        private System.ComponentModel.BackgroundWorker bgMigrations;
        private System.Windows.Forms.Button btnDex;
        private System.Windows.Forms.TextBox textBox2;
    }
}