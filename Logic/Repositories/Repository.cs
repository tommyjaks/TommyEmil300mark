using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Data;
using Logic.Entities;
using ComboBox = System.Windows.Controls.ComboBox;
using ListView = System.Windows.Controls.ListView;

namespace Logic.Repositories
{
 
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        internal XmlHandler<T> XmlHandler = new XmlHandler<T>();  

        public void Save(T value, string path)
        {
            try
            {
               XmlHandler.SaveXml(value, path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public T Load(string path)
        {
           return XmlHandler.Load(path);
        }
        public void Update(string xmlFile, string chooseNode, string chooseSingleNode, string selectedCategory,string elementToCreate, string newNode)
        {
            XmlHandler.updateXML(xmlFile, chooseNode, chooseSingleNode, selectedCategory,elementToCreate, newNode);
            
         
        }

        public void UpdateFeed(string path, string selectedFeed, string newName, string newUrl, string interval, string newCategory)
        {
            XmlHandler.updateFeed(path, selectedFeed, newName, newUrl, interval, newCategory);
        }

        public void Delete(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveData(string selectedFeed, string path, string selectedNodeToRemove, string selectedElement)
        {
            XmlHandler.RemoveData(selectedFeed, path, selectedNodeToRemove, selectedElement);
        }
        public string SelectSingleItemInFeed(string xmlFile, string chooseFirstDesc, string selectedListItem, string compareWithNode, string selectNode)
        {
           var load =  XmlHandler.SelectSingleFeedItem(xmlFile, chooseFirstDesc, selectedListItem, compareWithNode, selectNode);
            return load;
        }

        public void SelectMultipleFeedNames(ListView lv, string xmlFile, string selectNodes, string singleNodeToCompare,
            string selectedItem, string singleNode)
        {
            XmlHandler.SelectMultipleFeedNames(lv,xmlFile,selectNodes,singleNodeToCompare,selectedItem,singleNode);
        }
        public string SelectMultiplePlace(string xmlFile, string selectNodes, string singleNodeToCompare,
          string selectedItem)
        {
            var load = XmlHandler.SelectMultiplePlace(xmlFile, selectNodes, singleNodeToCompare, selectedItem);
            return load;
        }
        public void Play(string xmlFile, string chooseFirstDesc, string selectedListItem, string compareWithNode, string selectNode)
        {
            XmlHandler.Play(xmlFile, chooseFirstDesc, selectedListItem, compareWithNode, selectNode);
        }

        public void EditSingleNode(string xml, string desc, string selectNodeToCompare, string selectItem, string nodeToUpdate,
            string status)
        {
            XmlHandler.EditSingleNode(xml, desc, selectNodeToCompare, selectItem, nodeToUpdate, status);
        }

        public T Add(T item)
        {
            throw new NotImplementedException();
        }

        public T Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            //YoloHandler.Load("hej.xml");
            
        }

        public void FillSomething(ComboBox cb, string xmlFil, string valjNoder, string valjEnstakaNodAttFyllaBoxMed)
        {
            XmlHandler.FillSomething(cb,  xmlFil, valjNoder, valjEnstakaNodAttFyllaBoxMed);
        }
        public void FillSomething(ListView lv, string xmlFil, string valjNoder, string singleNodeFill)
        {
            XmlHandler.FillSomething(lv, xmlFil, valjNoder, singleNodeFill);
        }

      



       
    }


}
