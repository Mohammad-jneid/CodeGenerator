using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    public static class clsGlobalClass
    { 
            public static string GetDefaultValue(string csharpType)
            {
                switch (csharpType.ToLower())
                {
                    case "int": return "-1";
                    case "long": return "0L";
                    case "short": return "0";
                    case "byte": return "0";
                    case "bool": return "false";
                    case "decimal": return "0m";
                    case "double": return "0.0";
                    case "float": return "0f";
                    case "string": return "\"\"";
                    case "datetime": return "DateTime.MinValue";
                    case "timespan": return "TimeSpan.Zero";
                    case "guid": return "Guid.Empty";
                    case "byte[]": return "new byte[0]";
                    case "object": return "null";
                    default: return "null"; // fallback for unknown or reference types
                }
            }
        public static string ParametersAsArray ;
        public static string MapSqlToCSharpType(string sqlType, bool isNullable)
        {
            sqlType = sqlType.ToLowerInvariant();
            string type;

            switch (sqlType)
            {
                case "int": type = "int"; break;
                case "bigint": type = "long"; break;
                case "smallint": type = "short"; break;
                case "tinyint": type = "byte"; break;
                case "bit": type = "bool"; break;
                case "decimal":
                case "numeric":
                case "money":
                case "smallmoney":
                    type = "decimal"; break;
                case "float": type = "double"; break;
                case "real": type = "float"; break;
                case "datetime":
                case "smalldatetime":
                case "date":
                case "time":
                    type = "DateTime"; break;
                case "char":
                case "varchar":
                case "text":
                case "nchar":
                case "nvarchar":
                case "ntext":
                case "xml":
                    type = "string"; break;
                case "uniqueidentifier": type = "Guid"; break;
                case "binary":
                case "varbinary":
                case "image":
                case "timestamp":
                    type = "byte[]"; break;
                default: type = "object"; break;
            }

            return isNullable && type != "string" && type != "byte[]" ? $"{type}?" : type;
        }


        public static List<clsRecordDetails> _ColumnDetails = new List<clsRecordDetails>();
         
        
        public static string _PrimaryKeyColumn;

/*        public static string ConvertSqlTypeToCSharpType(string sqlType)
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
*/        }

    }