using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthorBookApi.Data;
using AuthorBookApi.Models;

namespace AuthorBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacGiasController : ControllerBase
    {
        private readonly AuthorBookContext _context;

        public TacGiasController(AuthorBookContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<TacGia>> TaoTacGia([FromBody] TacGia tacGia)
        {
            _context.TacGias.Add(tacGia);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(LayTheoId), new { id = tacGia.TacGiaId }, tacGia);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TacGia>>> LayDanhSachTacGia()
        {
            var ds = await _context.TacGias
                .Include(t => t.TacGiaSachs)
                .ThenInclude(ts => ts.Sach)
                .ToListAsync();
            return Ok(ds);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TacGia>> LayTheoId(int id)
        {
            var tacGia = await _context.TacGias
                .Include(t => t.TacGiaSachs)
                .ThenInclude(ts => ts.Sach)
                .FirstOrDefaultAsync(t => t.TacGiaId == id);

            if (tacGia == null) return NotFound();
            return Ok(tacGia);
        }

        [HttpPost("{id}/sachs")]
        public async Task<ActionResult> GanSachChoTacGia(int id, [FromBody] int sachId)
        {
            var tacGia = await _context.TacGias.FindAsync(id);
            if (tacGia == null) return NotFound("Tac gia khong ton tai");

            var sach = await _context.Sachs.FindAsync(sachId);
            if (sach == null) return NotFound("Sach khong ton tai");

            var exists = await _context.TacGiaSachs.FindAsync(id, sachId);
            if (exists != null) return BadRequest("Da gan sach cho tac gia");

            var tacGiaSach = new TacGiaSach { TacGiaId = id, SachId = sachId };
            _context.TacGiaSachs.Add(tacGiaSach);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
