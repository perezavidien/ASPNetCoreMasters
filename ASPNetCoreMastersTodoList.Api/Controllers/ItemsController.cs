using ASPNetCoreMastersTodoList.Api.BindingModels;
using ASPNetCoreMastersTodoList.Api.Data;
using ASPNetCoreMastersTodoList.Api.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using Services;
using Services.DTO;
using System.Collections.Generic;
using System.Linq;

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ItemExists]
    [Authorize]
    public class ItemsController : Controller
    {
        private readonly IItemService _itemService;
        private readonly UserManager<IdentityUser> _userService;
        private readonly ILogger<ItemsController> _logger;

        public ItemsController(
            ILogger<ItemsController> logger,
            IItemService itemService,
            UserManager<IdentityUser> userService)
        {
            _logger = logger;
            _itemService = itemService;
            _userService = userService;
        }

        [HttpGet]
        IActionResult Get()
        {
            return Ok(_itemService.GetAll().ToList());
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
        async Task<IActionResult> Post([FromBody] ItemCreateBindingModel itemCreateModel)
        {
            var email = ((ClaimsIdentity)User.Identity).FindFirst("Email");
            var user = await _userService.FindByNameAsync(email.Value);

            var itemDto = new ItemDTO(){
                Title = itemCreateModel.Title
                // description 
            };

            _itemService.Add(itemDto, user);

            return Ok();
        }

        [HttpPut]
        [Route("{itemId}")]
        IActionResult Put(int itemId, [FromBody] ItemUpdateBindingModel itemUpdateModel)
        {
            var itemDto = _itemService.Get(itemId);
            //var auth = await 

            _itemService.Update(new ItemDTO()
            {
                Id = itemUpdateModel.Id,
                Title = itemUpdateModel.Title,
                ShortDescription = itemUpdateModel.Description
            });

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
