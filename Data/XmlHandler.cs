using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;



namespace Data
{
    public class XmlHandler
    {
        internal string Sökväg;
        internal XmlSerializer Xml;
        

        public XmlHandler(string sökväg)
        {
            Sökväg = sökväg;
            Xml = new XmlSerializer(typeof(feedItem));
        }

        public T LoadData<T>()
        {
           XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
           using (TextReader reader = new StreamReader(settingsFileName))
           {
            return (T)xmlSerializer.Deserialize(reader);
           }
        
        }

        public void Spara(Bibliotek b)
        {
            using (var sw = new StreamWriter(Sökväg))
            {
                Xml.Serialize(sw, b );
            }
        }

        public Bibliotek Ladda()
        {
            if (!File.Exists(Sökväg))
            {
                return new Bibliotek();
            }
            //Xml = new XmlSerializer(b.GetType());
            using (var sr = new StreamReader(Sökväg))
            {
                return Xml.Deserialize(sr) as Bibliotek;// deserialize skickar tillbaka som objekt, därför skriver man bibliotek
            }
    }
}
