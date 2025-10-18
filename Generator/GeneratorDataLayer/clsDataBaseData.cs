using Generator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorDataLayer
{
    public class clsDataBaseData
    {
        public static string ConvertSqlTypeToCSharpType(string sqlType)
        {
            switch (sqlType.ToLower())
            {
                case "int": return "int";
                case "bigint": return "long";
                case "smallint": return "short";
                case "tinyint": return "byte";
                case "bit": return "bool";
                case "decimal":
                case "numeric":
                case "money":
                case "smallmoney": return "decimal";
                case "float": return "double";
                case "real": return "float";
                case "char":
                case "varchar":
                case "text":
                case "nchar":
                case "nvarchar":
                case "ntext": return "string";
                case "date":
                case "datetime":
                case "datetime2":
                case "smalldatetime":
                case "datetimeoffset": return "DateTime";
                case "time": return "TimeSpan";
                case "binary":
                case "varbinary":
                case "image": return "byte[]";
                case "uniqueidentifier": return "Guid";
                case "sql_variant": return "object";
                default: return "string"; // fallback for unknown types
            }
        }

        public static DataTable LoadDataBasesToDataTable()
        {
            DataTable databasesTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsSettings.ConnectionString()))
                {
                    connection.Open();

                    string query = "SELECT name AS DatabaseName FROM sys.databases";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            databasesTable.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading databases: " + ex.Message);
            }

            return databasesTable;
        }

        public static List<string> GetTableOfSomeDataBase(string databaseName)
        {
            List<string> tables = new List<string>();

            try
            {
                string connectionString = clsSettings.ConnectionString(databaseName);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT TABLE_SCHEMA, TABLE_NAME 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_TYPE = 'BASE TABLE'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string table = reader["TABLE_NAME"].ToString();
                            tables.Add($"{table}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {                                       
                //Console.WriteLine("Error retrieving tables: " + ex.Message);
            }

            return tables;
        }
        public static List<clsRecordDetails> GetColomnInfoDetails(string databaseName, string tableName)
        {
            List<clsRecordDetails> records = new List<clsRecordDetails>();

            try
            {
                string connectionString = clsSettings.ConnectionString(databaseName);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $@"
                SELECT 
                    c.COLUMN_NAME AS Name,
                    c.DATA_TYPE AS DataType,
                    c.IS_NULLABLE,
                    c.ORDINAL_POSITION,
                    CASE WHEN k.COLUMN_NAME IS NOT NULL THEN 1 ELSE 0 END AS IsPrimaryKey
                FROM INFORMATION_SCHEMA.COLUMNS c
                LEFT JOIN (
                    SELECT COLUMN_NAME 
                    FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE 
                    WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1
                          AND TABLE_NAME = @TableName
                ) k ON c.COLUMN_NAME = k.COLUMN_NAME
                WHERE c.TABLE_NAME = @TableName
                ORDER BY c.ORDINAL_POSITION";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TableName", tableName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string sqlType = reader["DataType"].ToString();
                                string csharpType = clsGlobalClass.MapSqlToCSharpType(sqlType, reader["IS_NULLABLE"].ToString() == "YES");

                                clsRecordDetails record = new clsRecordDetails
                                {
                                    Name = reader["Name"].ToString(),
                                    DataType = sqlType,
                                    IsNullable = reader["IS_NULLABLE"].ToString() == "YES",
                                    OrdinalPosition = Convert.ToInt32(reader["ORDINAL_POSITION"]),
                                    IsPrimaryKey = Convert.ToBoolean(reader["IsPrimaryKey"]),
                                    CSharpType = csharpType,
                                    YouWantToFindBy = false

                                };

                                records.Add(record);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving column info: " + ex.Message);
            }

            return records;
        }


    }

}


