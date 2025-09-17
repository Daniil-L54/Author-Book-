using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthorBookApi.Data;
using AuthorBookApi.Models;

namespace AuthorBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SachsController : ControllerBase
    {
        private readonly AuthorBookContext _context;

        public SachsController(AuthorBookContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Sach>> TaoSach([FromBody] Sach sach)
        {
            _context.Sachs.Add(sach);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(LayTheoId), new { id = sach.SachId }, sach);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sach>>> LayDanhSachSachs()
        {
            var ds = await _context.Sachs
                .Include(s => s.TacGiaSachs)
                .ThenInclude(ts => ts.TacGia)
                .ToListAsync();
            return Ok(ds);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sach>> LayTheoId(int id)
        {
            var sach = await _context.Sachs
                .Include(s => s.TacGiaSachs)
                .ThenInclude(ts => ts.TacGia)
                .FirstOrDefaultAsync(s => s.SachId == id);

            if (sach == null) return NotFound();
            return Ok(sach);
        }
    }
}
