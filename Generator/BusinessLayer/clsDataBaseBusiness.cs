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

        public static List<clsRecordDetails> GetColomnInfoDetails(string DataBaseName , string TableName)
        {
            return clsDataBaseData.GetColomnInfoDetails(DataBaseName, TableName);
        }
        public static List<string> GetTableOfSomeDataBase(string DataBaseName)
        {
            return clsDataBaseData.GetTableOfSomeDataBase(DataBaseName);
        }
    }
}
