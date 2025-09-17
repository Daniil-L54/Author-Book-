using System.Collections.Generic;

namespace AuthorBookApi.Models
{
    public class TacGia
    {
        public int TacGiaId { get; set; }
        public string Ten { get; set; } = string.Empty;
        public ICollection<TacGiaSach> TacGiaSachs { get; set; } = new List<TacGiaSach>();
    }
}
