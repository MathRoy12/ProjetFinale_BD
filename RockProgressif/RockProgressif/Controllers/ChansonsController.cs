using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RockProgressif.Data;
using RockProgressif.Models;
using RockProgressif.ViewModels;

namespace RockProgressif.Controllers
{
    public class ChansonsController : Controller
    {
        private readonly ProgRockBDContext _context;

        public ChansonsController(ProgRockBDContext context)
        {
            _context = context;
        }

        // GET: Chansons
        public async Task<IActionResult> Index()
        {
            ViewData["Albums"] = new SelectList(_context.Albums, "AlbumId", "Nom");
            ChansonIndexViewModel data = new ChansonIndexViewModel();
            data.Chansons = await _context.Chansons.ToListAsync();
            return _context.Chansons != null
                ? View(data)
                : Problem("Entity set 'ProgRockBDContext.Chansons'  is null.");
        }

        [HttpPost]
        public async Task<IActionResult> Index(int AlbumId)
        {
            ChansonIndexViewModel data = new ChansonIndexViewModel();
            if (AlbumId != 0)
            {
                string query = "EXEC Albums.USP_GetChansonsAlbum @AlbumId";
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@AlbumID", Value = AlbumId }
                };
                data.Chansons = await _context.Chansons.FromSqlRaw(query, parameters.ToArray()).ToListAsync();
            }
            else
            {
                data.Chansons = await _context.Chansons.ToListAsync();
            }

            ViewData["Albums"] = new SelectList(_context.Albums, "AlbumId", "Nom");
            return View(data);
        }
    }
}