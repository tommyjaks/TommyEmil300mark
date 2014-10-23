using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Logic.Entities;

namespace Logic.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected XmlHandler<T> yoloHandler = new XmlHandler<T>();  
        public void Save()
        {
            try
            {


            }
            catch (Exception)
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

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
