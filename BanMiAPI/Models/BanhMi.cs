using BanMiAPI.Models;

public class BanhMi
{
    public int Id { get; set; }
    public string Ten { get; set; } = string.Empty;
    public decimal Gia { get; set; }
    public List<NguyenLieu>? NguyenLieus { get; set; }
}
