using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Logic.Entities;
using ComboBox = System.Windows.Controls.ComboBox;
using ListView = System.Windows.Controls.ListView;

namespace Logic.Repositories
{
    internal interface IRepository<T> where T : IEntity
    {
        void Save(T items, string path);
        T Load(string path);
        void Update(string xmlFile, string chooseNode, string chooseSingleNode, string selectedCategory, string elementToCreate, string newNode);
        void Delete(T item);
        void RemoveData(string selectedFeed, string path, string selectedNodeToRemove, string selectedElement);

        void SelectSingleItemInFeed(ListView lv, string xmlFile, string chooseFirstDesc, string chooseNextDesc,
            string selectedListItem, string compareWithNode, string selectNode);

        void FillListView(ListView lv, string xmlFil, string valjNoder, string singleNodeFill);
        void FillComboBox(ComboBox cb, string xmlFil, string valjNoder, string valjEnstakaNodAttFyllaBoxMed);
        void UpdateFeed(string path, string selectedFeed, string newName, string newUrl, string newCategory);
        T Add(T item);
        T Find(Guid id);
        void GetAll();
    }
}