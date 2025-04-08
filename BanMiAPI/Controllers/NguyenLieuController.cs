using Microsoft.AspNetCore.Mvc;
using BanMiAPI.Models;
using BanMiAPI.Repositories.Interfaces;

namespace BanMiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguyenLieuController : ControllerBase
    {
        private readonly INguyenLieuRepository _repo;

        public NguyenLieuController(INguyenLieuRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var nl = await _repo.GetById(id);
            if (nl == null) return NotFound();
            return Ok(nl);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NguyenLieu nl)
        {
            var newId = await _repo.Create(nl);
            nl.Id = newId;
            return CreatedAtAction(nameof(GetById), new { id = newId }, nl);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, NguyenLieu nl)
        {
            if (id != nl.Id) return BadRequest();
            var success = await _repo.Update(nl);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _repo.Delete(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
