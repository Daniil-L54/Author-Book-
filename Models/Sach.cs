using System.Collections.Generic;

namespace AuthorBookApi.Models
{
    public class Sach
    {
        public int SachId { get; set; }
        public string TieuDe { get; set; } = string.Empty;
        public ICollection<TacGiaSach> TacGiaSachs { get; set; } = new List<TacGiaSach>();
    }
}
