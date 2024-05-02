using RockProgressif.Models;

namespace RockProgressif.ViewModels;

public class ChansonIndexViewModel
{
    public int AlbumId { get; set; }
    public List<Chanson> Chansons { get; set; } = new List<Chanson>();
}