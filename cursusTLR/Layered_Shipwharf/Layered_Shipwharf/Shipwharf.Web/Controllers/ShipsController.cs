using Microsoft.AspNetCore.Mvc;
using Shipwharf.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shipwharf.Web.Controllers
{
    public class ShipsController : Controller
    {
        private readonly IShipService _shipService;

        public ShipsController(IShipService shipService)
        {
            this._shipService = shipService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
