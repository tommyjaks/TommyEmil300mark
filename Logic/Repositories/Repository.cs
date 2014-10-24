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
        protected XmlHandler<T> XmlHandler = new XmlHandler<T>();

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

        public IEnumerable<T> GetAll()
        {
            // Don't really know what to return in order to make it work
            return null; 
        }
    }


}
