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
        protected XmlHandler<T> DataTable;

        public void Save()
        {
            try
            {
                XmlHandler<T>.SaveXml(T value,"hej.xml");
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
            throw new NotImplementedException();
        }
    }
}
