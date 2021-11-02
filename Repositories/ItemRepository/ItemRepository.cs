using ASPNetCoreMastersTodoList.Api.Data;
using DomainModels;
using System;
using System.Linq;

namespace Repositories
{
    public class ItemRepository : IItemRepository
    {
        private DotNetCoreMastersDbContext _dataContext;
        public ItemRepository(DotNetCoreMastersDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<Item> All()
        {
            return _dataContext.Item.AsQueryable<Item>();
        }

        public void Delete(int id)
        {
            var record = _dataContext.Item
                .FirstOrDefault(_ => _.Id == id);

            _dataContext.Item.Remove(record);
        }

        public void Save(Item item)
        {
            try
            {
                if (item == null)
                    return;

                if (item.Id == default)
                {
                    //create
                    _dataContext.Item.Add(item);
                }
                else
                {
                    var record = _dataContext.Item
                        .FirstOrDefault(_ => _.Id == item.Id);

                    if (record == null)
                    {
                        //create
                        _dataContext.Item.Add(item);
                    }
                    else
                    {
                        //update
                        record.Title = item.Title;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
