using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/error")]
        public IActionResult Error() => Problem();
    }
}
