using BanMiAPI.Models;

public class BanhMiNguyenLieu
{
    public int BanhMiId { get; set; }
    public int NguyenLieuId { get; set; }
    public int SoLuong { get; set; } // số lượng nguyên liệu trong ổ bánh

    // Navigation properties (tuỳ bạn có cần hay không)
    public BanhMi BanhMi { get; set; }
    public NguyenLieu NguyenLieu { get; set; }
}
