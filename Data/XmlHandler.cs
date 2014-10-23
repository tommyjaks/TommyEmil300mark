﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;



namespace Data
{
    public class XmlHandler<T> where T : class
    {
        //internal string Sökväg;
        internal XmlSerializer Xml;

        public XmlHandler()
        {
            //Sökväg = sökväg;
            Xml = new XmlSerializer(typeof (T));
        }

        public void Spara(T datatype, string path)
        {
            using (var streamWriter = new StreamWriter(path))
            {
                Xml.Serialize(streamWriter, datatype);
            }
        }

        public T Load(string path)
        {
            // if (!File.Exists(path))
            //{
            //  return new Bibliotek();
            //}
            //Xml = new XmlSerializer(b.GetType());

            using (var streamReader = new StreamReader(path))
            {
                return Xml.Deserialize(streamReader) as T;
            }
        }
    }
}
