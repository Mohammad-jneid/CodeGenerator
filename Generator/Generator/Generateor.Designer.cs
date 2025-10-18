using System.Windows.Forms;

namespace GenerateCode
{
    partial class DatabasesList 
    {
        //private System.ComponentModel.IContainer components = null;
        //private Button lbCreateBusinessLayer;
        //private Button btnCreateDataLayer;
        //private ComboBox cbDataBasesList;
        //private MaskedTextBox mtbProjectPath;
        //private Button btBrows;
        //private MaskedTextBox mtbProjectName;
        //private Label lblProjectName;
        //private Panel panelMain;
        //private Panel panelActions;
        //private Panel panelSettings;
        //private ComboBox cbTablesList;
        //private Button btnCheckForFindBy;
        //private Label labelPath;
        //private Label labelProjectSettings;
        //private Label labelDatabase;
        //private ProgressBar progressBar;
        //private Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            //if (disposing && (components != null))
            //{
            //    components.Dispose();
            //}
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lbCreateBusinessLayer = new System.Windows.Forms.Button();
            this.btnCreateDataLayer = new System.Windows.Forms.Button();
            this.cbDataBasesList = new System.Windows.Forms.ComboBox();
            this.mtbProjectPath = new System.Windows.Forms.MaskedTextBox();
            this.btBrows = new System.Windows.Forms.Button();
            this.mtbProjectName = new System.Windows.Forms.MaskedTextBox();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelActions = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.cbTablesList = new System.Windows.Forms.ComboBox();
            this.btnCheckForFindBy = new System.Windows.Forms.Button();
            this.labelPath = new System.Windows.Forms.Label();
            this.labelProjectSettings = new System.Windows.Forms.Label();
            this.labelDatabase = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCreateBusinessLayer
            // 
            this.lbCreateBusinessLayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lbCreateBusinessLayer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lbCreateBusinessLayer.FlatAppearance.BorderSize = 0;
            this.lbCreateBusinessLayer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(179)))));
            this.lbCreateBusinessLayer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(217)))));
            this.lbCreateBusinessLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbCreateBusinessLayer.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCreateBusinessLayer.ForeColor = System.Drawing.Color.White;
            this.lbCreateBusinessLayer.Location = new System.Drawing.Point(25, 30);
            this.lbCreateBusinessLayer.Margin = new System.Windows.Forms.Padding(4);
            this.lbCreateBusinessLayer.Name = "lbCreateBusinessLayer";
            this.lbCreateBusinessLayer.Size = new System.Drawing.Size(280, 60);
            this.lbCreateBusinessLayer.TabIndex = 0;
            this.lbCreateBusinessLayer.Text = "Generate Business Layer";
            this.lbCreateBusinessLayer.UseVisualStyleBackColor = false;
            this.lbCreateBusinessLayer.Click += new System.EventHandler(this.lbCreateBusinessLayer_Click);
            // 
            // btnCreateDataLayer
            // 
            this.btnCreateDataLayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnCreateDataLayer.Enabled = false;
            this.btnCreateDataLayer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnCreateDataLayer.FlatAppearance.BorderSize = 0;
            this.btnCreateDataLayer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(136)))), ((int)(((byte)(56)))));
            this.btnCreateDataLayer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(145)))), ((int)(((byte)(60)))));
            this.btnCreateDataLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateDataLayer.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateDataLayer.ForeColor = System.Drawing.Color.White;
            this.btnCreateDataLayer.Location = new System.Drawing.Point(25, 110);
            this.btnCreateDataLayer.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateDataLayer.Name = "btnCreateDataLayer";
            this.btnCreateDataLayer.Size = new System.Drawing.Size(280, 60);
            this.btnCreateDataLayer.TabIndex = 1;
            this.btnCreateDataLayer.Text = "Generate Data Layer";
            this.btnCreateDataLayer.UseVisualStyleBackColor = false;
            this.btnCreateDataLayer.Click += new System.EventHandler(this.btnCreateDataLayer_Click);
            // 
            // cbDataBasesList
            // 
            this.cbDataBasesList.BackColor = System.Drawing.Color.White;
            this.cbDataBasesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataBasesList.FormattingEnabled = true;
            this.cbDataBasesList.Location = new System.Drawing.Point(30, 75);
            this.cbDataBasesList.Margin = new System.Windows.Forms.Padding(4);
            this.cbDataBasesList.Name = "cbDataBasesList";
            this.cbDataBasesList.Size = new System.Drawing.Size(180, 24);
            this.cbDataBasesList.TabIndex = 2;
            this.cbDataBasesList.SelectedIndexChanged += new System.EventHandler(this.cbDataBasesList_SelectedIndexChanged);
            this.cbDataBasesList.TextChanged += new System.EventHandler(this.cbDataBasesList_SelectedIndexChanged);
            // 
            // mtbProjectPath
            // 
            this.mtbProjectPath.BackColor = System.Drawing.Color.White;
            this.mtbProjectPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtbProjectPath.Enabled = false;
            this.mtbProjectPath.Location = new System.Drawing.Point(30, 240);
            this.mtbProjectPath.Margin = new System.Windows.Forms.Padding(4);
            this.mtbProjectPath.Name = "mtbProjectPath";
            this.mtbProjectPath.Size = new System.Drawing.Size(320, 22);
            this.mtbProjectPath.TabIndex = 3;
            this.mtbProjectPath.TextChanged += new System.EventHandler(this.mtbProjectPath_TextChanged);
            // 
            // btBrows
            // 
            this.btBrows.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btBrows.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btBrows.FlatAppearance.BorderSize = 0;
            this.btBrows.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(91)))), ((int)(((byte)(98)))));
            this.btBrows.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(98)))), ((int)(((byte)(104)))));
            this.btBrows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBrows.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBrows.ForeColor = System.Drawing.Color.White;
            this.btBrows.Location = new System.Drawing.Point(360, 240);
            this.btBrows.Margin = new System.Windows.Forms.Padding(4);
            this.btBrows.Name = "btBrows";
            this.btBrows.Size = new System.Drawing.Size(50, 30);
            this.btBrows.TabIndex = 4;
            this.btBrows.Text = "...";
            this.btBrows.UseVisualStyleBackColor = false;
            this.btBrows.Click += new System.EventHandler(this.btnBrowsPath_Click);
            // 
            // mtbProjectName
            // 
            this.mtbProjectName.BackColor = System.Drawing.Color.White;
            this.mtbProjectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtbProjectName.Location = new System.Drawing.Point(180, 170);
            this.mtbProjectName.Margin = new System.Windows.Forms.Padding(4);
            this.mtbProjectName.Name = "mtbProjectName";
            this.mtbProjectName.Size = new System.Drawing.Size(230, 22);
            this.mtbProjectName.TabIndex = 5;
            this.mtbProjectName.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtbProjectName_MaskInputRejected);
            this.mtbProjectName.Click += new System.EventHandler(this.N_Click);
            this.mtbProjectName.TextChanged += new System.EventHandler(this.mtbProjectName_TextChanged);
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.lblProjectName.Location = new System.Drawing.Point(26, 173);
            this.lblProjectName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(92, 16);
            this.lblProjectName.TabIndex = 6;
            this.lblProjectName.Text = "Project Name:";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.panelActions);
            this.panelMain.Controls.Add(this.panelSettings);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(832, 503);
            this.panelMain.TabIndex = 7;
            // 
            // panelActions
            // 
            this.panelActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelActions.Controls.Add(this.progressBar);
            this.panelActions.Controls.Add(this.lblStatus);
            this.panelActions.Controls.Add(this.btnCreateDataLayer);
            this.panelActions.Controls.Add(this.lbCreateBusinessLayer);
            this.panelActions.Location = new System.Drawing.Point(470, 25);
            this.panelActions.Margin = new System.Windows.Forms.Padding(4);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(330, 450);
            this.panelActions.TabIndex = 9;
            this.panelActions.Paint += new System.Windows.Forms.PaintEventHandler(this.panelActions_Paint);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(25, 350);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(280, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 3;
            this.progressBar.Visible = false;
            this.progressBar.Click += new System.EventHandler(this.N_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblStatus.Location = new System.Drawing.Point(25, 380);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(280, 50);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Ready to generate code...";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelSettings
            // 
            this.panelSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSettings.BackColor = System.Drawing.Color.White;
            this.panelSettings.Controls.Add(this.cbTablesList);
            this.panelSettings.Controls.Add(this.btnCheckForFindBy);
            this.panelSettings.Controls.Add(this.labelPath);
            this.panelSettings.Controls.Add(this.labelProjectSettings);
            this.panelSettings.Controls.Add(this.labelDatabase);
            this.panelSettings.Controls.Add(this.cbDataBasesList);
            this.panelSettings.Controls.Add(this.lblProjectName);
            this.panelSettings.Controls.Add(this.mtbProjectPath);
            this.panelSettings.Controls.Add(this.mtbProjectName);
            this.panelSettings.Controls.Add(this.btBrows);
            this.panelSettings.Location = new System.Drawing.Point(25, 25);
            this.panelSettings.Margin = new System.Windows.Forms.Padding(4);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(430, 450);
            this.panelSettings.TabIndex = 8;
            // 
            // cbTablesList
            // 
            this.cbTablesList.BackColor = System.Drawing.Color.White;
            this.cbTablesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTablesList.FormattingEnabled = true;
            this.cbTablesList.Location = new System.Drawing.Point(220, 75);
            this.cbTablesList.Margin = new System.Windows.Forms.Padding(4);
            this.cbTablesList.Name = "cbTablesList";
            this.cbTablesList.Size = new System.Drawing.Size(190, 24);
            this.cbTablesList.TabIndex = 11;
            this.cbTablesList.TextChanged += new System.EventHandler(this.cbTablesList_SelectedIndexChanged);
            // 
            // btnCheckForFindBy
            // 
            this.btnCheckForFindBy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnCheckForFindBy.Enabled = false;
            this.btnCheckForFindBy.FlatAppearance.BorderSize = 0;
            this.btnCheckForFindBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckForFindBy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckForFindBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.btnCheckForFindBy.Location = new System.Drawing.Point(220, 110);
            this.btnCheckForFindBy.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheckForFindBy.Name = "btnCheckForFindBy";
            this.btnCheckForFindBy.Size = new System.Drawing.Size(190, 35);
            this.btnCheckForFindBy.TabIndex = 10;
            this.btnCheckForFindBy.Text = "Configure FindBy Methods";
            this.btnCheckForFindBy.UseVisualStyleBackColor = false;
            this.btnCheckForFindBy.Click += new System.EventHandler(this.btnCheckForFindBy_Click);
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.labelPath.Location = new System.Drawing.Point(26, 213);
            this.labelPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(82, 16);
            this.labelPath.TabIndex = 9;
            this.labelPath.Text = "Project Path:";
            // 
            // labelProjectSettings
            // 
            this.labelProjectSettings.AutoSize = true;
            this.labelProjectSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProjectSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.labelProjectSettings.Location = new System.Drawing.Point(25, 125);
            this.labelProjectSettings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProjectSettings.Name = "labelProjectSettings";
            this.labelProjectSettings.Size = new System.Drawing.Size(162, 28);
            this.labelProjectSettings.TabIndex = 8;
            this.labelProjectSettings.Text = "Project Settings";
            // 
            // labelDatabase
            // 
            this.labelDatabase.AutoSize = true;
            this.labelDatabase.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDatabase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.labelDatabase.Location = new System.Drawing.Point(25, 25);
            this.labelDatabase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDatabase.Name = "labelDatabase";
            this.labelDatabase.Size = new System.Drawing.Size(193, 28);
            this.labelDatabase.TabIndex = 7;
            this.labelDatabase.Text = "Database Selection";
            // 
            // DatabasesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(832, 503);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(850, 550);
            this.Name = "DatabasesList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code Generator - Database to C# Classes";
            this.Load += new System.EventHandler(this.DatabasesList_Load);
            this.panelMain.ResumeLayout(false);
            this.panelActions.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.ResumeLayout(false);

        }

//#endregion

        private System.Windows.Forms.Button lbCreateBusinessLayer;
        private System.Windows.Forms.Button btnCreateDataLayer;
        private System.Windows.Forms.ComboBox cbDataBasesList;
        private System.Windows.Forms.MaskedTextBox mtbProjectPath;
        private System.Windows.Forms.Button btBrows;
        private System.Windows.Forms.MaskedTextBox mtbProjectName;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label labelDatabase;
        private System.Windows.Forms.Label labelProjectSettings;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Button btnCheckForFindBy;
        private System.Windows.Forms.ComboBox cbTablesList;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
    }
}

