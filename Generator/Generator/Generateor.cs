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

        public DatabasesList()
        {
            InitializeComponent();
        }
        void HandleProjectNameAndPath()
        {
            mtbProjectName.Text = "New Project";
            clsSettings.ProjectName = mtbProjectName.Text;

            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //mtbProjectPath.Text = Path.Combine(path, clsSettings.ProjectName);
            mtbProjectPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
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
                        GenerateClassesDataAccess.AddTheHeader();
                        GenerateClassesDataAccess.GenerateDataAccessMethods();
                        GenerateClassesDataAccess.AddFooter();
                        break;
                    case enClassType.Businesss:
                        clsGenerateClass GenerateClassesBusiness = new clsGenerateClass(clsGenerateClass.enClassType.Business, tableName, _DataBaseName, clsSettings.FolderBusinessLayerPath);
                        GenerateClassesBusiness.CreateTheFile();
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
         

        //private void button1_Click(object sender, EventArgs e)
        //{

        //    Directory.Delete(clsSettings.ProjectRootPath, true);
        //    this.Close();
        //}

    }
}

