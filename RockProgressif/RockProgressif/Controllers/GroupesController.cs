using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RockProgressif.Data;
using RockProgressif.Models;

namespace RockProgressif.Controllers
{
    public class GroupesController : Controller
    {
        private readonly ProgRockBDContext _context;

        public GroupesController(ProgRockBDContext context)
        {
            _context = context;
        }

        // GET: Groupes
        public async Task<IActionResult> Index()
        {
            return _context.Groupes != null
                ? View(await _context.Groupes.ToListAsync())
                : Problem("Entity set 'ProgRockBDContext.Groupes'  is null.");
        }

        // GET: Groupes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Groupes == null)
            {
                return NotFound();
            }

            string query = "EXEC Groupes.USP_ObtenirGroupeEnClair @Id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter{ParameterName = "@Id", Value = id}
            };

            List<GroupeEnClair> groupes = await _context.GroupeEnClairs.FromSqlRaw(query, parameters.ToArray()).ToListAsync();
            
            if (groupes == null)
            {
                return NotFound();
            }

            return View(groupes.First());
        }

        // GET: Groupes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Groupes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Nom, DateTime DateFormation, int TotaleAlbumVendue)
        {
            if (ModelState.IsValid)
            {
                string query = "Groupes.USP_CreerGroupe @Nom, @DateFormation, @TotaleAlbumVendue";
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter{ParameterName = "@Nom", Value = Nom},
                    new SqlParameter{ParameterName = "@DateFormation", Value = DateFormation},
                    new SqlParameter{ParameterName = "@TotaleAlbumVendue", Value = TotaleAlbumVendue}
                };
                await _context.Database.ExecuteSqlRawAsync(query, parameters.ToArray());
                
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: Groupes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Groupes == null)
            {
                return NotFound();
            }

            var groupe = await _context.Groupes
                .FirstOrDefaultAsync(m => m.GroupeId == id);
            if (groupe == null)
            {
                return NotFound();
            }

            return View(groupe);
        }

        // POST: Groupes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Groupes == null)
            {
                return Problem("Entity set 'ProgRockBDContext.Groupes'  is null.");
            }

            var groupe = await _context.Groupes.FindAsync(id);
            if (groupe != null)
            {
                _context.Groupes.Remove(groupe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupeExists(int id)
        {
            return (_context.Groupes?.Any(e => e.GroupeId == id)).GetValueOrDefault();
        }
    }
}