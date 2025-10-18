using Generator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GenerateCode
{
    internal class clsGenerateMethodsCodeOfDataAccess
    {


        public static string GetFindByColumnMethodCode(string TableName, clsRecordDetails column)
        {
            string singularTableName = TableName.EndsWith("s") ? TableName.Remove(TableName.Length - 1) : TableName;

            string refParameters = GenerateRefParametersForColumn(column);

            string Content = $@"
        public static bool Get{singularTableName}By{column.Name}({column.CSharpType} {column.Name}, {refParameters})
        {{
            bool isFound = false;
            
            string query = @""SELECT {string.Join(", ", clsGlobalClass._ColumnDetails.Select(col => col.Name))} 
                            FROM {TableName} 
                            WHERE {column.Name} = @{column.Name}"";
            
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {{
                command.Parameters.AddWithValue(""@{column.Name}"", {column.Name});
                
                try
                {{
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {{
                        if (reader.Read())
                        {{
                            isFound = true;
                            {GenerateReaderAssignmentsForColumn(column)}
                        }}
                    }}
                }}
                catch (Exception ex)
                {{
                    // Handle exception
                }}
            }}
            
            return isFound;
        }}";

            return Content;
        }

        private static string GenerateRefParametersForColumn(clsRecordDetails targetColumn)
        {
            List<string> parameters = new List<string>();
            List<clsRecordDetails> records = clsGlobalClass._ColumnDetails;

            foreach (clsRecordDetails record in records)
            {
                if (record.Name != targetColumn.Name)
                {
                    parameters.Add($"ref {record.CSharpType} {record.Name}");
                }
            }

            return string.Join(", ", parameters);
        }

        private static string GenerateReaderAssignmentsForColumn(clsRecordDetails targetColumn)
        {
            StringBuilder assignments = new StringBuilder();
            List<clsRecordDetails> records = clsGlobalClass._ColumnDetails;

            foreach (clsRecordDetails record in records)
            {
                if (record.Name != targetColumn.Name)
                {
                    assignments.AppendLine($"{record.Name} = ({record.CSharpType})reader[\"{record.Name}\"];");
                }
            }

            return assignments.ToString();
        }
        /*  static void HandleTheNallubleValue(ref string AddParameters, string ColumnName)
          {
              AddParameters += $@"      
                  if ({ColumnName} != """" && {ColumnName} != null)
                  command.Parameters.AddWithValue(""@{ColumnName}"", {ColumnName});
                  else  command.Parameters.AddWithValue(""@{ColumnName}"", System.DBNull.Value);

  ";
              return;
          }
          static string GetAddParameters()
          {
              string AddParameters = "\n";
              foreach (var item in clsGlobalClass._ColumnDetails)
              {
                  if (item.Name != clsGlobalClass._PrimaryKeyColumn)
                      if (item.IsNullable)
                      {
                          HandleTheNallubleValue(ref AddParameters, item.Name);
                      }
                      else
                          AddParameters += $"\t\t\t\tCommand.Parameters.AddWithValue(@\"{item.Name}\" , {item.Name});\n";
              }

              return AddParameters;
          }*/
        /*        public static string GetAddMethodCode(string TableName, string Parameters)
                {
                    //TableName = ;

                    string Content = $@"
                    public static int AddNew{TableName.Remove(TableName.Length - 1)}({Parameters})
                    {{
                        int {TableName.Remove(TableName.Length - 1)}ID = -1 ;
                            string query = @"" Insert into {TableName} ({string.Join(",", clsGlobalClass.ParametersAsArray)})
                        VALUES (@{string.Join(",", clsGlobalClass.ParametersAsArray)})
                        SELECT SCOPE_IDENTITY();""
                        using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                        using(SqlCommand Command = new SqlCommand(query,Connection))
                        {{
                                {GetAddParameters()}
                        try
                        {{
                            Connection.Open();
                            object result = command.ExecuteScalar();
                            if(result != null && int.TryParse(result.ToString() , out int InsertedID))
                            {{
                                {TableName.Remove(TableName.Length - 1)}ID = InsertedID ;
                            }}
                        }}
                        catch (Exception)
                        {{
                            throw;
                        }}
                        }}
                    return {TableName.Remove(TableName.Length - 1)}ID;
                    }}




        ";


                    return Content;
                }
        */

        public static string GetAddMethodCode(string TableName, string Parameters)
        {
            string singularTableName = TableName.EndsWith("s") ? TableName.Remove(TableName.Length - 1) : TableName;

            // For INSERT, only include non-primary key columns
            var insertColumns = clsGlobalClass._ColumnDetails
                .Where(col => !col.IsPrimaryKey)
                .Select(col => col.Name);

            var valueParams = clsGlobalClass._ColumnDetails
                .Where(col => !col.IsPrimaryKey)
                .Select(col => $"@{col.Name}");

            string Content = $@"
        public static int AddNew{singularTableName}({Parameters})
        {{
            int {singularTableName}ID = -1;
            string query = @""INSERT INTO {TableName} ({string.Join(", ", insertColumns)})
                VALUES ({string.Join(", ", valueParams)})
                SELECT SCOPE_IDENTITY();"";

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(query, Connection))
            {{
                {GetAddParametersForInsert()}
                
                try
                {{
                    Connection.Open();
                    object result = Command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    {{
                        {singularTableName}ID = InsertedID;
                    }}
                }}
                catch (Exception ex)
                {{
                    // Handle exception
                }}
            }}
            return {singularTableName}ID;
        }}";

            return Content;
        }

        static string GetAddParametersForInsert()
        {
            string AddParameters = "\n";
            foreach (var item in clsGlobalClass._ColumnDetails)
            {
                if (!item.IsPrimaryKey) // Only add non-primary key parameters for INSERT
                {
                    if (item.IsNullable)
                    {
                        AddParameters += $@"      
                if ({item.Name} != null)
                    Command.Parameters.AddWithValue(""@{item.Name}"", {item.Name});
                else  
                    Command.Parameters.AddWithValue(""@{item.Name}"", DBNull.Value);
";
                    }
                    else
                    {
                        AddParameters += $"\t\t\tCommand.Parameters.AddWithValue(\"@{item.Name}\", {item.Name});\n";
                    }
                }
            }
            return AddParameters;
        }
        public static string GetUpdateMethodCode(string TableName, string Parameters)
        {
            string singularTableName = TableName.EndsWith("s") ? TableName.Remove(TableName.Length - 1) : TableName;

            // Generate SET clause for the update query
            var setColumns = clsGlobalClass._ColumnDetails
                .Where(col => !col.IsPrimaryKey)
                .Select(col => $"{col.Name} = @{col.Name}");

            string setClause = string.Join(", ", setColumns);

            string Content = $@"
        public static bool Update{singularTableName}({Parameters})
        {{
            int rowsAffected = 0;
            string query = @""UPDATE {TableName} 
                SET {setClause}
                WHERE {clsGlobalClass._PrimaryKeyColumn} = @{clsGlobalClass._PrimaryKeyColumn}"";

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(query, Connection))
            {{
                {GetAddParametersForUpdate()}
                
                try
                {{
                    Connection.Open();
                    rowsAffected = Command.ExecuteNonQuery();
                }}
                catch (Exception ex)
                {{
                    // Handle exception
                    return false;
                }}
            }}
            return (rowsAffected > 0);
        }}";

            return Content;
        }

        static string GetAddParametersForUpdate()
        {
            string AddParameters = "\n";
            foreach (var item in clsGlobalClass._ColumnDetails)
            {
                if (item.IsNullable)
                {
                    AddParameters += $@"      
                if ({item.Name} != null)
                    Command.Parameters.AddWithValue(""@{item.Name}"", {item.Name});
                else  
                    Command.Parameters.AddWithValue(""@{item.Name}"", DBNull.Value);
";
                }
                else
                {
                    AddParameters += $"\t\t\tCommand.Parameters.AddWithValue(\"@{item.Name}\", {item.Name});\n";
                }
            }
            return AddParameters;
        }

        /*        public static string GetUpdateMethodCode(string TableName, string Parameters)
                {

                    string Content = $@"
                    public static int Update{TableName.Remove(TableName.Length - 1)}({Parameters})
                    {{
                        int rowsAffected = 0;
                        string query = @"" Update {TableName}
                    {string.Join("\n\t\t\t\t\t\t", clsGlobalClass.ParametersAsArray
                    .Select((n, i) => $"{n} = @{n}" + (i < clsGlobalClass.ParametersAsArray.Length - 1 ? " ," : "")))}
                        where {TableName.Remove(TableName.Length - 1)} = @{TableName.Remove(TableName.Length - 1)};"";

                    using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    using(SqlCommand Command = new SqlCommand(query,Connection))
                    {{
                                {GetAddParameters()}
                        try
                        {{
                            Connection.Open();
                            rowsAffected = command.ExecuteNonQuery();

                        }}
                        catch (Exception)
                        {{
                            return false;
                            throw;
                        }}
                    }}
                return (rowsAffected >0 );
                    }}




        ";


                    return Content;
                }
        */
        public static string GetFindMethodCode(string TableName, string Parameters)
        {
            string singularTableName = TableName.EndsWith("s") ? TableName.Remove(TableName.Length - 1) : TableName;

            string Content = $@"
        public static bool Get{singularTableName}InfoBy{clsGlobalClass._PrimaryKeyColumn}(int {clsGlobalClass._PrimaryKeyColumn}, {GenerateRefParameters()})
        {{
            bool isFound = false;
            
            string query = @""SELECT {string.Join(", ", clsGlobalClass._ColumnDetails.Select(col => col.Name))} 
                            FROM {TableName} 
                            WHERE {clsGlobalClass._PrimaryKeyColumn} = @{clsGlobalClass._PrimaryKeyColumn}"";
            
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {{
                command.Parameters.AddWithValue(""@{clsGlobalClass._PrimaryKeyColumn}"", {clsGlobalClass._PrimaryKeyColumn});
                
                try
                {{
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {{
                        if (reader.Read())
                        {{
                            isFound = true;
                            {GenerateReaderAssignments()}
                        }}
                    }}
                }}
                catch (Exception ex)
                {{
                    // Handle exception
                }}
            }}
            
            return isFound;
        }}";

            return Content;
        }

        public static string GetGetAllMethodCode(string TableName)
        {
            string singularTableName = TableName.EndsWith("s") ? TableName.Remove(TableName.Length - 1) : TableName;

            string Content = $@"
        public static DataTable GetAll{singularTableName}s()
        {{
            DataTable dt = new DataTable();
            
            string query = @""SELECT {string.Join(", ", clsGlobalClass._ColumnDetails.Select(col => col.Name))} 
                            FROM {TableName}"";
            
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {{
                try
                {{
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {{
                        dt.Load(reader);
                    }}
                }}
                catch (Exception ex)
                {{
                    // Handle exception
                }}
            }}
            
            return dt;
        }}";

            return Content;
        }

        public static string GetIsExistsMethodCode(string TableName, string parameterName, string parameterType = "int")
        {
            string singularTableName = TableName.EndsWith("s") ? TableName.Remove(TableName.Length - 1) : TableName;

            string Content = $@"
        public static bool Is{singularTableName}Exist({parameterType} {parameterName})
        {{
            bool exists = false;
            
            string query = @""SELECT 1 FROM {TableName} WHERE {parameterName} = @{parameterName}"";
            
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {{
                command.Parameters.AddWithValue(""@{parameterName}"", {parameterName});
                
                try
                {{
                    connection.Open();
                    object result = command.ExecuteScalar();
                    exists = (result != null);
                }}
                catch (Exception ex)
                {{
                    // Handle exception
                }}
            }}
            
            return exists;
        }}";

            return Content;
        }

        private static string GenerateRefParameters()
        {
            List<string> parameters = new List<string>();
            List<clsRecordDetails> records = clsGlobalClass._ColumnDetails;

            foreach (clsRecordDetails record in records)
            {
                if (!record.IsPrimaryKey)
                {
                    parameters.Add($"ref {record.CSharpType} {record.Name}");
                }
            }

            return string.Join(", ", parameters);
        }

        private static string GenerateReaderAssignments()
        {
            StringBuilder assignments = new StringBuilder();
            List<clsRecordDetails> records = clsGlobalClass._ColumnDetails;

            foreach (clsRecordDetails record in records)
            {
                if (!record.IsPrimaryKey)
                {
                    assignments.AppendLine($"{record.Name} = ({record.CSharpType})reader[\"{record.Name}\"];");
                }
            }

            return assignments.ToString();
        }

    }
}
