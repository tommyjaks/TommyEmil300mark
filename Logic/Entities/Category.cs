﻿using System;

namespace Logic.Entities
{
    public class Category : IEntity
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
    }
}
