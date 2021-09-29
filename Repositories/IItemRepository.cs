using DomainModels;
using System.Linq;

namespace Repositories
{
    public interface IItemRepository
    {
        public IQueryable<Item> All();
        public void Save(Item item);
        public void Delete(int id);
    }
}
