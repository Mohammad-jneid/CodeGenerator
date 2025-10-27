using BusinessLayer;
using Generator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateCode
{
    public partial class DatabasesList : Form
    {
        private enum enClassType { DataAccess, Business };
        private enClassType _ClassType;
        private DataTable _DataTable;
        private static string _DataBaseName;
        private List<string> _Tables = new List<string>();
        private string _SelectedTable;

        public DatabasesList()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            // Set form icon and title
            this.Text = "Code Generator - Database to C# Classes";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void HandleProjectNameAndPath()
        {
            mtbProjectName.Text = "New Project";
            clsSettings.ProjectName = mtbProjectName.Text;

            mtbProjectPath.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            clsSettings.ProjectRootPath = mtbProjectPath.Text;
        }

        private void FillComboBoxWithDataBases()
        {
            try
            {
                DataTable dt = clsDataBaseBusiness.LoadDataBasesToDataTable();
                cbDataBasesList.DataSource = dt;
                cbDataBasesList.DisplayMember = "DatabaseName";

                if (dt.Rows.Count > 0)
                {
                    cbDataBasesList.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ShowError("Error loading databases: " + ex.Message);
            }
        }

        private async void DatabasesList_Load(object sender, EventArgs e)
        {
            HandleProjectNameAndPath();
            FillComboBoxWithDataBases();
            UpdateButtonStates();
        }

        private void btnBrowsPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select the folder for your project";
                folderDialog.SelectedPath = mtbProjectPath.Text;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    mtbProjectPath.Text = folderDialog.SelectedPath;
                    clsSettings.ProjectRootPath = folderDialog.SelectedPath;
                }
            }
        }

        private void mtbProjectName_TextChanged(object sender, EventArgs e)
        {
            clsSettings.ProjectName = mtbProjectName.Text.Trim();
            //UpdateButtonStates();
        }

        private bool CreateTheRootProject()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(clsSettings.ProjectRootPath))
                {
                    ShowError("Project path is empty or invalid.");
                    return false;
                }

                //string fullProjectPath = Path.Combine(clsSettings.ProjectRootPath, clsSettings.ProjectName);

                if (!Directory.Exists(clsSettings.ProjectRootPath))
                {
                    Directory.CreateDirectory(clsSettings.ProjectRootPath);
                    return true;
                }
                else
                {
                    ShowWarning("Project folder already exists. Using existing folder.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                ShowError("Failed to create project folder: " + ex.Message);
                return false;
            }
        }

        private void CreateBusinessLayer()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(clsSettings.FolderBusinessLayerPath))
                {
                    ShowError("Business Layer path is empty or invalid.");
                    return;
                }

                if (!Directory.Exists(clsSettings.FolderBusinessLayerPath))
                {
                    Directory.CreateDirectory(clsSettings.FolderBusinessLayerPath);
                }
            }
            catch (Exception ex)
            {
                ShowError("Error creating Business Layer: " + ex.Message);
            }
        }

        private void CreateDataLayer()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(clsSettings.FolderDataLayerPath))
                {
                    ShowError("Data Layer path is empty or invalid.");
                    return;
                }

                if (!Directory.Exists(clsSettings.FolderDataLayerPath))
                {
                    Directory.CreateDirectory(clsSettings.FolderDataLayerPath);
                }
            }
            catch (Exception ex)
            {
                ShowError("Error creating Data Layer: " + ex.Message);
            }
        }

        private void GenerateClasses(enClassType classType)
        {
            if (_Tables == null || _Tables.Count == 0)
            {
                ShowWarning("No tables found in the selected database.");
                return;
            }

            try
            {
                progressBar.Visible = true;
                progressBar.Maximum = _Tables.Count;
                progressBar.Value = 0;

                foreach (string tableName in _Tables)
                {
                    switch (classType)
                    {
                        case enClassType.DataAccess:
                            GenerateDataAccessClass(tableName);
                            break;
                        case enClassType.Business:
                            GenerateBusinessClass(tableName);
                            break;
                    }

                    progressBar.Value++;
                    Application.DoEvents(); // Keep UI responsive
                }

                ShowSuccess($"{_Tables.Count} {classType} classes generated successfully!");
            }
            catch (Exception ex)
            {
                ShowError($"Error generating classes: {ex.Message}");
            }
            finally
            {
                progressBar.Visible = false;
            }
        }

        private void GenerateDataAccessClass(string tableName)
        {
            var generator = new clsGenerateClass(clsGenerateClass.enClassType.DataAccess, tableName, _DataBaseName, clsSettings.FolderDataLayerPath);
            generator.CreateTheFile();
            generator.LoadRecordDetails();
            generator.AddTheHeader();
            generator.GenerateDataAccessMethods();
            generator.AddFooter();
        }

        private void GenerateBusinessClass(string tableName)
        {
            var generator = new clsGenerateClass(clsGenerateClass.enClassType.Business, tableName, _DataBaseName, clsSettings.FolderBusinessLayerPath);
            generator.CreateTheFile();
            generator.LoadRecordDetails();
            generator.AddTheHeader();
            generator.GeneratePropertyAndBusinessMethod();
            generator.AddFooter();
        }

        private async void lbCreateBusinessLayer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_DataBaseName) || _DataBaseName == "master")
            {
                ShowWarning("Please select a valid database first.");
                return;
            }
            btnCreateDataLayer.Enabled = true;
            mtbProjectName.Enabled = false;
            lbCreateBusinessLayer.Enabled = false;
            btBrows.Enabled = false;
            btnCheckForFindBy.Enabled = false;
            cbDataBasesList.Enabled = false;
            cbTablesList.Enabled = false;   


            clsSettings.ProjectRootPath = Path.Combine(clsSettings.ProjectRootPath, clsSettings.ProjectName);

            if (!CreateTheRootProject()) return;

            CreateBusinessLayer();

            try
            {
                _Tables = await clsDataBaseBusiness.GetTableOfSomeDataBaseAsync(_DataBaseName);

                if (_Tables.Count > 0)
                {
                    GenerateClasses(enClassType.Business);
                    UpdateButtonStates();
                }
                else
                {
                    ShowWarning("No tables found in the selected database.");
                }
            }
            catch (Exception ex)
            {
                ShowError("Error loading tables: " + ex.Message);
            }
            
        }

        private void cbDataBasesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _DataBaseName = cbDataBasesList.Text;

            if (!string.IsNullOrEmpty(_DataBaseName) && _DataBaseName != "master")
            {
                try
                {
                    DataTable dt = clsDataBaseBusiness.LoadTablesToDataTable(_DataBaseName);
                    cbTablesList.DataSource = dt;
                    cbTablesList.DisplayMember = "TABLE_NAME";

                    if (dt.Rows.Count > 0)
                    {
                        cbTablesList.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    ShowError("Error loading tables: " + ex.Message);
                }
            }

            UpdateButtonStates();
        }

        private void btnCreateDataLayer_Click(object sender, EventArgs e)
        {
            CreateDataLayer();
            GenerateClasses(enClassType.DataAccess);
            UpdateButtonStates();
            btnCreateDataLayer.Enabled = false;
            mtbProjectName.Enabled = false;
            lbCreateBusinessLayer.Enabled = false;
            btBrows.Enabled = false;
            btnCheckForFindBy.Enabled = false;
            cbDataBasesList.Enabled = false;
            cbTablesList.Enabled = false;
             
        }

        private void btnCheckForFindBy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_DataBaseName) || string.IsNullOrEmpty(_SelectedTable))
            {
                ShowWarning("Please select a database and table first.");
                return;
            }

            using (var frm = new frmColumnSelectionForm(_DataBaseName, _SelectedTable))
            {
                frm.ShowDialog();
            }
        }

        private void cbTablesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbTablesList.Text))
            {
                _SelectedTable = cbTablesList.Text;
                UpdateButtonStates();
            }
        }

        private void UpdateButtonStates()
        {
            bool hasValidDatabase = !string.IsNullOrEmpty(_DataBaseName) && _DataBaseName != "master";
            bool hasValidProjectName = !string.IsNullOrWhiteSpace(clsSettings.ProjectName);
            bool hasValidPath = !string.IsNullOrWhiteSpace(clsSettings.ProjectRootPath);
            bool hasSelectedTable = !string.IsNullOrEmpty(_SelectedTable);

            btnCheckForFindBy.Enabled = hasValidDatabase && hasSelectedTable;
            lbCreateBusinessLayer.Enabled = hasValidDatabase && hasValidProjectName && hasValidPath;
        }

        // Helper methods for user feedback
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mtbProjectPath_TextChanged(object sender, EventArgs e)
        {
            clsSettings.ProjectRootPath = mtbProjectPath.Text;
            UpdateButtonStates();
        }

     
        private void mtbProjectName_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            clsSettings.ProjectName = mtbProjectName.Text;

        }

        private void N_Click(object sender, EventArgs e)
        {

        }

        private void panelActions_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}





