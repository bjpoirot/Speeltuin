using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShipwharfMVCSolution.Data;
using ShipwharfMVCSolution.Models;
using ShipwharfMVCSolution.Repositories;

namespace ShipwharfMVCSolution.Controllers
{
    public class ShipTypesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IShipTypesRepository _shiptypesRepository;

        public ShipTypesController(ApplicationDbContext context, IShipTypesRepository shiptypesRepository)
        {
            _context = context;
            _shiptypesRepository = shiptypesRepository;
        }

        // GET: ShipTypes
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var numberOfShiptypes = await _shiptypesRepository.GetNumberOfShipTypes();
            var vm = new PagedViewModel<ShipTypePageListItemViewModel>(numberOfShiptypes);
            if (pageNumber.HasValue)
            {
                vm.PageNumber = pageNumber.Value;
            }
            var ships = await _shiptypesRepository.GetShipTypes(vm.PageSize * (vm.PageNumber - 1), vm.PageSize);
            vm.Items = ships;

            return View(vm);
        }

        // GET: ShipTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipType = await _context.ShipTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shipType == null)
            {
                return NotFound();
            }

            return View(shipType);
        }

        // GET: ShipTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShipTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] ShipType shipType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shipType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shipType);
        }

        // GET: ShipTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipType = await _context.ShipTypes.FindAsync(id);
            if (shipType == null)
            {
                return NotFound();
            }
            return View(shipType);
        }

        // POST: ShipTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] ShipType shipType)
        {
            if (id != shipType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shipType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShipTypeExists(shipType.Id))
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
            return View(shipType);
        }

        // GET: ShipTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipType = await _context.ShipTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shipType == null)
            {
                return NotFound();
            }

            return View(shipType);
        }

        // POST: ShipTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shipType = await _context.ShipTypes.FindAsync(id);
            _context.ShipTypes.Remove(shipType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShipTypeExists(int id)
        {
            return _context.ShipTypes.Any(e => e.Id == id);
        }
    }
}
