using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpedIT.Models;
using SpedIT_Domain;
using SpedIT_Domain.Repositories;

namespace SpedIT_Interface.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionsController : Controller
    {
        private readonly IPositionRepository positionRepository;

        public PositionsController(IPositionRepository positionRepository)
        {
            this.positionRepository = positionRepository;
        }

        // GET: Positions
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var positions = await positionRepository.GetAllPositionsAsync();
            return positions != null ? View(positions) : Problem("Entity set 'DataContext.Positions' is null.");
        }

        // GET: Positions/Details/5
        [HttpGet("{id}/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await positionRepository.GetPositionByIdAsync(id.Value);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // GET: Positions/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Positions/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Position position)
        {
            if (ModelState.IsValid)
            {
                await positionRepository.AddPositionAsync(position);
                return RedirectToAction(nameof(Index));
            }
            return View(position);
        }

        // GET: Positions/Edit/5
        [HttpGet("{id}/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await positionRepository.GetPositionByIdAsync(id.Value);
            if (position == null)
            {
                return NotFound();
            }
            return View(position);
        }

        // POST: Positions/Edit/5
        [HttpPost("{id}/Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] Position position)
        {
            if (id != position.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await positionRepository.UpdatePositionAsync(position);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await positionRepository.GetPositionByIdAsync(position.Id) == null)
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
            return View(position);
        }

        // GET: Positions/Delete/5
        [HttpGet("{id}/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await positionRepository.GetPositionByIdAsync(id.Value);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // POST: Positions/Delete/5
        [HttpPost("{id}/Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await positionRepository.DeletePositionAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
