using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Filters
{
    public class ItemExistsFilter: IActionFilter
    {
        private IItemService _itemService;

        public ItemExistsFilter(IItemService itemService)
        {
            _itemService = itemService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.ActionArguments.TryGetValue("itemId", out object itemId);

            if (itemId != null)
            {
                var id = (int)itemId;

                if (!_itemService.ItemExists(id))
                {
                    context.Result = new NotFoundResult();
                }
            }
        }
    }

    public class ItemExistsAttribute : TypeFilterAttribute
    {
        public ItemExistsAttribute() : base(typeof(ItemExistsFilter))
        { }
    }

}