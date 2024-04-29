using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RockProgressif.Data;
using RockProgressif.Models;

namespace RockProgressif.Controllers;

public class ArtistesController : Controller
{
    private readonly ProgRockBDContext _context;

    public ArtistesController(ProgRockBDContext context)
    {
        _context = context;
    }
        
    public async Task<IActionResult> LiensArtisteGroupes()
    {
        return _context.VwLiensArtisteGroupes != null ? 
            View(await _context.VwLiensArtisteGroupes.ToListAsync()) :
            Problem("Entity set 'ProgRockBDContext.Artistes'  is null.");
    }
}