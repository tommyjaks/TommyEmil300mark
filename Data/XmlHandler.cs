using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;




namespace Data
{
    public class XmlHandler<T> where T : class 
    {
       
        internal XmlSerializer Xml;

        public XmlHandler()
        {
           
            Xml = new XmlSerializer(typeof (List<T>));
        }

        public void SaveXml(List<T> datatyp, string path)
        {
            using (var streamWriter = new StreamWriter(path))
            {
                Xml.Serialize(streamWriter, datatyp);
            }
        }

        public List<T> Load(string path)
        {
            using (var streamReader = new StreamReader(path))
            {
                return Xml.Deserialize(streamReader) as List<T>;
            }
        }


        public void FyllCombobox(ComboBox cb, string xmlFil, string valjNoder, string valjEnstakaNodAttFyllaBoxMed)
        {

            var doc = new XmlDocument();
            doc.Load(xmlFil);
            var nodeList = doc.SelectNodes(valjNoder);

            foreach (XmlNode node in nodeList)
                if (!cb.Items.Contains(node.SelectSingleNode(valjEnstakaNodAttFyllaBoxMed).InnerText))
                {
                    cb.Items.Add(node.SelectSingleNode(valjEnstakaNodAttFyllaBoxMed).InnerText);
                }

        }

        public void updateXML(string xmlFile, string chooseNode, string chooseSingleNode, string selectedCategory,string elementToCreate, string newNode)
        {
            
            
                XmlDocument xml = new XmlDocument();

                xml.Load(xmlFile);

                foreach (XmlElement element in xml.SelectNodes(chooseNode))
                {
                    foreach (XmlElement element1 in element)
                    {
                        if (element.SelectSingleNode(chooseSingleNode).InnerText == selectedCategory)
                        {

                            XmlNode newvalue = xml.CreateElement(elementToCreate);
                            newvalue.InnerText = newNode;
                            element.ReplaceChild(newvalue, element1.NextSibling);
                            xml.Save(xmlFile);
                           
                        }
                        xml.Save(xmlFile);
                    }
                }
              
            }

        public void deleteCategory(string xmlFile)
        {
           // deleteKod Inc Y0
           
        }
            
        }

        }



      
    


