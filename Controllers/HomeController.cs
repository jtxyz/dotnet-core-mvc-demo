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
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index([FromServices] INodeServices nodeServices)
        {
            ViewData["ResultFromNode"] = await nodeServices
                .InvokeAsync<string>("node/node-greeting.js");

            return View();
        }
    }
}
