using BusinessLayer;
using GenerateCode;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    public class clsGenerateClass
    {
        //clsGenerateClass.enClassType.DataAccess, tableName, _DataBaseName, clsSettings.FolderDataLayerPath);
        public enum enClassType { DataAccess, Business };
        string _ClassType;
        public string DataBaseName { get; set; }
        public string ClassName { get; set; }
        public string TableName { get; set; }

        public string _CurrentFolderPath;
        public string _FilePath { get; set; }

        void AddToFile(string Content, string Comment = "")
        {
            if (Comment != "")
                File.AppendAllText(this._FilePath, "\t\t//" + Comment + "\n");

            File.AppendAllText(this._FilePath, Content);
        }

        public clsGenerateClass(clsGenerateClass.enClassType classtype, string tablename,
            string databaseName, string currentFolderPath)
        {
            this._CurrentFolderPath = currentFolderPath;
            this.DataBaseName = databaseName;
            this._ClassType = classtype == enClassType.DataAccess ? "Data" : "Business";
            this.TableName = tablename;
            this.ClassName = classtype == enClassType.Business ? "cls" + tablename : $"cls{tablename}Data";

            this._CurrentFolderPath = currentFolderPath;
            _FilePath = Path.Combine(this._CurrentFolderPath, this.ClassName + ".cs");
        }

        public void CreateTheFile()
        {
            File.WriteAllText(_FilePath, "");
        }

        void GenerateTheParameterizedConstructure()
        {
            AddToFile("\n");
            AddToFile("", "Parameterized Constructor - Sets All Properties");

            string parameters = GenerateConstructorParameters();
            string assignments = GenerateParameterAssignments();

            string constructorCode = $@"
        public {this.ClassName}({parameters})
        {{
 {assignments}
        }}";

            AddToFile(constructorCode);
        }
         private string GenerateConstructorParameters()
        {
            List<string> parameters = new List<string>();
            List<clsRecordDetails> records = clsGlobalClass._ColumnDetails;

            foreach (clsRecordDetails record in records)
            {
                // Only the parameter name is lowercase, type remains proper case
                parameters.Add($"{record.CSharpType} {record.Name.ToLower()}");
            }

            return string.Join(", ", parameters);
        }
        string GenerateParameterAssignments()
        {
            StringBuilder assignments = new StringBuilder();
            List<clsRecordDetails> records = clsGlobalClass._ColumnDetails;

            foreach (clsRecordDetails record in records)
            {
                string assignmentLine = clssGeneratMCodMethodsOfBusinesss.GetAssignValueFromParametersToObjectCode(record.Name);
                assignments.AppendLine($"            {assignmentLine}");
            }

            return assignments.ToString();
        }

        void GenerateTheDefaultConstructure()
        {
            AddToFile("\n\n");
            AddToFile("", "Default Constructor - Resets to Default Values");

            string constructorCode = $@"
        public {this.ClassName}()
        {{
{GeneratePropertyInitializations()}
        }}";

            AddToFile(constructorCode);
            AddToFile("\n");
        }

        string GeneratePropertyInitializations()
        {
            StringBuilder initializations = new StringBuilder();
            List<clsRecordDetails> records = clsGlobalClass._ColumnDetails;

            foreach (clsRecordDetails record in records)
            {
                string initializationLine = clssGeneratMCodMethodsOfBusinesss.GetDefaultPropertyToConstructreCode(record.Name, record.CSharpType);
                initializations.AppendLine($"            {initializationLine}");
            }

            return initializations.ToString();
        }
        void GenerateAddNewMethod()
        {
            AddToFile("\n\n");
            AddToFile("", "Add New Method - Calls Data Access Layer");

            string methodCode = clssGeneratMCodMethodsOfBusinesss.GetAddMethodCode(this.TableName, GenerateAddMethodParameters());
            AddToFile(methodCode);
        }

        string GenerateAddMethodParameters()
        {
            List<string> parameters = new List<string>();
            List<clsRecordDetails> records = clsGlobalClass._ColumnDetails;

            foreach (clsRecordDetails record in records)
            {
                if (!record.IsPrimaryKey)
                {
                    // Use the same pattern as your existing method
                    parameters.Add($"this.{record.Name}");
                }
            }

            return string.Join(", ", parameters);
        }
        string GenerateUpdateMethodParameters()
        {
            List<string> parameters = new List<string>();
            List<clsRecordDetails> records = clsGlobalClass._ColumnDetails;

            foreach (clsRecordDetails record in records)
            {
                // Include ALL parameters for update, including primary key
                parameters.Add($"this.{record.Name}");
            }

            return string.Join(", ", parameters);
        }
        void GenerateUpdateMethod()
        {
            AddToFile("\n\n");
            AddToFile("", "Update Method - Calls Data Access Layer");

            string methodCode = clssGeneratMCodMethodsOfBusinesss.GetUpdateMethodCode(this.TableName, GenerateUpdateMethodParameters());
            AddToFile(methodCode);
        }
        void GenerateFindMethod()
        {
            AddToFile("\n\n");
            AddToFile("", "Find Method - Finds by Primary Key");

            string methodCode = clssGeneratMCodMethodsOfBusinesss.GetFindMethodCode(this.TableName, GenerateFindMethodParameters());
            AddToFile(methodCode);
        }
        string GenerateFindMethodParameters()
        {
            List<string> parameters = new List<string>();
            List<clsRecordDetails> records = clsGlobalClass._ColumnDetails;

            foreach (clsRecordDetails record in records)
            {
                if (!record.IsPrimaryKey) // Primary key is passed separately
                {
                    parameters.Add(record.Name);
                }
            }

            return string.Join(", ", parameters);
        }
        void GenerateSaveMethod()
        {
            AddToFile("\n\n");
            AddToFile("", "Save Method - Handles Add and Update Operations");

            string methodCode = clssGeneratMCodMethodsOfBusinesss.GetSaveMethodCode(this.TableName);
            AddToFile(methodCode);
        }
        void GenerateIsExistsMethod()
        {
            AddToFile("\n\n");
            AddToFile("", "IsExists Method - Checks if record exists");

            string methodCode = clssGeneratMCodMethodsOfBusinesss.GetIsExistsMethodCode(
                this.TableName,
                clsGlobalClass._PrimaryKeyColumn,
                GetPrimaryKeyType());
            AddToFile(methodCode);
        }

        void GenerateGetAllMethod()
        {
            AddToFile("\n\n");
            AddToFile("", "GetAll Method - Returns all records as DataTable");

            string methodCode = clssGeneratMCodMethodsOfBusinesss.GetGetAllMethodCode(this.TableName);
            AddToFile(methodCode);
        }

        string GetPrimaryKeyType()
        {
            var primaryKeyColumn = clsGlobalClass._ColumnDetails.FirstOrDefault(col => col.IsPrimaryKey);
            return primaryKeyColumn?.CSharpType ?? "int";
        }

        void GenerateAdditionalFindByMethods()
        {
            if (clsGlobalClass._ColumnDetails == null) return;

            // Get the columns that should have FindBy methods for this table
            List<string> FindByColumns = new List<string>();
            if (clsGlobalClass._ColumnPositionYouWantToFindBy.ContainsKey(this.TableName))
            {
                FindByColumns = clsGlobalClass._ColumnPositionYouWantToFindBy[this.TableName];
            }

            foreach (string columnName in FindByColumns)
            {
                var column = clsGlobalClass._ColumnDetails.FirstOrDefault(c => c.Name == columnName);
                if (column != null && !column.IsPrimaryKey)
                {
                    AddToFile("\n\n", $"FindBy{column.Name} Method - Finds by {column.Name}");

                    string methodCode = clssGeneratMCodMethodsOfBusinesss.GetFindBySpecificColumnMethodCode(this.TableName, column);
                    AddToFile(methodCode);
                }
            }
        }
        void FindPrimarykey()
        {

            var primaryKeyColumn = clsGlobalClass._ColumnDetails.FirstOrDefault(col => col.IsPrimaryKey);
            if (primaryKeyColumn != null)
            {
                clsGlobalClass._PrimaryKeyColumn = primaryKeyColumn.Name;
            }
            else
            {
                // Fallback to first column if no primary key found
                clsGlobalClass._PrimaryKeyColumn = clsGlobalClass._ColumnDetails.First().Name;
            }
        }

        public void LoadRecordDetails()
        {
            clsDataBaseBusiness.LoadColomnInfoDetails(this.DataBaseName, this.TableName);
            List<string> FindByColumn = clsGlobalClass._ColumnPositionYouWantToFindBy
                .Where(n => n.Key == this.TableName)
                .Select(n => n.Value)
                .FirstOrDefault();
            foreach (var column in clsGlobalClass._ColumnDetails)
            {
                if (FindByColumn?.Contains(column.Name) == true)
                {
                    column.YouWantToFindBy = true;
                }
            }
        }
        void GenerateDeleteDataAccessMethod()
        {
            AddToFile("\n\n", "Delete Method - Data Access Layer");

            string methodCode = clsGenerateMethodsCodeOfDataAccess.GetDeleteMethodCode(
                this.TableName,
                clsGlobalClass._PrimaryKeyColumn,
                GetPrimaryKeyType());
            AddToFile(methodCode);
        }
        void GenerateDeleteMethod()
        {
            AddToFile("\n\n", "Delete Method - Business Layer");

            string methodCode = clssGeneratMCodMethodsOfBusinesss.GetDeleteMethodCode(
                this.TableName,
                clsGlobalClass._PrimaryKeyColumn,
                GetPrimaryKeyType());
            AddToFile(methodCode);
        }


        public void GeneratePropertyAndBusinessMethod()
        {
            FindPrimarykey();

            GenerateTheProperty();
            GenerateTheDefaultConstructure();
            GenerateTheParameterizedConstructure();
            GenerateAddNewMethod();
            GenerateUpdateMethod();
            GenerateFindMethod();
            GenerateAdditionalFindByMethods();
            GenerateSaveMethod();
            GenerateDeleteMethod();
            GenerateIsExistsMethod();
            GenerateGetAllMethod();


        }
        void AddEnum()
        {
            AddToFile("\n", "");
            string Enum = @"        public enum enMode { AddNew = 0, Update = 1 };
        public enMode _Mode = enMode.AddNew;
";
            AddToFile(Enum);
        }
        void GenerateTheProperty()
        {
            AddEnum();
            AddToFile("\n\n", "");


            AddToFile("", "These are the Property");
            List<clsRecordDetails> records = clsGlobalClass._ColumnDetails;
            foreach (clsRecordDetails record in records)
            {
                AddToFile(clssGeneratMCodMethodsOfBusinesss.GetTheProperty(record.Name, record.CSharpType));
            }
        }
        void GenerateAdditionalFindByDataAccessMethods()
        {
            if (clsGlobalClass._ColumnDetails == null) return;

            // Get the columns that should have FindBy methods for this table
            List<string> FindByColumns = new List<string>();
            if (clsGlobalClass._ColumnPositionYouWantToFindBy.ContainsKey(this.TableName))
            {
                FindByColumns = clsGlobalClass._ColumnPositionYouWantToFindBy[this.TableName];
            }

            foreach (string columnName in FindByColumns)
            {
                var column = clsGlobalClass._ColumnDetails.FirstOrDefault(c => c.Name == columnName);
                if (column != null && !column.IsPrimaryKey)
                {
                    AddToFile("\n\n", $"FindBy{column.Name} Method - Data Access Layer");

                    string methodCode = clsGenerateMethodsCodeOfDataAccess.GetFindByColumnMethodCode(this.TableName, column);
                    AddToFile(methodCode);
                }
            }
        }
        public void GenerateDataAccessMethods()
        {
             FindPrimarykey();

            GenerateAddDataAccessMethod();
            GenerateUpdateDataAccessMethod();
             GenerateFindDataAccessMethod();
            GenerateGetAllDataAccessMethod();
            GenerateIsExistsDataAccessMethod();
            GenerateDeleteDataAccessMethod();
            //GenerateFindDataAccessMethod();
            //GenerateAdditionalFindByDataAccessMethods();
            GenerateAdditionalFindByDataAccessMethods();
        }
        void GenerateFindDataAccessMethod()
        {
            AddToFile("\n\n", "Find Method - Data Access Layer");

            string methodCode = clsGenerateMethodsCodeOfDataAccess.GetFindMethodCode(this.TableName, GenerateDataAccessMethodParameters(true));
            AddToFile(methodCode);
        }

        void GenerateGetAllDataAccessMethod()
        {
            AddToFile("", "    GetAll Method - Data Access Layer");

            string methodCode = clsGenerateMethodsCodeOfDataAccess.GetGetAllMethodCode(this.TableName);
            AddToFile(methodCode);
        }

        void GenerateIsExistsDataAccessMethod()
        {
            AddToFile("\n\n", "IsExists Method - Data Access Layer");

            string methodCode = clsGenerateMethodsCodeOfDataAccess.GetIsExistsMethodCode(
                this.TableName,
                clsGlobalClass._PrimaryKeyColumn,
                GetPrimaryKeyType());
            AddToFile(methodCode);
        }

        string GenerateDataAccessMethodParameters(bool includePrimaryKey)
        {
            List<string> parameters = new List<string>();
            List<clsRecordDetails> records = clsGlobalClass._ColumnDetails;

            foreach (clsRecordDetails record in records)
            {
                if (includePrimaryKey || !record.IsPrimaryKey)
                {
                    parameters.Add($"{record.CSharpType} {record.Name}");
                }
            }

            return string.Join(", ", parameters);
        }
        void GenerateAddDataAccessMethod()
        {
            AddToFile("\n\n", "Add Method - Data Access Layer");

            string parameters = GenerateDataAccessMethodParameters(false); // false = exclude primary key for Add
            string methodCode = clsGenerateMethodsCodeOfDataAccess.GetAddMethodCode(this.TableName, parameters);
            AddToFile(methodCode);
        }

        void GenerateUpdateDataAccessMethod()
        {
            AddToFile("\n\n", "Update Method - Data Access Layer");

            string parameters = GenerateDataAccessMethodParameters(true); // true = include all parameters for Update
            string methodCode = clsGenerateMethodsCodeOfDataAccess.GetUpdateMethodCode(this.TableName, parameters);
            AddToFile(methodCode);
        }
        public void AddFooter()
        {
            string Content = @"         }
}";
            AddToFile(Content);
        }
        public void AddTheHeader()
        {
            string Content;
            //if (this._ClassType == "Business")
            Content = clssGeneratMCodMethodsOfBusinesss.GetHeader(this._ClassType, this.DataBaseName, this.ClassName);

            AddToFile(Content);
        }


    }
}

