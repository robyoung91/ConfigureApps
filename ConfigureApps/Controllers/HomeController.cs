using System.Collections.Generic;
using ConfigureApps.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ConfigureApps.Controllers
{
    public class HomeController : Controller
    {
        public UptimeService uptime;
        public HomeController(UptimeService up)
        {
            uptime = up;
        }

        public ViewResult Index(bool throwException = false)
        {
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
