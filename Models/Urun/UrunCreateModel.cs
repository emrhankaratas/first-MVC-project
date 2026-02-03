using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class UrunCreateModel
{
    [Display(Name = "Ürün Adı")]
    [Required(ErrorMessage = "{0} girmelisiniz.")]
    [StringLength(50, ErrorMessage = "{0} için {2}-{1} karakter aralığında değer girmelisiniz.", MinimumLength = 10)]
    public string UrunAdi { get; set; } = null!;

    [Display(Name = "Ürün Fiyat")]
    public double Fiyat { get; set; }

    [Display(Name = "Ürün Resmi")]
    public IFormFile? Resim { get; set; }

    public string? Aciklama { get; set; }

    public bool Aktif { get; set; }

    public bool Anasayfa { get; set; }

    public int KategoriId { get; set; }
}