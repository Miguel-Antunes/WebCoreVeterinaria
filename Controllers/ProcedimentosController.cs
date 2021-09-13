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
    public class ProcedimentosController : Controller
    {
        private readonly Contexto _context;

        public ProcedimentosController(Contexto context)
        {
            _context = context;
        }

        // GET: Procedimentos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Procedimentos.Include(p => p.nomeAnimal);
            return View(await contexto.ToListAsync());
        }

        // GET: Procedimentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedimento = await _context.Procedimentos
                .Include(p => p.nomeAnimal)
                .FirstOrDefaultAsync(m => m.id == id);
            if (procedimento == null)
            {
                return NotFound();
            }

            return View(procedimento);
        }

        // GET: Procedimentos/Create
        public IActionResult Create()
        {
            ViewData["idAnimal"] = new SelectList(_context.Animais, "id", "nomeAnimal");
            ViewData["idVeterinario"] = new SelectList(_context.Veterinarios, "id", "nomeVeterinario");
            ViewData["idVacina"] = new SelectList(_context.Vacinas, "id", "descricaoVacina");
            return View();
        }

        // POST: Procedimentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,idAnimal,idVeterinario,idVacina,dataProcedimento,statusDor,statusFebre,statusEstado,queixa,procedimento")] Procedimento procedimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procedimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idAnimal"] = new SelectList(_context.Animais, "id", "nomeAnimal", procedimento.idAnimal);
            return View(procedimento);
        }

        // GET: Procedimentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedimento = await _context.Procedimentos.FindAsync(id);
            if (procedimento == null)
            {
                return NotFound();
            }
            ViewData["idAnimal"] = new SelectList(_context.Animais, "id", "nomeAnimal", procedimento.idAnimal);
            return View(procedimento);
        }

        // POST: Procedimentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,idAnimal,idVeterinario,idVacina,dataProcedimento,statusDor,statusFebre,statusEstado,queixa,procedimento")] Procedimento procedimento)
        {
            if (id != procedimento.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procedimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcedimentoExists(procedimento.id))
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
            ViewData["idAnimal"] = new SelectList(_context.Animais, "id", "nomeAnimal", procedimento.idAnimal);
            return View(procedimento);
        }

        // GET: Procedimentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedimento = await _context.Procedimentos
                .Include(p => p.nomeAnimal)
                .FirstOrDefaultAsync(m => m.id == id);
            if (procedimento == null)
            {
                return NotFound();
            }

            return View(procedimento);
        }

        // POST: Procedimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var procedimento = await _context.Procedimentos.FindAsync(id);
            _context.Procedimentos.Remove(procedimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcedimentoExists(int id)
        {
            return _context.Procedimentos.Any(e => e.id == id);
        }
    }
}
