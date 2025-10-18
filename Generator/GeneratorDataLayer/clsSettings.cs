using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorDataLayer
{
    internal class clsSettings
    {
        public static string ConnectionString(string DataBaseName = "Master")
        {
            return $"Server=.;Database={DataBaseName};User Id=sa;Password=123456;";
        }
    }
}
