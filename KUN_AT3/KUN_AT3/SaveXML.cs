using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace KUN_AT3
{
    public class SaveXML
    {
        public static void SaveData(string filename, object obj)
        {
            TextWriter writer = new StreamWriter(filename);
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            sr.Serialize(writer, obj);
            writer.Close();
        }
    }
}
