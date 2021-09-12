using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Models.Dominio;

namespace ClinicaVeterinaria.Controllers
{
    public class VacinasController : Controller
    {
        private readonly Contexto _context;

        public VacinasController(Contexto context)
        {
            _context = context;
        }

        // GET: Vacinas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vacinas.ToListAsync());
        }

        // GET: Vacinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacina = await _context.Vacinas
                .FirstOrDefaultAsync(m => m.id == id);
            if (vacina == null)
            {
                return NotFound();
            }

            return View(vacina);
        }

        // GET: Vacinas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vacinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricaoVacina,fabricanteVacina,fabricacaoVacina,validadeVacina")] Vacina vacina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vacina);
        }

        // GET: Vacinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacina = await _context.Vacinas.FindAsync(id);
            if (vacina == null)
            {
                return NotFound();
            }
            return View(vacina);
        }

        // POST: Vacinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descricaoVacina,fabricanteVacina,fabricacaoVacina,validadeVacina")] Vacina vacina)
        {
            if (id != vacina.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacinaExists(vacina.id))
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
            return View(vacina);
        }

        // GET: Vacinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacina = await _context.Vacinas
                .FirstOrDefaultAsync(m => m.id == id);
            if (vacina == null)
            {
                return NotFound();
            }

            return View(vacina);
        }

        // POST: Vacinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacina = await _context.Vacinas.FindAsync(id);
            _context.Vacinas.Remove(vacina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacinaExists(int id)
        {
            return _context.Vacinas.Any(e => e.id == id);
        }
    }
}
