namespace RockProgressif.ViewModels;

public class AlbumCreationViewModel
{
    public string Nom { get; set; } = null!;
    public DateTime DatePublication { get; set; }
    public int NombreVentes { get; set; }
    public int NoteCritiques { get; set; }
    public int GroupeId { get; set; }
    public IFormFile FormFile { get; set; } = null!;
}