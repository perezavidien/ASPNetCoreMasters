using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
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
            return _itemService.GetAll();
        }
    }
}
