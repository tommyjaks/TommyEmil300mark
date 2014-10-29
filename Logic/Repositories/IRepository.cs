using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Logic.Entities;
using ComboBox = System.Windows.Controls.ComboBox;

namespace Logic.Repositories
{
    internal interface IRepository<T> where T : IEntity
    {
        void Save(T items, string path);
        T Load(string path);
        void Update(string xmlFile, string chooseNode, string chooseSingleNode, string selectedCategory, string elementToCreate, string newNode);
        void Delete(T item);
        void fillComboBox(ComboBox cb, string xmlFil, string valjNoder, string valjEnstakaNodAttFyllaBoxMed);
        T Add(T item);
        T Find(Guid id);
        void GetAll();
    }
}