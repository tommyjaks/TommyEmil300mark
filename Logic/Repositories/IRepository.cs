using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Logic.Entities;
using ComboBox = System.Windows.Controls.ComboBox;

namespace Logic.Repositories
{
    internal interface IRepository<T> where T : IEntity
    {
        void Save(List<T> items, string path);
        void Load(string path);
        void Update(T item);
        void Delete(T item);
        void fillComboBox(ComboBox cb, string xmlFil, string valjNoder, string valjEnstakaNodAttFyllaBoxMed);
        T Add(T item);
        T Find(Guid id);
        void GetAll();
    }
}