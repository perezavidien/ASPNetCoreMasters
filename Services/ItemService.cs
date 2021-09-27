using DomainModels;
using Repositories;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ItemService : IItemService
    {
        private IItemRepository _repository;

        public ItemService(IItemRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ItemDTO> GetAll()
        {
            return _repository.All()
                .Select(_ => new ItemDTO { Id = _.Id, Text = _.Text });
        }
        public ItemDTO Get(int itemId)
        {
            var record = _repository.All().FirstOrDefault(_ => _.Id == itemId);
            if (record == null)
                return null;
                //else
                //{
                //    throw;
                //}

            return new ItemDTO { Id = record.Id, Text = record.Text };
        }
        public IEnumerable<ItemDTO> GetAllByFilter(ItemByFilterDTO filters)
        {
            return _repository.All().Where(_ => _.Text == filters.Text)
                .Select(_ => new ItemDTO { Id = _.Id, Text = _.Text });
        }

        public void Add(ItemDTO itemDto)
        {
            var record = new Item(itemDto.Text);
            _repository.Save(record);
        }

        public void Update(ItemDTO itemDto)
        {
            var record = _repository.All().FirstOrDefault(_ => _.Id == itemDto.Id);
            if (record != null)
                _repository.Save(record);

            //else
            //{
            //    throw;
            //}
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
