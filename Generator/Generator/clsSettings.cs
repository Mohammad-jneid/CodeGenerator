using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCode
{

    internal class clsSettings
    {
        //public static string connectionstring = "Server=.;DataBase=DVLD;user Id=sa;Password=123456";

        public static string ProjectName { get; set; } = "MyWinFormsApp";

        private static string _projectRootPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "MyWinFormsApp");

        public static string ProjectRootPath
        {
            get => _projectRootPath;
            set
            {
                _projectRootPath = string.IsNullOrWhiteSpace(value)
                    ? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), ProjectName)
                    : value;

                FolderDataLayerPath = Path.Combine(_projectRootPath, "DataAccessLayer");
                FolderBusinessLayerPath = Path.Combine(_projectRootPath, "BusinessLayer");
            }
        }

        public static string FolderDataLayerPath { get; private set; }
        public static string FolderBusinessLayerPath { get; private set; }
    }

}