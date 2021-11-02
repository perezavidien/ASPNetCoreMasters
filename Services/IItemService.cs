using Microsoft.AspNetCore.Identity;
using Services.DTO;
using System.Collections.Generic;

namespace Services
{
    public interface IItemService
    {
        IEnumerable<ItemDTO> GetAll();
        IEnumerable<ItemDTO> GetAllByFilter(ItemByFilterDTO filters);
        ItemDTO Get(int itemId);
        void Add(ItemDTO itemDto, IdentityUser user);
        void Update(ItemDTO itemDTO);
        void Delete(int id);
        bool ItemExists(int id);
    }
}
