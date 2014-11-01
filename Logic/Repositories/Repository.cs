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
    ////public class FeedRepository : Repository<Feed>
    //{
    //    public void GetFeed()
    //    {
    //        GetAll().Where(b => b.Items != null);
    //    }   
    //}
    
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected XmlHandler<T> XmlHandler = new XmlHandler<T>();  

        public void Save(T value, string path)
        {
            try
            {
               XmlHandler.SaveXml(value, path);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
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

        public void UpdateFeed(string path, string selectedFeed, string newName, string newUrl, string newCategory)
        {
            XmlHandler.updateFeed(path, selectedFeed, newName, newUrl, newCategory);
        }

        public void Delete(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveData(string selectedFeed, string path, string selectedNodeToRemove, string selectedElement)
        {
            XmlHandler.RemoveData(selectedFeed, path, selectedNodeToRemove, selectedElement);
        }
        public void SelectSingleItemInFeed(ListView lv, string xmlFile, string chooseFirstDesc, string chooseNextDesc, string selectedListItem, string compareWithNode, string selectNode)
        {
            XmlHandler.SelectSingleFeedItem(lv, xmlFile, chooseFirstDesc, chooseNextDesc, selectedListItem, compareWithNode, selectNode);
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

        public void FillComboBox(ComboBox cb, string xmlFil, string valjNoder, string valjEnstakaNodAttFyllaBoxMed)
        {
            XmlHandler.FyllCombobox(cb,  xmlFil, valjNoder, valjEnstakaNodAttFyllaBoxMed);
        }
        public void FillListView(ListView lv, string xmlFil, string valjNoder, string singleNodeFill)
        {
            XmlHandler.FyllListView(lv, xmlFil, valjNoder, singleNodeFill);
        }

      



       
    }


}
