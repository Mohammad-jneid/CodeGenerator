
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabasesList));
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
            this.labelDatabase = new System.Windows.Forms.Label();
            this.labelProjectSettings = new System.Windows.Forms.Label();
            this.labelPath = new System.Windows.Forms.Label();
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
            //this.cbDataBasesList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //this.cbDataBasesList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDataBasesList.FormattingEnabled = true;
            this.cbDataBasesList.Location = new System.Drawing.Point(30, 75);
            this.cbDataBasesList.Margin = new System.Windows.Forms.Padding(4);
            this.cbDataBasesList.Name = "cbDataBasesList";
            this.cbDataBasesList.Size = new System.Drawing.Size(320, 31);
            this.cbDataBasesList.TabIndex = 2;
            this.cbDataBasesList.SelectedIndexChanged += new System.EventHandler(this.cbDataBasesList_SelectedIndexChanged);
            // 
            // mtbProjectPath
            // 
            this.mtbProjectPath.BackColor = System.Drawing.Color.White;
            this.mtbProjectPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //this.mtbProjectPath.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbProjectPath.Location = new System.Drawing.Point(30, 240);
            this.mtbProjectPath.Margin = new System.Windows.Forms.Padding(4);
            this.mtbProjectPath.Name = "mtbProjectPath";
            this.mtbProjectPath.Size = new System.Drawing.Size(320, 30);
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
            //this.mtbProjectName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbProjectName.Location = new System.Drawing.Point(180, 170);
            this.mtbProjectName.Margin = new System.Windows.Forms.Padding(4);
            this.mtbProjectName.Name = "mtbProjectName";
            this.mtbProjectName.Size = new System.Drawing.Size(230, 30);
            this.mtbProjectName.TabIndex = 5;
            this.mtbProjectName.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtbProjectName_MaskInputRejected);
            // 
            // l
            // 
            this.l.AutoSize = true;
            //this.l.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.l.Location = new System.Drawing.Point(26, 173);
            this.l.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(146, 23);
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
            // 
            // panelSettings
            // 
            this.panelSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSettings.BackColor = System.Drawing.Color.White;
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
            // 
            // labelDatabase
            // 
            this.labelDatabase.AutoSize = true;
            this.labelDatabase.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDatabase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.labelDatabase.Location = new System.Drawing.Point(25, 25);
            this.labelDatabase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDatabase.Name = "labelDatabase";
            this.labelDatabase.Size = new System.Drawing.Size(183, 28);
            this.labelDatabase.TabIndex = 7;
            this.labelDatabase.Text = "Database Selection";
            // 
            // labelProjectSettings
            // 
            this.labelProjectSettings.AutoSize = true;
            this.labelProjectSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProjectSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.labelProjectSettings.Location = new System.Drawing.Point(25, 125);
            this.labelProjectSettings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProjectSettings.Name = "labelProjectSettings";
            this.labelProjectSettings.Size = new System.Drawing.Size(157, 28);
            this.labelProjectSettings.TabIndex = 8;
            this.labelProjectSettings.Text = "Project Settings";
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            //this.labelPath.Font = new System.Drawing.Font( 10F, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.labelPath.Location = new System.Drawing.Point(26, 213);
            this.labelPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(119, 23);
            this.labelPath.TabIndex = 9;
            this.labelPath.Text = "Project Path:";
            // 
            // DatabasesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(832, 503);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
    }
}