/*using BusinessLayer;
using GenerateCode;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace Generator
{
    public class clsGenerateClass
    {
        public enum enClassType { DataAccess, Business };

        private string _ClassType;
        public string DataBaseName { get; set; }
        public string ClassName { get; set; }
        public string TableName { get; set; }
        public string _CurrentFolderPath;
        public string _FilePath { get; set; }

        public clsGenerateClass(clsGenerateClass.enClassType classtype, string tablename,
            string databaseName, string currentFolderPath)
        {
            this._CurrentFolderPath = currentFolderPath;
            this.DataBaseName = databaseName;
            this._ClassType = classtype == enClassType.DataAccess ? "Data" : "Business";
            this.TableName = tablename;
            this.ClassName = classtype == enClassType.Business ? $"cls{tablename}" : $"cls{tablename}Data";
            _FilePath = Path.Combine(this._CurrentFolderPath, this.ClassName + ".cs");
        }

        private void AddToFile(string content, string comment = "")
        {
            if (!string.IsNullOrEmpty(comment))
                File.AppendAllText(this._FilePath, $"\t// {comment}\n");

            File.AppendAllText(this._FilePath, content);
        }

        public void CreateTheFile()
        {
            File.WriteAllText(_FilePath, "");
        }

        public void AddTheHeader()
        {
            string content = clssGeneratMCodMethodsOfBusinesss.GetHeader(this._ClassType, this.DataBaseName, this.ClassName);
            AddToFile(content);
        }

        public void AddFooter()
        {
            string content = @"    }
}";
            AddToFile(content);
        }

        public void LoadRecordDetails()
        {
            if (clsGlobalClass._ColumnDetails == null)
            {
                clsDataBaseBusiness.LoadColomnInfoDetails(this.DataBaseName, this.TableName);
            }

            List<string> findByColumns = clsGlobalClass._ColumnPositionYouWantToFindBy
                .Where(n => n.Key == this.TableName)
                .Select(n => n.Value)
                .FirstOrDefault();

            if (findByColumns != null && clsGlobalClass._ColumnDetails != null)
            {
                foreach (var column in clsGlobalClass._ColumnDetails)
                {
                    column.YouWantToFindBy = findByColumns.Contains(column.Name);
                }
            }
        }

        private void FindPrimaryKey()
        {
            if (clsGlobalClass._ColumnDetails == null || !clsGlobalClass._ColumnDetails.Any())
                return;

            var primaryKeyColumn = clsGlobalClass._ColumnDetails.FirstOrDefault(col => col.IsPrimaryKey);
            if (primaryKeyColumn != null)
            {
                clsGlobalClass._PrimaryKeyColumn = primaryKeyColumn.Name;
            }
            else
            {
                clsGlobalClass._PrimaryKeyColumn = clsGlobalClass._ColumnDetails.First().Name;
            }
        }

        // Property Generation
        private void AddEnum()
        {
            string enumCode = @"        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
";
            AddToFile(enumCode);
        }

        private void GenerateTheProperty()
        {
            AddEnum();
            AddToFile("\n", "Properties");

            if (clsGlobalClass._ColumnDetails == null) return;

            foreach (clsRecordDetails record in clsGlobalClass._ColumnDetails)
            {
                AddToFile(clssGeneratMCodMethodsOfBusinesss.GetTheProperty(record.Name, record.CSharpType));
            }
        }

        // Constructor Generation
        private void GenerateTheDefaultConstructor()
        {
            AddToFile("\n", "Default Constructor - Resets to Default Values");

            string constructorCode = $@"
        public {this.ClassName}()
        {{
            // Initialize all properties to their default values
{GeneratePropertyInitializations()}
        }}";

            AddToFile(constructorCode);
        }

        private void GenerateTheParameterizedConstructor()
        {
            AddToFile("\n", "Parameterized Constructor - Sets All Properties");

            string parameters = GenerateConstructorParameters();
            string assignments = GenerateParameterAssignments();

            string constructorCode = $@"
        public {this.ClassName}({parameters})
        {{
            // Set all properties from parameters
{assignments}
        }}";

            AddToFile(constructorCode);
        }

        private string GenerateConstructorParameters()
        {
            if (clsGlobalClass._ColumnDetails == null) return string.Empty;

            List<string> parameters = new List<string>();
            foreach (clsRecordDetails record in clsGlobalClass._ColumnDetails)
            {
                parameters.Add($"{record.CSharpType} {record.Name.ToLower()}");
            }
            return string.Join(", ", parameters);
        }

        private string GenerateParameterAssignments()
        {
            if (clsGlobalClass._ColumnDetails == null) return string.Empty;

            StringBuilder assignments = new StringBuilder();
            foreach (clsRecordDetails record in clsGlobalClass._ColumnDetails)
            {
                string assignmentLine = clssGeneratMCodMethodsOfBusinesss.GetAssignValueFromParametersToObjectCode(record.Name);
                assignments.AppendLine($"            {assignmentLine}");
            }
            return assignments.ToString();
        }

        private string GeneratePropertyInitializations()
        {
            if (clsGlobalClass._ColumnDetails == null) return string.Empty;

            StringBuilder initializations = new StringBuilder();
            foreach (clsRecordDetails record in clsGlobalClass._ColumnDetails)
            {
                string initializationLine = clssGeneratMCodMethodsOfBusinesss.GetDefaultPropertyToConstructreCode(record.Name, record.CSharpType);
                initializations.AppendLine($"            {initializationLine}");
            }
            return initializations.ToString();
        }

        // Business Layer Methods
        public void GeneratePropertyAndBusinessMethod()
        {
            FindPrimaryKey();
            GenerateTheProperty();
            GenerateTheDefaultConstructor();
            GenerateTheParameterizedConstructor();
            GenerateAddNewMethod();
            GenerateUpdateMethod();
            GenerateFindMethod();
            GenerateSaveMethod();
            GenerateIsExistsMethod();
            GenerateGetAllMethod();
            GenerateAdditionalFindByMethods();
        }

        private void GenerateAddNewMethod()
        {
            AddToFile("\n", "Add New Method - Calls Data Access Layer");
            string methodCode = clssGeneratMCodMethodsOfBusinesss.GetAddMethodCode(this.TableName, GenerateAddMethodParameters());
            AddToFile(methodCode);
        }

        private void GenerateUpdateMethod()
        {
            AddToFile("\n", "Update Method - Calls Data Access Layer");
            string methodCode = clssGeneratMCodMethodsOfBusinesss.GetUpdateMethodCode(this.TableName, GenerateUpdateMethodParameters());
            AddToFile(methodCode);
        }

        private void GenerateFindMethod()
        {
            AddToFile("\n", "Find Method - Finds by Primary Key");
            string methodCode = clssGeneratMCodMethodsOfBusinesss.GetFindMethodCode(this.TableName, GenerateFindMethodParameters());
            AddToFile(methodCode);
        }

        private void GenerateSaveMethod()
        {
            AddToFile("\n", "Save Method - Handles Add and Update Operations");
            string methodCode = clssGeneratMCodMethodsOfBusinesss.GetSaveMethodCode(this.TableName);
            AddToFile(methodCode);
        }

        private void GenerateIsExistsMethod()
        {
            AddToFile("\n", "IsExists Method - Checks if record exists");
            string methodCode = clssGeneratMCodMethodsOfBusinesss.GetIsExistsMethodCode(
                this.TableName,
                clsGlobalClass._PrimaryKeyColumn,
                GetPrimaryKeyType());
            AddToFile(methodCode);
        }

        private void GenerateGetAllMethod()
        {
            AddToFile("\n", "GetAll Method - Returns all records as DataTable");
            string methodCode = clssGeneratMCodMethodsOfBusinesss.GetGetAllMethodCode(this.TableName);
            AddToFile(methodCode);
        }

        private void GenerateAdditionalFindByMethods()
        {
            if (clsGlobalClass._ColumnDetails == null) return;

            List<string> findByColumns = clsGlobalClass._ColumnPositionYouWantToFindBy
                .Where(n => n.Key == this.TableName)
                .Select(n => n.Value)
                .FirstOrDefault() ?? new List<string>();

            foreach (string columnName in findByColumns)
            {
                var column = clsGlobalClass._ColumnDetails.FirstOrDefault(c => c.Name == columnName);
                if (column != null && !column.IsPrimaryKey)
                {
                    AddToFile("\n", $"FindBy{column.Name} Method - Finds by {column.Name}");
                    string methodCode = clssGeneratMCodMethodsOfBusinesss.GetFindBySpecificColumnMethodCode(this.TableName, column);
                    AddToFile(methodCode);
                }
            }
        }

        private string GenerateAddMethodParameters()
        {
            if (clsGlobalClass._ColumnDetails == null) return string.Empty;

            List<string> parameters = new List<string>();
            foreach (clsRecordDetails record in clsGlobalClass._ColumnDetails)
            {
                if (!record.IsPrimaryKey)
                {
                    parameters.Add($"this.{record.Name}");
                }
            }
            return string.Join(", ", parameters);
        }

        private string GenerateUpdateMethodParameters()
        {
            if (clsGlobalClass._ColumnDetails == null) return string.Empty;

            List<string> parameters = new List<string>();
            foreach (clsRecordDetails record in clsGlobalClass._ColumnDetails)
            {
                parameters.Add($"this.{record.Name}");
            }
            return string.Join(", ", parameters);
        }

        private string GenerateFindMethodParameters()
        {
            if (clsGlobalClass._ColumnDetails == null) return string.Empty;

            List<string> parameters = new List<string>();
            foreach (clsRecordDetails record in clsGlobalClass._ColumnDetails)
            {
                if (!record.IsPrimaryKey)
                {
                    parameters.Add(record.Name);
                }
            }
            return string.Join(", ", parameters);
        }

        private string GetPrimaryKeyType()
        {
            var primaryKeyColumn = clsGlobalClass._ColumnDetails?.FirstOrDefault(col => col.IsPrimaryKey);
            return primaryKeyColumn?.CSharpType ?? "int";
        }

        // Data Access Layer Methods
        public void GenerateDataAccessMethods()
        {
            FindPrimaryKey();
            GenerateAddDataAccessMethod();
            GenerateUpdateDataAccessMethod();
            GenerateFindDataAccessMethod();
            GenerateGetAllDataAccessMethod();
            GenerateIsExistsDataAccessMethod();
            GenerateAdditionalFindByDataAccessMethods();
        }

        private void GenerateAddDataAccessMethod()
        {
            AddToFile("\n", "Add Method - Data Access Layer");
            string parameters = GenerateDataAccessMethodParameters(false);
            string methodCode = clsGenerateMethodsCodeOfDataAccess.GetAddMethodCode(this.TableName, parameters);
            AddToFile(methodCode);
        }

        private void GenerateUpdateDataAccessMethod()
        {
            AddToFile("\n", "Update Method - Data Access Layer");
            string parameters = GenerateDataAccessMethodParameters(true);
            string methodCode = clsGenerateMethodsCodeOfDataAccess.GetUpdateMethodCode(this.TableName, parameters);
            AddToFile(methodCode);
        }

        private void GenerateFindDataAccessMethod()
        {
            AddToFile("\n", "Find Method - Data Access Layer");
            string methodCode = clsGenerateMethodsCodeOfDataAccess.GetFindMethodCode(this.TableName, GenerateDataAccessMethodParameters(true));
            AddToFile(methodCode);
        }

        private void GenerateGetAllDataAccessMethod()
        {
            AddToFile("\n", "GetAll Method - Data Access Layer");
            string methodCode = clsGenerateMethodsCodeOfDataAccess.GetGetAllMethodCode(this.TableName);
            AddToFile(methodCode);
        }

        private void GenerateIsExistsDataAccessMethod()
        {
            AddToFile("\n", "IsExists Method - Data Access Layer");
            string methodCode = clsGenerateMethodsCodeOfDataAccess.GetIsExistsMethodCode(
                this.TableName,
                clsGlobalClass._PrimaryKeyColumn,
                GetPrimaryKeyType());
            AddToFile(methodCode);
        }

        private void GenerateAdditionalFindByDataAccessMethods()
        {
            if (clsGlobalClass._ColumnDetails == null) return;

            List<string> findByColumns = clsGlobalClass._ColumnPositionYouWantToFindBy
                .Where(n => n.Key == this.TableName)
                .Select(n => n.Value)
                .FirstOrDefault() ?? new List<string>();

            foreach (string columnName in findByColumns)
            {
                var column = clsGlobalClass._ColumnDetails.FirstOrDefault(c => c.Name == columnName);
                if (column != null && !column.IsPrimaryKey)
                {
                    AddToFile("\n", $"FindBy{column.Name} Method - Data Access Layer");
                    string methodCode = clsGenerateMethodsCodeOfDataAccess.GetFindByColumnMethodCode(this.TableName, column);
                    AddToFile(methodCode);
                }
            }
        }

        private string GenerateDataAccessMethodParameters(bool includePrimaryKey)
        {
            if (clsGlobalClass._ColumnDetails == null) return string.Empty;

            List<string> parameters = new List<string>();
            foreach (clsRecordDetails record in clsGlobalClass._ColumnDetails)
            {
                if (includePrimaryKey || !record.IsPrimaryKey)
                {
                    parameters.Add($"{record.CSharpType} {record.Name}");
                }
            }
            return string.Join(", ", parameters);
        }
    }
}

*/
