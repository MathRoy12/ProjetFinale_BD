using RockProgressif.Models;

namespace RockProgressif.ViewModels;

public class AlbumsFiltreViewModel
{
    public int? NoteCritiqueMin { get; set; }
    public int? NbVenteMin { get; set; }
    public int? GroupeId { get; set; }
    
    public List<Album> albums { get; set; } = new List<Album>();
}