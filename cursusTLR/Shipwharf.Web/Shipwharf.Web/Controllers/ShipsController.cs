using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shipwharf.ApplicationCore.Entities;
using Shipwharf.ApplicationCore.Interfaces;
using Shipwharf.Web.Data;
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
            _shipService = shipService;
            
        }

        public IActionResult Index()
        {
            var ships = new List<Ship>();
            return View(ships);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            var ship = new Ship();
            return View(ship);
        }

        [HttpPost()]
        public async Task<IActionResult> Create(Ship ship)
        {
            if(ModelState.IsValid)
            {
                await _shipService.CreateShipAsync(ship);
                return RedirectToAction(nameof(Index));
            }

            return View(ship);
        }
    }
}
