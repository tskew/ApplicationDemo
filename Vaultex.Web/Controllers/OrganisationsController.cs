using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Vaultex.Web.Controllers
{
    public class OrganisationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}