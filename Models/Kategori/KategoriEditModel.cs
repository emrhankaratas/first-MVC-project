using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class KategoriEditModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(30)]
    [Display(Name = "Kategori Adı")]
    public string KategoriAdi { get; set; } = null!;
    
    [Required]
    [StringLength(30)]
    [Display(Name = "URL")]
    public string Url { get; set; } = null!;
}