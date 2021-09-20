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

        public IEnumerable<string> GetAll(int userId)
        {
            // no requirements on what to do on the userId
            return Items;
        }


        public void Save(ItemDTO itemObject)
        {
            Console.Write(itemObject);

            // do something to itemObject
        }
    }
}
