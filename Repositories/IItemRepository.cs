using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    //todo
    //uses the DataContext 
    interface IItemRepository
    {
        IQueryable<Item> All();
        void Save(Item item);
        void Delete(int id);
    }
}
