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
    [Route("[controller]")]
    public class ItemsController : Controller
    {
        private readonly ILogger<ItemsController> _logger;

        private IItemService _itemService;

        public ItemsController(ILogger<ItemsController> logger, IItemService itemService)
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
        IActionResult Get(int itemId)
        {
            var result = _itemService.Get(itemId);

            return Ok(result);
        }

        [HttpGet]
        [Route("filterBy")]
        IActionResult GetByFilters([FromBody] string filters)
        {
            var itemFilterDto = new ItemByFilterDTO(filters);

            var result = _itemService.GetAllByFilter(itemFilterDto);

            return Ok(result);
        }

        [HttpPost]
        IActionResult Post([FromBody] ItemCreateBindingModel itemCreateModel)
        {
            var itemDto = new ItemDTO() { Text = itemCreateModel.Text };

            _itemService.Add(itemDto);

            return Ok();
        }

        [HttpPut]
        [Route("{itemId}")]
        IActionResult Put(int itemId, [FromBody] ItemUpdateBindingModel itemUpdateModel)
        {
            //where to use itemId?

            var itemDto = new ItemDTO()
            {
                Id = itemUpdateModel.Id,
                Text = itemUpdateModel.Text
            };

            _itemService.Update(itemDto);

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
