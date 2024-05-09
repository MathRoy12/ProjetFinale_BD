using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RockProgressif.Data;
using RockProgressif.Models;
using RockProgressif.ViewModels;

namespace RockProgressif.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly ProgRockBDContext _context;

        public AlbumsController(ProgRockBDContext context)
        {
            _context = context;
        }

        // GET: Albums
        public async Task<IActionResult> Index()
        {
            var progRockBDContext = _context.Albums.Include(a => a.Groupe);
            return View(await progRockBDContext.ToListAsync());
        }

        // GET: Albums/Create
        public IActionResult Create()
        {
            ViewData["GroupeId"] = new SelectList(_context.Groupes, "GroupeId", "Nom");
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AlbumCreationViewModel acvm)
        {
            if (ModelState.IsValid && acvm.FormFile.Length >= 0)
            {
                Album album = new Album
                {
                    GroupeId = acvm.GroupeId,
                    AlbumId = 0,
                    Nom = acvm.Nom,
                    DatePublication = acvm.DatePublication,
                    NoteCritiques = acvm.NoteCritiques,
                    NombreVentes = acvm.NombreVentes
                };

                MemoryStream stream = new MemoryStream();
                await acvm.FormFile.CopyToAsync(stream);
                byte[] fichier = stream.ToArray();
                album.CoverContent = fichier;

                await _context.Albums.AddAsync(album);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["GroupeId"] = new SelectList(_context.Groupes, "GroupeId", "Nom", acvm.GroupeId);
            return View(acvm);
        }

        public async Task<IActionResult> Filtre()
        {
            AlbumsFiltreViewModel data = new AlbumsFiltreViewModel();

            data.albums = await _context.Albums.ToListAsync();
            ViewData["Groupes"] = new SelectList(_context.Groupes, "GroupeId", "Nom");

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Filtre(AlbumsFiltreViewModel afvm)
        {
            ViewData["Groupes"] = new SelectList(_context.Groupes, "GroupeId", "Nom");

            var albums = _context.Albums.AsQueryable();
            if (afvm.GroupeId > 0)
            {
                albums = albums.Where(a => a.GroupeId == afvm.GroupeId).AsQueryable();
            }
            if (afvm.NbVenteMin != null)
            {
                albums = albums.Where(a => a.NombreVentes >= afvm.NbVenteMin).AsQueryable();
            }
            if (afvm.NoteCritiqueMin != null)
            {
                albums = albums.Where(a => a.NoteCritiques >= afvm.NoteCritiqueMin).AsQueryable();
            }
    
            afvm.albums = await albums.ToListAsync();
            return View(afvm);
        }
    }
}