//namespace GenerateCode
//{
//    partial class DatabasesList
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.lbCreateBusinessLayer = new System.Windows.Forms.Button();
//            this.btnCreateDataLayer = new System.Windows.Forms.Button();
//            this.cbDataBasesList = new System.Windows.Forms.ComboBox();
//            this.mtbProjectPath = new System.Windows.Forms.MaskedTextBox();
//            this.btBrows = new System.Windows.Forms.Button();
//            this.mtbProjectName = new System.Windows.Forms.MaskedTextBox();
//            this.l = new System.Windows.Forms.Label();
//            this.SuspendLayout();
//            // 
//            // lbCreateBusinessLayer
//            // 
//            this.lbCreateBusinessLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.lbCreateBusinessLayer.Location = new System.Drawing.Point(484, 70);
//            this.lbCreateBusinessLayer.Name = "lbCreateBusinessLayer";
//            this.lbCreateBusinessLayer.Size = new System.Drawing.Size(254, 58);
//            this.lbCreateBusinessLayer.TabIndex = 0;
//            this.lbCreateBusinessLayer.Text = "Create Businesss layer";
//            this.lbCreateBusinessLayer.UseVisualStyleBackColor = true;
//            this.lbCreateBusinessLayer.Click += new System.EventHandler(this.lbCreateBusinessLayer_Click);
//            // 
//            // btnCreateDataLayer
//            // 
//            this.btnCreateDataLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btnCreateDataLayer.Location = new System.Drawing.Point(484, 169);
//            this.btnCreateDataLayer.Name = "btnCreateDataLayer";
//            this.btnCreateDataLayer.Size = new System.Drawing.Size(254, 58);
//            this.btnCreateDataLayer.TabIndex = 1;
//            this.btnCreateDataLayer.Text = "button2";
//            this.btnCreateDataLayer.UseVisualStyleBackColor = true;
//            this.btnCreateDataLayer.Click += new System.EventHandler(this.btnCreateDataLayer_Click);
//            // 
//            // cbDataBasesList
//            // 
//            this.cbDataBasesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.cbDataBasesList.FormattingEnabled = true;
//            this.cbDataBasesList.Location = new System.Drawing.Point(92, 88);
//            this.cbDataBasesList.Name = "cbDataBasesList";
//            this.cbDataBasesList.Size = new System.Drawing.Size(279, 24);
//            this.cbDataBasesList.TabIndex = 2;
//            this.cbDataBasesList.SelectedIndexChanged += new System.EventHandler(this.cbDataBasesList_SelectedIndexChanged);
//            // 
//            // mtbProjectPath
//            // 
//            this.mtbProjectPath.Location = new System.Drawing.Point(48, 320);
//            this.mtbProjectPath.Name = "mtbProjectPath";
//            this.mtbProjectPath.Size = new System.Drawing.Size(341, 22);
//            this.mtbProjectPath.TabIndex = 3;
//            // 
//            // btBrows
//            // 
//            this.btBrows.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btBrows.Location = new System.Drawing.Point(412, 315);
//            this.btBrows.Name = "btBrows";
//            this.btBrows.Size = new System.Drawing.Size(43, 31);
//            this.btBrows.TabIndex = 4;
//            this.btBrows.Text = "...";
//            this.btBrows.UseVisualStyleBackColor = true;
//            this.btBrows.Click += new System.EventHandler(this.btnBrowsPath_Click);
//            // 
//            // mtbProjectName
//            // 
//            this.mtbProjectName.Location = new System.Drawing.Point(183, 281);
//            this.mtbProjectName.Name = "mtbProjectName";
//            this.mtbProjectName.Size = new System.Drawing.Size(121, 22);
//            this.mtbProjectName.TabIndex = 5;
//            this.mtbProjectName.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtbProjectName_MaskInputRejected);
//            // 
//            // l
//            // 
//            this.l.AutoSize = true;
//            this.l.Location = new System.Drawing.Point(54, 281);
//            this.l.Name = "l";
//            this.l.Size = new System.Drawing.Size(98, 16);
//            this.l.TabIndex = 6;
//            this.l.Text = "Project Name : ";
//            // 
//            // DatabasesList
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(800, 450);
//            this.Controls.Add(this.l);
//            this.Controls.Add(this.mtbProjectName);
//            this.Controls.Add(this.btBrows);
//            this.Controls.Add(this.mtbProjectPath);
//            this.Controls.Add(this.cbDataBasesList);
//            this.Controls.Add(this.btnCreateDataLayer);
//            this.Controls.Add(this.lbCreateBusinessLayer);
//            this.Name = "DatabasesList";
//            this.Text = "Form1";
//            this.Load += new System.EventHandler(this.DatabasesList_Load);
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private System.Windows.Forms.Button lbCreateBusinessLayer;
//        private System.Windows.Forms.Button btnCreateDataLayer;
//        private System.Windows.Forms.ComboBox cbDataBasesList;
//        private System.Windows.Forms.MaskedTextBox mtbProjectPath;
//        private System.Windows.Forms.Button btBrows;
//        private System.Windows.Forms.MaskedTextBox mtbProjectName;
//        private System.Windows.Forms.Label l;
//    }
//}

