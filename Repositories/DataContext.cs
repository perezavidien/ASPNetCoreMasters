using DomainModels;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public class DataContext
    {
        public List<Item> Items { get; set; }

        public DataContext()
        {
            Items = new List<Item>();
            Items.Add(new Item(1, "testing"));
            Items.Add(new Item(2, "something else"));
        }
}
}
