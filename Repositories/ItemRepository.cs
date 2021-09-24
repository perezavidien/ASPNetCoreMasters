using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    class ItemRepository : IItemRepository
    {
        //todo
        //ItemRepository should use DataContext appropriately.
        public IQueryable<Item> All()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
