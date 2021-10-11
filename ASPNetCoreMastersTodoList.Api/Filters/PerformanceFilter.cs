using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Filters
{
    public class PerformanceFilter : IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Items["StopWatch"] = new Stopwatch();
            Stopwatch stopwatch = (Stopwatch)context.HttpContext.Items["StopWatch"];
            stopwatch.Start();
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Stopwatch stopwatch = (Stopwatch)context.HttpContext.Items["StopWatch"];
            stopwatch.Stop();
        }
    }
}