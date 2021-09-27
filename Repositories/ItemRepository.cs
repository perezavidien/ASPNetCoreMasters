using DomainModels;
using System;
using System.Linq;

namespace Repositories
{
    public class ItemRepository : IItemRepository
    {
        private DataContext _dataContext;
        public ItemRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<Item> All()
        {
            return _dataContext.Items.AsQueryable<Item>();
        }

        public void Delete(int id)
        {
            var record = _dataContext.Items.Find(_ => _.Id == id);

            _dataContext.Items.Remove(record);
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
                    _dataContext.Items.Add(item);
                }
                else
                {
                    var record = _dataContext.Items.Find(_ => _.Id == item.Id);

                    if (record == null)
                    {
                        //create
                        _dataContext.Items.Add(item);
                    }
                    else
                    {
                        //update
                        record.Text = item.Text;
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
