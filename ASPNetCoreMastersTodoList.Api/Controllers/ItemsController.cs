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
    [ApiController]
    [Route("items")]
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
        IActionResult Get()
        {
            var result = _itemService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("{itemId}")]
        IActionResult Get(int userId)
        {
            var result = _itemService.GetById(userId);
            return Ok(result);
        }

        [HttpGet]
        [Route("filterBy?[text]=[text]")]
        IActionResult GetByFilters([FromBody] Dictionary<string, string> filters)
        {
            var result = _itemService.GetByFilters(filters);
            return Ok(result);
        }

        [HttpPost]
        IActionResult Post([FromBody] ItemCreateBindingModel itemCreateModel)
        {
            // accepts ItemCreateBindingModel object
            // ? and is mapped to an ItemDTO object
            // for the ItemService Save method to consume
            
            var itemDto = new ItemDTO(itemCreateModel.Text);            

            _itemService.Save(itemDto);

            return Ok();
        }

        [HttpPut]
        [Route("{itemId}")]
        IActionResult Put(int id, [FromBody] ItemUpdateBindingModel itemUpdateModel)
        {
            var itemDto = new ItemDTO(itemUpdateModel.Text);

            _itemService.Update(id, itemDto);
            return Ok();
        }

        [HttpDelete]
        [Route("{itemId}")]
        IActionResult Delete(int itemId)
        {
            _itemService.Delete(itemId);
            return Ok();
        }
    }
}
