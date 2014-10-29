using System;
using System.Collections.Generic;
using Logic.Entities;

namespace Logic.Readers
{
    public interface IReader
    {
        List<FeedItem> Read(string url, string name, string category);
        
    }
}