using DomainModels;
using Services.DTO;
using System;
using System.Collections.Generic;

namespace Services
{
    public class ItemService: IItemService
    {
        //todo
        //ItemService should use IItemRepository appropriately.
        private IItemService _service;
        
        public IEnumerable<ItemDTO> GetAll()
        {
            return _service.GetAll();
        }
        public ItemDTO Get(int itemId)
        {
            return _service.Get(itemId);
        }
        public IEnumerable<ItemDTO> GetAllByFilter(ItemByFilterDTO filters)
        {
            return _service.GetAllByFilter(filters);
        }
        
        public void Add(ItemDTO itemDto)
        {
            var item = new Item(itemDto.Text);
            Console.Write("save " + item);

            _service.Add(itemDto);
        }

        public void Update(ItemDTO itemDto)
        {
            var item = new Item(itemDto.Text);
            Console.Write("update " + item);

            _service.Update(itemDto);
        }

        public void Delete(int id)
        {
            Console.Write("delete " + id);

            _service.Delete(id);
        }
    }
}
