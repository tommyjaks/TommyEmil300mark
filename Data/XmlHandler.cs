﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

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
        public void FillSomething(ListView lv, string xmlFil, string valjNoder, string singleNodeFill)
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load(xmlFil);
                var nodeList = doc.SelectNodes(valjNoder);

                foreach (XmlNode node in nodeList)
                    if (!lv.Items.Contains(node.SelectSingleNode(singleNodeFill).InnerText))
                    {
                        lv.Items.Add(node.SelectSingleNode(singleNodeFill).InnerText);
                    }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void FillSomething(ComboBox cb, string xmlFil, string valjNoder, string valjEnstakaNodAttFyllaBoxMed)
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
        public void updateFeed(string path, string selectedFeed, string newName, string  newUrl, string newUpdateInterval, string newCategory)
        {
            var doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList selectedNodes = doc.SelectNodes("ListOfFeeds/FeedList/Feed");

            foreach (XmlNode node in selectedNodes)
            {

                if (node.SelectSingleNode("Namn").InnerText == selectedFeed)
                {
                    XmlNode feedName = node.SelectSingleNode("Namn");
                    XmlNode feedUrl = node.SelectSingleNode("Url");
                    XmlNode feedUpdateInterval = node.SelectSingleNode("UppdateInterval");
                    XmlNode feedSelectedCategory = node.SelectSingleNode("Category");
                    feedUrl.InnerText = newUrl;
                    feedSelectedCategory.InnerText = newCategory;
                    feedName.InnerText = newName;
                    feedUpdateInterval.InnerText = newUpdateInterval;
                    
               
                
                    doc.Save(path);
                }
            }

        }

        public void RemoveData(string selectedFeed, string path, string selectedNodeToRemove, string selectedElement)
        {

            XDocument doc = XDocument.Load(path);
            var q = from node in doc.Descendants(selectedNodeToRemove)
                    let attr = node.Element(selectedElement)
                    where attr != null && attr.Value == selectedFeed
                    select node;
            q.ToList().ForEach(b => b.Remove());
            doc.Save(path);

            

        }


        

        public string SelectSingleFeedItem(string xmlFile, string chooseFirstDesc, string selectedListItem, string compareWithNode, string selectNode)
        {
            
            XDocument doc = XDocument.Load(xmlFile);
            var values = doc.Descendants(chooseFirstDesc)

                        .Where(i => i.Element(compareWithNode).Value == selectedListItem)
                        .Select(i => i.Element(selectNode).Value)
                        .Single();

            return values;
        }

        public void SelectMultipleFeedNames(ListView lv, string xmlFile,string selectNodes, string singleNodeToCompare, string selectedItem, string singleNode )
        {
            
            var doc = new XmlDocument();
            doc.Load(xmlFile);

            XmlNodeList selectedNodes = doc.SelectNodes(selectNodes);

            foreach (XmlNode node in selectedNodes)
            {
                if (node.SelectSingleNode(singleNodeToCompare).InnerText == selectedItem)
                {
                    XmlNode feedItem = node.SelectSingleNode(singleNode);
                    for (int i = 0; i < feedItem.ChildNodes.Count; i++)
                    {
                        lv.Items.Add(feedItem.ChildNodes.Item(i).ChildNodes[1].InnerText);
                    }
                }
            }
        }

        public string SelectMultiplePlace(string xmlFile, string selectNodes, string singleNodeToCompare, string selectedItem)
        {

            var doc = new XmlDocument();
            doc.Load(xmlFile);
            var load = "";
            XmlNodeList selectedNodes = doc.SelectNodes(selectNodes);

            foreach (XmlElement node in selectedNodes)
            {
                if (node.SelectSingleNode(singleNodeToCompare).InnerText == selectedItem)
                {
  
                       load += (node.SelectSingleNode("Namn").InnerText);
                }
            }
            return load;
        }
        public void Play(string xmlFile, string chooseFirstDesc, string selectedListItem, string compareWithNode, string selectNode)
        {
            XDocument doc = XDocument.Load(xmlFile);
            var values = doc.Descendants(chooseFirstDesc)

                        .Where(i => i.Element(compareWithNode).Value == selectedListItem)
                        .Select(i => i.Element(selectNode).Value)
                        .Single();

            Process.Start("wmplayer.exe", values);
        }

        public void EditSingleNode(string xml, string desc, string selectNodeToCompare, string selectItem, string nodeToUpdate, string status)
        {
            XDocument xmlDoc = XDocument.Load(xml);
          
                var items = (from item in xmlDoc.Descendants(desc)
                    where item.Element(selectNodeToCompare).Value == selectItem
                    select item).ToList();

                foreach (XElement itemElement in items)
                {
                    itemElement.SetElementValue(nodeToUpdate, status);
                }
             xmlDoc.Save(xml);
            
        }

            
        }

        }



      
    


