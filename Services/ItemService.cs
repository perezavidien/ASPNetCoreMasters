using DomainModels;
using Microsoft.AspNetCore.Identity;
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
                .Select(_ =>
                new ItemDTO
                {
                    Id = _.Id,
                    Title = _.Title,
                    ShortDescription = _.ShortDescription,
                    DateCreated = _.DateCreated,
                    CreatedBy = _.CreatedBy
                });
        }
        public ItemDTO Get(int itemId)
        {
            var record = _repository.All().FirstOrDefault(_ => _.Id == itemId);

            if (record == null)
                return null; // does not exist

            return new ItemDTO
            {
                Id = record.Id,
                Title = record.Title,
                ShortDescription = record.ShortDescription,
                DateCreated = record.DateCreated,
                CreatedBy = record.CreatedBy
            };
        }
        public IEnumerable<ItemDTO> GetAllByFilter(ItemByFilterDTO filters)
        {
            return _repository.All().Where(_ => _.Title == filters.Text)
                .Select(_ => new ItemDTO { Id = _.Id, Title = _.Title });
        }

        public void Add(ItemDTO itemDto, IdentityUser user)
        {
            _repository.Save(new Item
            {
                Title = itemDto.Title,
                ShortDescription = itemDto.ShortDescription,
                CreatedBy = user.Id,
                DateCreated = DateTime.UtcNow
            });
        }

        public void Update(ItemDTO itemDto)
        {
            var record = _repository.All().FirstOrDefault(_ => _.Id == itemDto.Id);
            if (record == null)
            {
                return;
            }

            _repository.Save(new Item
            {
                Id = record.Id,
                Title = itemDto.Title,
                ShortDescription = itemDto.ShortDescription
            });
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public bool ItemExists(int id)
        {
            return _repository.All().Any(_ => _.Id == id);
        }
    }
}
