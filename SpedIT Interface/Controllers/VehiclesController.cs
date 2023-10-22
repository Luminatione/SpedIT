using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpedIT_Data.Repositories;
using SpedIT_Domain;
using SpedIT_Domain.Models;
using SpedIT_Domain.Repositories;

namespace SpedIT_Interface.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclesController : Controller
    {
        private readonly IVehicleRepository vehicleRepository;
        private readonly IPackageRepository packageRepository;


        public VehiclesController(IVehicleRepository vehicleRepository, IPackageRepository packageRepository)
        {
            this.vehicleRepository = vehicleRepository;
            this.packageRepository = packageRepository;
        }

        // GET: Vehicles
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await vehicleRepository.GetAllVehiclesAsync());
        }

        // GET: Vehicles/Details/5
        [HttpGet("{id}/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || await vehicleRepository.GetAllVehiclesAsync() == null)
            {
                return NotFound();
            }

            var vehicle = await vehicleRepository.GetVehicleByIdAsync(id.Value);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            ViewData["PackageId"] = new MultiSelectList(await packageRepository.GetAllPackagesAsync(), "Id", "Id");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                await vehicleRepository.AddVehicleAsync(vehicle);
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        [HttpGet("{id}/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || await vehicleRepository.GetAllVehiclesAsync() == null)
            {
                return NotFound();
            }

            ViewData["PackagesIds"] = new MultiSelectList(await packageRepository.GetAllPackagesAsync(), "Id", "Id");
            var vehicle = await vehicleRepository.GetVehicleByIdAsync(id.Value);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("{id}/Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await vehicleRepository.UpdateVehicleAsync(vehicle);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await vehicleRepository.GetVehicleByIdAsync(id) == null)
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
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        [HttpGet("{id}/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || await vehicleRepository.GetAllVehiclesAsync() == null)
            {
                return NotFound();
            }

            var vehicle = await vehicleRepository.GetVehicleByIdAsync(id.Value);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost("{id}/Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await vehicleRepository.GetAllVehiclesAsync() == null)
            {
                return Problem("Entity set 'DataContext.Vehicles'  is null.");
            }
            await vehicleRepository.DeleteVehicleAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