/*
using BusinessLayer;
using Generator;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Text;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateCode
{
    public partial class DatabasesList : Form
    {
        enum enClassType { DataAccess, Businesss };
        enClassType _ClassType;
        DataTable _DataTable;
        static string _DataBaseName;
        List<string> _Tables = new List<string>();
        string _SelectedTable;
        public DatabasesList()
        {
            InitializeComponent();
        }
        void HandleProjectNameAndPath()
        {
            mtbProjectName.Text = "New Project";
            clsSettings.ProjectName = mtbProjectName.Text;


            //mtbProjectPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            mtbProjectPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";


            clsSettings.ProjectRootPath = mtbProjectPath.Text;

        }
        void FillComboBoxWithDataBases()
        {
            DataTable dt = new DataTable();
            dt = clsDataBaseBusiness.LoadDataBasesToDataTable();
            cbDataBasesList.DataSource = dt;
            cbDataBasesList.DisplayMember = "DatabaseName";

        }
        private void DatabasesList_Load(object sender, EventArgs e)
        {
            HandleProjectNameAndPath();
            FillComboBoxWithDataBases();


        }
        private void btnBrowsPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.Description = "Select the folder for your project";
            //folderDialog.UseDescriptionForTitle = true; // Optional: shows description as window title

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                //string fullPath = Path.Combine(folderDialog.SelectedPath, clsSettings.ProjectName);

                // Show it in the textbox
                mtbProjectPath.Text = folderDialog.SelectedPath;

                // Update the internal setting
                clsSettings.ProjectRootPath = folderDialog.SelectedPath;
            }
        }

        private void mtbProjectName_TextChanged(object sender, EventArgs e)
        {
            clsSettings.ProjectName = mtbProjectName.Text;
        }
        bool CreateTheRootProject()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(clsSettings.ProjectRootPath))
                {
                    MessageBox.Show("Project path is empty or invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!Directory.Exists(clsSettings.ProjectRootPath))
                {
                    Directory.CreateDirectory(clsSettings.ProjectRootPath);
                    //MessageBox.Show("Project folder created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("This project already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to create project folder: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        void CreateBusinesslayer()
        {
            if (string.IsNullOrWhiteSpace(clsSettings.FolderBusinessLayerPath))
            {
                MessageBox.Show("Business Layer path is empty or invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(clsSettings.FolderBusinessLayerPath))
            {
                Directory.CreateDirectory(clsSettings.FolderBusinessLayerPath);
                //MessageBox.Show("Business Layer folder created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Business Layer folder already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void GenerateClasses(enClassType ClassType)
        {
            List<string> table = _Tables;
            foreach (string tableName in table)
            {
                switch (ClassType)
                {
                    case enClassType.DataAccess:
                        clsGenerateClass GenerateClassesDataAccess = new clsGenerateClass(clsGenerateClass.enClassType.DataAccess, tableName, _DataBaseName, clsSettings.FolderDataLayerPath);
                        GenerateClassesDataAccess.CreateTheFile();
                        GenerateClassesDataAccess.LoadRecordDetails();
                        GenerateClassesDataAccess.AddTheHeader();
                        GenerateClassesDataAccess.GenerateDataAccessMethods();
                        GenerateClassesDataAccess.AddFooter();
                        break;
                    case enClassType.Businesss:
                        clsGenerateClass GenerateClassesBusiness = new clsGenerateClass(clsGenerateClass.enClassType.Business, tableName, _DataBaseName, clsSettings.FolderBusinessLayerPath);
                        GenerateClassesBusiness.CreateTheFile();
                        GenerateClassesBusiness.LoadRecordDetails();
                        GenerateClassesBusiness.AddTheHeader();
                        GenerateClassesBusiness.GeneratePropertyAndBusinessMethod();
                        GenerateClassesBusiness.AddFooter();
                        break;
                }
            }

        }

        private void lbCreateBusinessLayer_Click(object sender, EventArgs e)
        {
            if (cbDataBasesList.Text == "master")
            {
                MessageBox.Show("Choose Database to Create the project ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsSettings.ProjectRootPath = Path.Combine(clsSettings.ProjectRootPath, clsSettings.ProjectName);


            if (!CreateTheRootProject()) return;
            CreateBusinesslayer();
            _Tables = clsDataBaseBusiness.GetTableOfSomeDataBase(_DataBaseName);

            GenerateClasses(enClassType.Businesss);
            btBrows.Enabled = false;
            btnCreateDataLayer.Enabled = true;
            lbCreateBusinessLayer.Enabled = false;

        }

        private void cbDataBasesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _DataBaseName = cbDataBasesList.Text;
            if (cbDataBasesList.Text.ToString() != "master")
            {
                DataTable dt = new DataTable();
                dt = clsDataBaseBusiness.LoadTablesToDataTable(_DataBaseName);
                cbTablesList.DataSource = dt;
                cbTablesList.DisplayMember = "TABLE_NAME";
            }

        }

        void CreateDatalayer()
        {
            if (string.IsNullOrWhiteSpace(clsSettings.FolderDataLayerPath))
            {
                MessageBox.Show("Data Layer path is empty or invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!Directory.Exists(clsSettings.FolderDataLayerPath))
            {
                Directory.CreateDirectory(clsSettings.FolderDataLayerPath);
                //MessageBox.Show("Data Layer folder created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Layer folder already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCreateDataLayer_Click(object sender, EventArgs e)
        {
            CreateDatalayer();
            //_Tables = clsGenerate.GetTableOfSomeDataBase();

            GenerateClasses(enClassType.DataAccess);
            btnCreateDataLayer.Enabled = false;

        }

        private void mtbProjectName_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            clsSettings.ProjectName = mtbProjectName.Text;
        }

        private void mtbProjectPath_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void panelSettings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCheckForFindBy_Click(object sender, EventArgs e)
        {
            frmColumnSelectionForm frm = new frmColumnSelectionForm(_DataBaseName, _SelectedTable);
            frm.ShowDialog();
        }

        private void cbTablesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbTablesList.Text))
            {
                _SelectedTable = cbTablesList.Text;
                btnCheckForFindBy.Enabled = true;
            }
        }

        private void panelActions_Paint(object sender, PaintEventArgs e)
        {

        }


 
    }
}


*/