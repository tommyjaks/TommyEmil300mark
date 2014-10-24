using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Logic.Entities;

namespace Logic.Repositories
{
    public class FeedRepository : Repository<Feed>
    {
        public void Hej()
        {
            GetAll().Where(b => b.Items);
        }   
    }
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected XmlHandler<T> yoloHandler = new XmlHandler<T>();  
        public void Save(List<T> value)
        {
            try
            {
               yoloHandler.SaveXml(value,"hej.xml");
            }
            catch (Exception ex)
            {

                throw new NotImplementedException();
            }
            
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
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

        public IEnumerable<T> GetAll()
        {
            yoloHandler.Load("hej.xml");
            
        }
    }


}
