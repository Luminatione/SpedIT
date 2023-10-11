using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpedIT_Domain.Models;
using SpedIT_Domain.Repositories;

namespace SpedIT_Interface.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PackagesController : Controller
	{
		private readonly IPackageRepository packageRepository;

		public PackagesController(IPackageRepository packageRepository)
		{
			this.packageRepository = packageRepository;
		}

		// GET: Packages
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var packages = await packageRepository.GetAllPackagesAsync();
			return packages != null ? View(packages) : Problem("Entity set 'DataContext.Packages' is null.");
		}

		// GET: Packages/Details/5
		[HttpGet("{id}/Details")]
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var package = await packageRepository.GetPackageByIdAsync(id.Value);
			if (package == null)
			{
				return NotFound();
			}

			return View(package);
		}

		// GET: Packages/Create
		[HttpGet("Create")]
		public IActionResult Create()
		{
			return View();
		}

		// POST: Packages/Create
		[HttpPost("Create")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([FromForm] Package package)
		{
			if (ModelState.IsValid)
			{
				await packageRepository.AddPackageAsync(package);
				return RedirectToAction(nameof(Index));
			}
			return View(package);
		}

		// GET: Packages/Edit/5
		[HttpGet("{id}/Edit")]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var package = await packageRepository.GetPackageByIdAsync(id.Value);
			if (package == null)
			{
				return NotFound();
			}

			return View(package);
		}

		// POST: Packages/Edit/5
		[HttpPost("{id}/Edit")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [FromForm] Package package)
		{
			if (id != package.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					await packageRepository.UpdatePackageAsync(package);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (await packageRepository.GetPackageByIdAsync(package.Id) == null)
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
			return View(package);
		}

		// GET: Packages/Delete/5
		[HttpGet("{id}/Delete")]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var package = await packageRepository.GetPackageByIdAsync(id.Value);
			if (package == null)
			{
				return NotFound();
			}

			return View(package);
		}

		// POST: Packages/Delete/5
		[HttpPost("{id}/Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await packageRepository.DeletePackageAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}