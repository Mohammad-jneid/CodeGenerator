using Generator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateCode
{
    internal class clssGeneratMCodMethodsOfBusinesss
    {
        public static string GetHeader(string ClassType, string DataBaseName, string ClassName)
        {
            string Header =
$@"using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

    namespace {DataBaseName}_{ClassType}
    {{
        public class {ClassName}
    {{"; return Header;
        }

        public static string GetTheProperty(string PropertyName, string csharpType)
        {
            return $"\t\tpublic {csharpType} {PropertyName} {{ get; set; }}\n";
        }

        public static string GetDefaultPropertyToConstructreCode(string PropertyName, string csharpType)
        {
            string defaultValue = clsGlobalClass.GetDefaultValue(csharpType);
            return $"this.{PropertyName} = {defaultValue};";
        }

        public static string GetAssignValueFromParametersToObjectCode(string PropertyName)
        {
            return $"this.{PropertyName} = {PropertyName.ToLower()};"; ;
        }

        public static string GetUpdateMethodCode(string TableName, string parameters)
        {
            if (string.IsNullOrEmpty(TableName))
                TableName = "Table";

            string ClassNameOfDataAccess = $"cls{TableName}Data";
            string singularTableName = TableName.EndsWith("s") ?
                TableName.Remove(TableName.Length - 1) : TableName;

            string Content = $@"        private bool _Update{singularTableName}()
        {{
                return {ClassNameOfDataAccess}.Update{singularTableName}({parameters});
        }}";

            return Content;
        }

        public static string GetAddMethodCode(string TableName, string parameters)
        {
            string ClassNameOfDataAccess = $"cls{TableName}Data";
            TableName = TableName. EndsWith("s")?  TableName.Remove(TableName.Length - 1) : TableName; // Remove the last letter (s)

            string Content =
                            $@"        private bool _AddNew{TableName}()
        {{
            this.{clsGlobalClass._PrimaryKeyColumn} = {ClassNameOfDataAccess}.AddNew{TableName}({parameters});
            return (this.{clsGlobalClass._PrimaryKeyColumn} != -1 );
        }}";
            return Content;
        }

         

        public static string GetSaveMethodCode(string TableName)
        {
            if (string.IsNullOrEmpty(TableName))
                TableName = "Table";

            string singularTableName = TableName.EndsWith("s") ?
                TableName.Remove(TableName.Length - 1) : TableName;

            string Content = $@"        public bool Save()
        {{
            switch (_Mode)
            {{
                case enMode.AddNew:
                    if (_AddNew{singularTableName}())
                    {{
                        _Mode = enMode.Update;
                        return true;
                    }}
                    else
                    {{
                        return false;
                    }}

                case enMode.Update:
                    return _Update{singularTableName}();
            }}
            return false;
        }}";

            return Content;
        }

        public static string GetGetDtaMethodCode(string TableName)
        {
            string ClassNameOfDataAccess = $"cls{TableName}Data";

            string Content =
                            $@"        public static DataTable GetAll{TableName}()
        {{
            return {ClassNameOfDataAccess}.Get{TableName}();
        }}
         ";
            return Content;
        }
 
        
        public static string GetIsExistsMethodCode(string TableName, string parameterName, string parameterType = "int")
        {
            if (string.IsNullOrEmpty(TableName))
                TableName = "Table";

            string ClassNameOfDataAccess = $"cls{TableName}Data";
            string singularTableName = TableName.EndsWith("s") ?
                TableName.Remove(TableName.Length - 1) : TableName;

            string Content = $@"        public static bool Is{singularTableName}Exist({parameterType} {parameterName})
        {{
            return {ClassNameOfDataAccess}.Is{singularTableName}Exist({parameterName});
        }}";

            return Content;
        }
        public static string GetDeleteMethodCode(string TableName)
        {
            string ClassNameOfDataAccess = $"cls{TableName}Data";
            TableName = TableName.Remove(TableName.Length - 1); // Remove the last letter (s)

            string Content =
                            $@"        public static bool Delete{TableName}(int {clsGlobalClass._PrimaryKeyColumn})
        {{
            return {ClassNameOfDataAccess}.Delete{TableName}(int {clsGlobalClass._PrimaryKeyColumn});
        }}
         ";
            return Content;
        }

        public static string GetFindMethodCode(string TableName, string parameters)
        {
            if (string.IsNullOrEmpty(TableName))
                TableName = "Table";

            string ClassNameOfDataAccess = $"cls{TableName}Data";
            string singularTableName = TableName.EndsWith("s") ?
                TableName.Remove(TableName.Length - 1) : TableName;

            string localVariables = GenerateLocalVariables();
            string dataAccessCallParameters = GenerateDataAccessCallParameters();

            string Content = $@"        public static cls{singularTableName} FindBy{clsGlobalClass._PrimaryKeyColumn}(int {clsGlobalClass._PrimaryKeyColumn})
        {{
            {localVariables}

            if ({ClassNameOfDataAccess}.Get{singularTableName}InfoBy{clsGlobalClass._PrimaryKeyColumn}({clsGlobalClass._PrimaryKeyColumn}, {dataAccessCallParameters}))
                return new cls{singularTableName}({clsGlobalClass._PrimaryKeyColumn}, {parameters});
            else
                return null;
        }}";

            return Content;
        }

        private static string GenerateLocalVariables()
        {
            StringBuilder variables = new StringBuilder();
            List<clsRecordDetails> records = clsGlobalClass._ColumnDetails;

            foreach (clsRecordDetails record in records)
            {
                if (!record.IsPrimaryKey) // Don't create local variable for primary key
                {
                    string defaultValue =clsGlobalClass.GetDefaultValue (record.CSharpType);
                    variables.AppendLine($"\t\t\t{record.CSharpType} {record.Name} = {defaultValue};");
                }
            }

            return variables.ToString().TrimEnd();
        }
        public static string GetGetAllMethodCode(string TableName)
        {
            if (string.IsNullOrEmpty(TableName))
                TableName = "Table";

            string ClassNameOfDataAccess = $"cls{TableName}Data";
            string singularTableName = TableName.EndsWith("s") ?
                TableName.Remove(TableName.Length - 1) : TableName;

            string Content = $@"        public static DataTable GetAll{singularTableName}s()
        {{
            return {ClassNameOfDataAccess}.GetAll{singularTableName}s();
        }}";

            return Content;
        }

        private static string GenerateDataAccessCallParameters()
        {
            List<string> parameters = new List<string>();
            List<clsRecordDetails> records = clsGlobalClass._ColumnDetails;

            foreach (clsRecordDetails record in records)
            {
                if (!record.IsPrimaryKey)
                {
                    parameters.Add($"ref {record.Name}");
                }
            }

            return string.Join(", ", parameters);
        }
        public static string GetDeleteMethodCode(string TableName, string parameterName, string parameterType = "int")
        {
            if (string.IsNullOrEmpty(TableName))
                TableName = "Table";

            string ClassNameOfDataAccess = $"cls{TableName}Data";
            string singularTableName = TableName.EndsWith("s") ?
                TableName.Remove(TableName.Length - 1) : TableName;

            string Content = $@"
        public static bool Delete{singularTableName}({parameterType} {parameterName})
        {{
            return {ClassNameOfDataAccess}.Delete{singularTableName}({parameterName});
        }}";

            return Content;
        }
        public static string GetFindBySpecificColumnMethodCode(string TableName, clsRecordDetails column)
        {
            if (string.IsNullOrEmpty(TableName))
                TableName = "Table";

            string ClassNameOfDataAccess = $"cls{TableName}Data";
            string singularTableName = TableName.EndsWith("s") ?
                TableName.Remove(TableName.Length - 1) : TableName;

            string localVariables = GenerateLocalVariablesForColumn(column);
            string dataAccessCallParameters = GenerateDataAccessCallParametersForColumn(column);

            string Content = $@"        public static cls{singularTableName} FindBy{column.Name}({column.CSharpType} {column.Name})
        {{
            {localVariables}

            if ({ClassNameOfDataAccess}.Get{singularTableName}By{column.Name}({column.Name}, {dataAccessCallParameters}))
                return new cls{singularTableName}({column.Name}, {GenerateFindByColumnParameters(column)});
            else
                return null;
        }}";

            return Content;
        }
        private static string GenerateFindByColumnParameters(clsRecordDetails targetColumn)
        {
            List<string> parameters = new List<string>();
            List<clsRecordDetails> records = clsGlobalClass._ColumnDetails;

            foreach (clsRecordDetails record in records)
            {
                if (record.Name != targetColumn.Name)
                {
                    parameters.Add(record.Name);
                }
            }

            return string.Join(", ", parameters);
        }
        private static string GenerateLocalVariablesForColumn(clsRecordDetails targetColumn)
        {
            StringBuilder variables = new StringBuilder();
            List<clsRecordDetails> records = clsGlobalClass._ColumnDetails;

            foreach (clsRecordDetails record in records)
            {
                if (record.Name != targetColumn.Name) // Don't create local variable for the search column
                {
                    string defaultValue =clsGlobalClass.GetDefaultValue (record.CSharpType);
                    variables.AppendLine($"\t\t\t{record.CSharpType} {record.Name} = {defaultValue};");
                }
            }

            return variables.ToString().TrimEnd();
        }

        private static string GenerateDataAccessCallParametersForColumn(clsRecordDetails targetColumn)
        {
            List<string> parameters = new List<string>();
            List<clsRecordDetails> records = clsGlobalClass._ColumnDetails;

            foreach (clsRecordDetails record in records)
            {
                if (record.Name != targetColumn.Name)
                {
                    parameters.Add($"ref {record.Name}");
                }
            }

            return string.Join(", ", parameters);
        }

    }

}