using ASPNetCoreMastersTodoList.Api.BindingModels;
using ASPNetCoreMastersTodoList.Api.Data;
using ASPNetCoreMastersTodoList.Api.Filters;
using Microsoft.AspNetCore.Authorization;
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
    [ItemExists]
    [Authorize]
    public class ItemsController : Controller
    {
        private readonly ILogger<ItemsController> _logger;

        private IItemService _itemService;

        private DotNetMastersDB _dbContext;

        public ItemsController(ILogger<ItemsController> logger, IItemService itemService, DotNetMastersDB dbContext )
        {
            _logger = logger;
            _itemService = itemService;
            _dbContext = dbContext;
        }

        [HttpGet]
        IActionResult Get()
        {
            var result = _itemService.GetAll();

            //return Ok(result);

            return Ok(_dbContext.Item.ToList());
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
        IActionResult GetByFilters([FromBody] Dictionary<string, string> filters)
        {
            var id = int.Parse(filters.GetValueOrDefault("id"));
            var text = filters.GetValueOrDefault("text");

            var itemFilterDto = new ItemByFilterDTO(id, text);

            var result = _itemService.GetAllByFilter(itemFilterDto);

            return Ok(result);
        }

        [HttpPost]
        IActionResult Post([FromBody] ItemCreateBindingModel itemCreateModel)
        {
            var itemDto = new ItemDTO(itemCreateModel.Text);

            _itemService.Add(itemDto);

            return Ok();
        }

        [HttpPut]
        [Route("{itemId}")]
        IActionResult Put(int itemId, [FromBody] ItemUpdateBindingModel itemUpdateModel)
        {
            var itemDto = new ItemDTO(itemId, itemUpdateModel.Text);

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
