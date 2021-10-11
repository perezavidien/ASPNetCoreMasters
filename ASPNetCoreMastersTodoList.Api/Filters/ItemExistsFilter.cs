using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Filters
{
    public class ItemExistsFilter : IActionFilter
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
            // call svc
        }
    }

    public class ItemExistAttribute : TypeFilterAttribute
    {
        public ItemExistAttribute() : base(typeof(ItemExistsFilter))
        { }
    }

}