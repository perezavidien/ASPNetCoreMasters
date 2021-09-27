using DomainModels;
using Services.DTO;
using System;
using System.Collections.Generic;

namespace Services
{
    public class ItemService
    {
        //todo return list of <str, str> objects
        private static readonly string[] Items = new[]
        {
            "One", "Two", "Three"
        };

        public IEnumerable<string> GetAll()
        {
            return Items;
        }
        public IEnumerable<string> GetById(int userId)
        {
            //todo
            return Items;
        }
        public IEnumerable<string> GetByFilters(Dictionary<string, string> filters)
        {
            //todo
            return Items;
        }
        
        //todo
        public void Save(ItemDTO itemDto)
        {
            var item = new Item(itemDto.Text);
            Console.Write("save " + item);

            // do something to item
        }

        //todo
        public void Update(int id, ItemDTO itemDto)
        {
            var item = new Item(itemDto.Text);
            Console.Write("update " + id);
            Console.Write("update " + item);

            // do something to item
        }

        //todo
        public void Delete(int id)
        {
            Console.Write("delete " + id);

            // do something to item
        }
    }
}
