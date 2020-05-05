using System.Collections.Generic;
using ConfigureApps.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConfigureApps.Controllers
{
    public class HomeController : Controller
    {
        public UptimeService uptime;
        private ILogger<HomeController> logger;

        public HomeController(UptimeService up, ILogger<HomeController> log)
        {
            uptime = up;
            logger = log;
        }

        public ViewResult Index(bool throwException = false)
        {
            logger.LogDebug($"Handled {Request.Path} at uptime {uptime.Uptime}");

            if (throwException)
            {
                throw new System.NullReferenceException();
            }
            else
            {
                return View(new Dictionary<string, string>
                {
                    ["Message"] = "This is the Index action",
                    ["Uptime"] = $"{uptime.Uptime}ms"
                });
            }
        }

        public ViewResult Error()
        {
            return View(nameof(Index),
                new Dictionary<string, string>
                {
                    ["Message"] = "This is the Error action."
                });
        }
    }
}
