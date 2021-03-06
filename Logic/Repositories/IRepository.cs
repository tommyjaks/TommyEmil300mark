﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Logic.Entities;
using ComboBox = System.Windows.Controls.ComboBox;
using ListView = System.Windows.Controls.ListView;

namespace Logic.Repositories
{
    internal interface IRepository<T> where T : IEntity
    {
        void Save(List<T> items, string path);
        List<T> Load(string path);
        void Update(string xmlFile, string chooseNode, string chooseSingleNode, string selectedCategory, string elementToCreate, string newNode);
        void Delete(T item);
        void RemoveData(string selectedFeed, string path, string selectedNodeToRemove, string selectedElement);

        string SelectSingleItemInFeed(string xmlFile, string chooseFirstDesc,
            string selectedListItem, string compareWithNode, string selectNode);

        void Play(string xmlFile, string chooseFirstDesc, string selectedListItem, string compareWithNode,
            string selectNode);

        void SelectMultipleFeedNames(ListView lv, string xmlFile, string selectNodes, string singleNodeToCompare,
            string selectedItem, string singleNode);
        string SelectMultiplePlace(string xmlFile, string selectNodes, string singleNodeToCompare,
            string selectedItem);

        void EditSingleNode(string xml, string desc, string selectNodeToCompare, string selectItem, string nodeToUpdate,
            string status);

        void FillSomething(ListView lv, string xmlFil, string valjNoder, string singleNodeFill);
        void FillSomething(ComboBox cb, string xmlFil, string valjNoder, string valjEnstakaNodAttFyllaBoxMed);
        void UpdateFeed(string path, string selectedFeed, string newName, string newUrl,string interval, string newCategory);
        T Add(T item);
        T Find(Guid id);
        void GetAll();
    }
}