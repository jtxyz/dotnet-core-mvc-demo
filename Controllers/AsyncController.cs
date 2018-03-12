using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_mvc.Models;
using Microsoft.AspNetCore.NodeServices;

namespace dotnet_mvc.Controllers
{
    public class AsyncController : Controller
    {
        public async Task<IActionResult> Index([FromServices] INodeServices nodeServices)
        {
            var firstTask = nodeServices
                .InvokeAsync<string>("node/add-slowly.js", 10, 20, 3000);
            var secondTask = nodeServices
                .InvokeAsync<string>("node/add-slowly.js", 54, 27, 3000);

            var messages = new List<string>();

            messages.Add(await firstTask);
            messages.Add(await secondTask);

            ViewData["Messages"] = messages;

            return View();
        }
    }
}
