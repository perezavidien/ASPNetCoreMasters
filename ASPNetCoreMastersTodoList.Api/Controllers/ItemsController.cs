using ASPNetCoreMastersTodoList.Api.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ILogger<ItemsController> _logger;
        private ItemService _itemService;

        public ItemsController(ILogger<ItemsController> logger, ItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }


        [HttpGet]
        IEnumerable<string> GetAll(int userId)
        {
            return _itemService.GetAll(userId);
        }

        [HttpGet]
        int Get(int userId)
        {
            return 1;
        }

        [HttpPost]
        void Save(ItemCreateBindingModel modelObject)
        {
            // accepts ItemCreateBindingModel object
            // ? and is mapped to an ItemDTO object
            // for the ItemService Save method to consume
            
            var itemObject = new ItemDTO(modelObject.Text);            

            _itemService.Save(itemObject);
        }
    }
}
