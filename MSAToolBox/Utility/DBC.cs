using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSAToolBox.Utility
{
    class DBC
    {
        public static void WriteDBCHeader(BinaryWriter w, int records, int fields, int rowSize, int stringBlockSize = 0)
        {
            w.Write(0x43424457);
            w.Write(records);
            w.Write(fields);
            w.Write(rowSize);
            w.Write(stringBlockSize);
        }
    }
}
