using Generator;
using GeneratorDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsDataBaseBusiness
    {
        public static DataTable LoadDataBasesToDataTable()
        {
            return clsDataBaseData.LoadDataBasesToDataTable();
        }

        public static void LoadColomnInfoDetails(string DataBaseName, string TableName)
        {
            clsDataBaseData.LoadColomnInfoDetails(DataBaseName, TableName);
        }

        public static async Task<List<string>> GetTableOfSomeDataBaseAsync(string DataBaseName)
        {
            return await clsDataBaseData.GetTableOfSomeDataBaseAsync(DataBaseName);
        }

        public static DataTable LoadTablesToDataTable(string DataBaseName)
        {
            return clsDataBaseData.LoadTablesToDataTable(DataBaseName);
        }

        // Synchronous version for backward compatibility
        public static List<string> GetTableOfSomeDataBase(string DataBaseName)
        {
            return clsDataBaseData.GetTableOfSomeDataBase(DataBaseName);
        }
    }
}

/*using Generator;
using GeneratorDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
                 
    public class clsDataBaseBusiness 
    {
        public static DataTable LoadDataBasesToDataTable()
        {
            return clsDataBaseData.LoadDataBasesToDataTable();
        }

        public static void LoadColomnInfoDetails(string DataBaseName , string TableName)
        {
            clsDataBaseData.LoadColomnInfoDetails(DataBaseName, TableName);
        }
        public static async Task< List<string>> GetTableOfSomeDataBase(string DataBaseName)
        {
            return clsDataBaseData.GetTableOfSomeDataBase(DataBaseName);
        }
        public static DataTable LoadTablesToDataTable(string DataBaseName)
        {
            return clsDataBaseData.LoadTablesToDataTable(DataBaseName);
        }
        
    }
}
*/