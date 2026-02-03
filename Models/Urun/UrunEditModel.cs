namespace dotnet_store.Models;
public class UrunEditModel
{
    public int Id { get; set; }
    public string UrunAdi { get; set; } = null!;
    public double Fiyat { get; set; }
    public string? ResimAdi { get; set; }
    public IFormFile? ResimDosyasi { get; set; }
    public string? Aciklama { get; set; }
    public bool Aktif { get; set; }
    public bool Anasayfa { get; set; }
    public int KategoriId { get; set; }
}
