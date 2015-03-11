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

        public static void WriteString(BinaryWriter w, string s, ref int ofs, ref List<string> stringBlock, int skip = 0, int jump = 0)
        {
            for (int i = 0; i != skip; i++)
                w.Write(0);
            if (s == null || s == "")
                w.Write(0);
            else
            {
                w.Write(ofs);
                stringBlock.Add(s);
                ofs += Encoding.UTF8.GetBytes(s + "\0").Length;
            }
            for (int i = 0; i != jump; i++)
                w.Write(0);
        }

        public static string ReadString(BinaryReader r, int ofs, int skip = 0, int jump = 0)
        {
            r.BaseStream.Position += skip;
            int pos = r.ReadInt32();
            long rec = r.BaseStream.Position;
            r.BaseStream.Position = pos + ofs;
            string s = "";
            List<byte> blist = new List<byte>();
            while (true)
            {
                byte b = r.ReadByte();
                if (b == 0)
                    break;
                blist.Add(b);
            }
            if (blist.Count != 0)
            {
                byte[] stringBytes = new byte[blist.Count];
                for (int j = 0; j != blist.Count; ++j)
                    stringBytes[j] = blist[j];
                s = Encoding.UTF8.GetString(stringBytes);
            }
            r.BaseStream.Position = rec + jump;
            return s;
        }

        public static void WriteZeros(BinaryWriter w, int count)
        {
            if (count < 0) return;
            for (int i = 0; i != count; ++i)
                w.Write(0);
        }
    }
}
