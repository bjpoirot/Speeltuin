using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShipwharfMVCSolution.Data;
using ShipwharfMVCSolution.Models;
using ShipwharfMVCSolution.Repositories;

namespace ShipwharfMVCSolution.Controllers
{
    public class ShipsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IShipsRepository _shipsRepository;
        private readonly IShipTypesRepository _shipTypesRepository;

        public ShipsController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            IShipsRepository shipsRepository,
            IShipTypesRepository shipTypesRepository
            )
        {
            _context = context;
            _userManager = userManager;
            _shipsRepository = shipsRepository;
            _shipTypesRepository = shipTypesRepository; 
        }

        //// GET: Ships
        //public async Task<IActionResult> Index(int? pageNumber, int? pageSize)
        //{

        //    var numberOfShips = await _shipsRepository.GetNumberOfShips();
        //    var ships = await _shipsRepository.GetShips((pageSize ?? 15) * ((pageNumber ?? 1)-1), pageSize ?? 15);
        //    var vm = new ShipsPagedViewModel(ships, numberOfShips);
        //    vm.PageNumber = pageNumber ?? 1;
        //    vm.PageSize = pageSize ?? 15;
        //    return View(vm);
        //}

    
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var numberOfShips = await _shipsRepository.GetNumberOfShips();
            var vm = new PagedViewModel<ShipPageListItemViewModel>(numberOfShips);
            if (pageNumber.HasValue)
            {
                vm.PageNumber = pageNumber.Value;
            }
            var ships = await _shipsRepository.GetShips(vm.PageSize * (vm.PageNumber - 1), vm.PageSize);
            vm.Items = ships;

            return View(vm);
        }

        private void TestGenericClassConveriosn()
        {
            // try to convert from generic to less generic
            PagedViewModel<ShipPageListItemViewModel> specific = new(0);
           // doesn't work!!!
            // PagedViewModel<PageListItemViewModelBase> lessSpecific = (PagedViewModel<IPageListItemViewModel>)specific;
            // Cannot convert a generic typed class 

        }

        // GET: Ships/Details/5
        public async Task<IActionResult> Details(Guid? id, Guid? aapje)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ship = await _shipsRepository.GetShipDetails(id.Value);
            if (ship == null)
            {
                return NotFound();
            }

            return View(ship);
        }

        // GET: Ships/Create
        public async Task<IActionResult> Create()
        {
            var shipTypes = await _shipTypesRepository.Get();
            var createShipViewModel = new CreateShipViewModel(shipTypes);

            // ViewData["ShipTypeId"] = new SelectList(_context.ShipTypes, "Id", "Id");
            return View(createShipViewModel);
        }

        // POST: Ships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Hold,Name,ShipTypeId")] UpdateShipViewModel ship)
        {
            if (ModelState.IsValid)
            {
                
                await _shipsRepository.Create(ship);
                return RedirectToAction(nameof(Index));
            }

            var shipTypes = await _shipTypesRepository.Get();
            var createShipViewModel = new CreateShipViewModel(shipTypes);
            createShipViewModel.Id = ship.Id;
            createShipViewModel.Hold = ship.Hold;
            createShipViewModel.EuNumber = ship.EuNumber;
            createShipViewModel.ShipTypeId = ship.ShipTypeId;
            createShipViewModel.Name = ship.Name;
            return View(createShipViewModel);
        }

        // GET: Ships/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ship = await _context.Ships.FindAsync(id);
            if (ship == null)
            {
                return NotFound();
            }
            ViewData["ShipTypeId"] = new SelectList(_context.ShipTypes, "Id", "Id", ship.ShipTypeId);
            return View(ship);
        }

        // POST: Ships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Hold,Name,ShipTypeId")] Ship ship)
        {
            if (id != ship.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var entityState = _context.Entry<Ship>(ship).State;
                    _context.Entry<Ship>(ship).State = EntityState.Added;
                    
                    _context.Update(ship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShipExists(ship.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShipTypeId"] = new SelectList(_context.ShipTypes, "Id", "Id", ship.ShipTypeId);
            return View(ship);
        }

        // GET: Ships/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ship = await _context.Ships
                .Include(s => s.ShipType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ship == null)
            {
                return NotFound();
            }

            return View(ship);
        }

        // POST: Ships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ship = await _context.Ships.FindAsync(id);
            _context.Ships.Remove(ship);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShipExists(Guid id)
        {
            return _context.Ships.Any(e => e.Id == id);
        }
    }
}
