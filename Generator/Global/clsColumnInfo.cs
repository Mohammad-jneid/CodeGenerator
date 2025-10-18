using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    public class clsRecordDetails
    {

        public string Name { get; set; }
        public string DataType { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool YouWantToFindBy { get; set; }
        public bool IsNullable { get; set; }
        public int OrdinalPosition { get; set; }
        public string CSharpType { get; set; }
    }
}