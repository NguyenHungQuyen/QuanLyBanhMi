using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BanhMiController : ControllerBase
{
    private readonly BanhMiRepository _repo;

    public BanhMiController(BanhMiRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _repo.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _repo.GetById(id);
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BanhMi banhMi)
    {
        await _repo.Create(banhMi);
        return Ok("Thêm thành công");
    }
}
