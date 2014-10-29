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
        protected XmlHandler<T> YoloHandler = new XmlHandler<T>();  

        public void Save(T value, string path)
        {
            try
            {
               YoloHandler.SaveXml(value, path);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public T Load(string path)
        {
           return YoloHandler.Load(path);
        }
        public void Update(string xmlFile, string chooseNode, string chooseSingleNode, string selectedCategory,string elementToCreate, string newNode)
        {
            YoloHandler.updateXML(xmlFile, chooseNode, chooseSingleNode, selectedCategory,elementToCreate, newNode);
            
         
        }

        public void Delete(T item)
        {
            throw new NotImplementedException();
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

        public void fillComboBox(ComboBox cb, string xmlFil, string valjNoder, string valjEnstakaNodAttFyllaBoxMed)
        {
            YoloHandler.FyllCombobox(cb,  xmlFil, valjNoder, valjEnstakaNodAttFyllaBoxMed);
        }




        internal void Save(ListOfCategories createCategories, string xmlFilPathpath)
        {
            throw new NotImplementedException();
        }
    }


}
