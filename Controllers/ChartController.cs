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
    public class ChartController : Controller
    {
        public async Task<IActionResult> Index([FromServices] INodeServices nodeServices)
        {
            var options = new // anonymous types!
            {
                width = 1000,
                height = 600,
                showArea = true,
                showPoint = true,
                fullWidth = true
            };

            var data = new
            {
                labels = new[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" },
                series = new[] { // type infered arrays!
                    new[] { 1, 5, 2, 5, 4, 3 },
                    new[] { 2, 3, 4, 8, 1, 2 },
                    new[] { 5, 4, 3, 2, 1, 0 }
                }
            };

            ViewData["ChartMarkup"] = await nodeServices
                .InvokeAsync<string>("node/charts.js", "line", options, data);

            return View();
        }
    }
}
