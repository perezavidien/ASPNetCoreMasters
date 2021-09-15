using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
    public class ItemsController : Controller
    {
        private static readonly string[] Items = new[]
        {
            "One", "Two", "Three"
        };

        private readonly ILogger<ItemsController> _logger;

        public ItemsController(ILogger<ItemsController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        IEnumerable<string> GetAll(int userId)
        {
            // ?

            return Items;
        }
    }
}
