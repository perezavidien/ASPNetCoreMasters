using Services.DTO;
using System;
using System.Collections.Generic;

namespace Services
{
    public class ItemService
    {
        private static readonly string[] Items = new[]
        {
            "One", "Two", "Three"
        };

        public IEnumerable<string> GetAll()
        {
            return Items;
        }


        public void Save(ItemDTO text) // todo
        {
            // ?
        }
        public void Save()
        {
            // ?
        }
    }
}