/*


namespace GenerateCode
{
    partial class DatabasesList
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
            this.lbCreateBusinessLayer = new System.Windows.Forms.Button();
            this.btnCreateDataLayer = new System.Windows.Forms.Button();
            this.cbDataBasesList = new System.Windows.Forms.ComboBox();
            this.mtbProjectPath = new System.Windows.Forms.MaskedTextBox();
            this.btBrows = new System.Windows.Forms.Button();
            this.mtbProjectName = new System.Windows.Forms.MaskedTextBox();
            this.l = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelActions = new System.Windows.Forms.Panel();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.cbTablesList = new System.Windows.Forms.ComboBox();
            this.btnCheckForFindBy = new System.Windows.Forms.Button();
            this.labelPath = new System.Windows.Forms.Label();
            this.labelProjectSettings = new System.Windows.Forms.Label();
            this.labelDatabase = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCreateBusinessLayer
            // 
            this.lbCreateBusinessLayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lbCreateBusinessLayer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lbCreateBusinessLayer.FlatAppearance.BorderSize = 0;
            this.lbCreateBusinessLayer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(179)))));
            this.lbCreateBusinessLayer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(217)))));
            this.lbCreateBusinessLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbCreateBusinessLayer.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCreateBusinessLayer.ForeColor = System.Drawing.Color.White;
            this.lbCreateBusinessLayer.Location = new System.Drawing.Point(25, 30);
            this.lbCreateBusinessLayer.Margin = new System.Windows.Forms.Padding(4);
            this.lbCreateBusinessLayer.Name = "lbCreateBusinessLayer";
            this.lbCreateBusinessLayer.Size = new System.Drawing.Size(280, 60);
            this.lbCreateBusinessLayer.TabIndex = 0;
            this.lbCreateBusinessLayer.Text = "Create Business Layer";
            this.lbCreateBusinessLayer.UseVisualStyleBackColor = false;
            this.lbCreateBusinessLayer.Click += new System.EventHandler(this.lbCreateBusinessLayer_Click);
            // 
            // btnCreateDataLayer
            // 
            this.btnCreateDataLayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCreateDataLayer.Enabled = false;
            this.btnCreateDataLayer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCreateDataLayer.FlatAppearance.BorderSize = 0;
            this.btnCreateDataLayer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(91)))), ((int)(((byte)(98)))));
            this.btnCreateDataLayer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(98)))), ((int)(((byte)(104)))));
            this.btnCreateDataLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateDataLayer.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateDataLayer.ForeColor = System.Drawing.Color.White;
            this.btnCreateDataLayer.Location = new System.Drawing.Point(25, 110);
            this.btnCreateDataLayer.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateDataLayer.Name = "btnCreateDataLayer";
            this.btnCreateDataLayer.Size = new System.Drawing.Size(280, 60);
            this.btnCreateDataLayer.TabIndex = 1;
            this.btnCreateDataLayer.Text = "Create Data Layer";
            this.btnCreateDataLayer.UseVisualStyleBackColor = false;
            this.btnCreateDataLayer.Click += new System.EventHandler(this.btnCreateDataLayer_Click);
            // 
            // cbDataBasesList
            // 
            this.cbDataBasesList.BackColor = System.Drawing.Color.White;
            this.cbDataBasesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataBasesList.FormattingEnabled = true;
            this.cbDataBasesList.Location = new System.Drawing.Point(30, 75);
            this.cbDataBasesList.Margin = new System.Windows.Forms.Padding(4);
            this.cbDataBasesList.Name = "cbDataBasesList";
            this.cbDataBasesList.Size = new System.Drawing.Size(165, 24);
            this.cbDataBasesList.TabIndex = 2;
            this.cbDataBasesList.SelectedIndexChanged += new System.EventHandler(this.cbDataBasesList_SelectedIndexChanged);
            // 
            // mtbProjectPath
            // 
            this.mtbProjectPath.BackColor = System.Drawing.Color.White;
            this.mtbProjectPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtbProjectPath.Location = new System.Drawing.Point(30, 240);
            this.mtbProjectPath.Margin = new System.Windows.Forms.Padding(4);
            this.mtbProjectPath.Name = "mtbProjectPath";
            this.mtbProjectPath.Size = new System.Drawing.Size(320, 22);
            this.mtbProjectPath.TabIndex = 3;
            // 
            // btBrows
            // 
            this.btBrows.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btBrows.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btBrows.FlatAppearance.BorderSize = 0;
            this.btBrows.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(91)))), ((int)(((byte)(98)))));
            this.btBrows.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(98)))), ((int)(((byte)(104)))));
            this.btBrows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBrows.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBrows.ForeColor = System.Drawing.Color.White;
            this.btBrows.Location = new System.Drawing.Point(360, 240);
            this.btBrows.Margin = new System.Windows.Forms.Padding(4);
            this.btBrows.Name = "btBrows";
            this.btBrows.Size = new System.Drawing.Size(50, 30);
            this.btBrows.TabIndex = 4;
            this.btBrows.Text = "...";
            this.btBrows.UseVisualStyleBackColor = false;
            this.btBrows.Click += new System.EventHandler(this.btnBrowsPath_Click);
            // 
            // mtbProjectName
            // 
            this.mtbProjectName.BackColor = System.Drawing.Color.White;
            this.mtbProjectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtbProjectName.Location = new System.Drawing.Point(180, 170);
            this.mtbProjectName.Margin = new System.Windows.Forms.Padding(4);
            this.mtbProjectName.Name = "mtbProjectName";
            this.mtbProjectName.Size = new System.Drawing.Size(230, 22);
            this.mtbProjectName.TabIndex = 5;
            this.mtbProjectName.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtbProjectName_MaskInputRejected);
            // 
            // l
            // 
            this.l.AutoSize = true;
            this.l.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.l.Location = new System.Drawing.Point(26, 173);
            this.l.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(92, 16);
            this.l.TabIndex = 6;
            this.l.Text = "Project Name:";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.panelActions);
            this.panelMain.Controls.Add(this.panelSettings);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(832, 503);
            this.panelMain.TabIndex = 7;
            // 
            // panelActions
            // 
            this.panelActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelActions.Controls.Add(this.btnCreateDataLayer);
            this.panelActions.Controls.Add(this.lbCreateBusinessLayer);
            this.panelActions.Location = new System.Drawing.Point(470, 25);
            this.panelActions.Margin = new System.Windows.Forms.Padding(4);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(330, 450);
            this.panelActions.TabIndex = 9;
            this.panelActions.Paint += new System.Windows.Forms.PaintEventHandler(this.panelActions_Paint);
            // 
            // panelSettings
            // 
            this.panelSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSettings.BackColor = System.Drawing.Color.White;
            this.panelSettings.Controls.Add(this.cbTablesList);
            this.panelSettings.Controls.Add(this.btnCheckForFindBy);
            this.panelSettings.Controls.Add(this.labelPath);
            this.panelSettings.Controls.Add(this.labelProjectSettings);
            this.panelSettings.Controls.Add(this.labelDatabase);
            this.panelSettings.Controls.Add(this.cbDataBasesList);
            this.panelSettings.Controls.Add(this.l);
            this.panelSettings.Controls.Add(this.mtbProjectPath);
            this.panelSettings.Controls.Add(this.mtbProjectName);
            this.panelSettings.Controls.Add(this.btBrows);
            this.panelSettings.Location = new System.Drawing.Point(25, 25);
            this.panelSettings.Margin = new System.Windows.Forms.Padding(4);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(430, 450);
            this.panelSettings.TabIndex = 8;
            this.panelSettings.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSettings_Paint);
            // 
            // cbTablesList
            // 
            this.cbTablesList.BackColor = System.Drawing.Color.White;
            this.cbTablesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTablesList.FormattingEnabled = true;
            this.cbTablesList.Location = new System.Drawing.Point(215, 75);
            this.cbTablesList.Margin = new System.Windows.Forms.Padding(4);
            this.cbTablesList.Name = "cbTablesList";
            this.cbTablesList.Size = new System.Drawing.Size(165, 24);
            this.cbTablesList.TabIndex = 11;
            this.cbTablesList.SelectedIndexChanged += new System.EventHandler(this.cbTablesList_SelectedIndexChanged);
            // 
            // btnCheckForFindBy
            // 
            this.btnCheckForFindBy.Enabled = false;
            this.btnCheckForFindBy.Location = new System.Drawing.Point(290, 125);
            this.btnCheckForFindBy.Name = "btnCheckForFindBy";
            this.btnCheckForFindBy.Size = new System.Drawing.Size(99, 25);
            this.btnCheckForFindBy.TabIndex = 10;
            this.btnCheckForFindBy.Text = "button1";
            this.btnCheckForFindBy.UseVisualStyleBackColor = true;
            this.btnCheckForFindBy.Click += new System.EventHandler(this.btnCheckForFindBy_Click);
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.labelPath.Location = new System.Drawing.Point(26, 213);
            this.labelPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(82, 16);
            this.labelPath.TabIndex = 9;
            this.labelPath.Text = "Project Path:";
            // 
            // labelProjectSettings
            // 
            this.labelProjectSettings.AutoSize = true;
            this.labelProjectSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProjectSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.labelProjectSettings.Location = new System.Drawing.Point(25, 125);
            this.labelProjectSettings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProjectSettings.Name = "labelProjectSettings";
            this.labelProjectSettings.Size = new System.Drawing.Size(162, 28);
            this.labelProjectSettings.TabIndex = 8;
            this.labelProjectSettings.Text = "Project Settings";
            // 
            // labelDatabase
            // 
            this.labelDatabase.AutoSize = true;
            this.labelDatabase.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDatabase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.labelDatabase.Location = new System.Drawing.Point(25, 25);
            this.labelDatabase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDatabase.Name = "labelDatabase";
            this.labelDatabase.Size = new System.Drawing.Size(193, 28);
            this.labelDatabase.TabIndex = 7;
            this.labelDatabase.Text = "Database Selection";
            // 
            // DatabasesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(832, 503);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(850, 550);
            this.Name = "DatabasesList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code Generator";
            this.Load += new System.EventHandler(this.DatabasesList_Load);
            this.panelMain.ResumeLayout(false);
            this.panelActions.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button lbCreateBusinessLayer;
        private System.Windows.Forms.Button btnCreateDataLayer;
        private System.Windows.Forms.ComboBox cbDataBasesList;
        private System.Windows.Forms.MaskedTextBox mtbProjectPath;
        private System.Windows.Forms.Button btBrows;
        private System.Windows.Forms.MaskedTextBox mtbProjectName;
        private System.Windows.Forms.Label l;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label labelDatabase;
        private System.Windows.Forms.Label labelProjectSettings;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Button btnCheckForFindBy;
        private System.Windows.Forms.ComboBox cbTablesList;
    }
}

*/