namespace AuthorBookApi.Models
{
    public class TacGiaSach
    {
        public int TacGiaId { get; set; }
        public TacGia? TacGia { get; set; }
        public int SachId { get; set; }
        public Sach? Sach { get; set; }
    }
}
