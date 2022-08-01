#nullable disable
namespace Stuntman.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StuntmanController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public StuntmanController(ApplicationDbContext db)
    {
        _db = db;
    }

    // GET: api/Stuntman
    /// <summary>
    /// Get all stuntman
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StuntmanModel>>> GetStuntman()
    {
        if (_db.Stuntman == null)
        {
            return NotFound();
        }
        return await _db.Stuntman.ToListAsync();
    }

    // GET: api/Stuntman/5
    /// <summary>
    /// Get a stuntman (by Id)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<StuntmanModel>> GetStuntman(int id)
    {
        var stuntman = await _db.Stuntman.FindAsync(id);

        if (stuntman == null)
        {
            return NotFound();
        }

        return stuntman;
    }

    // PATCH: api/Stuntman/5
    /// <summary>
    /// Patch a stuntman (by Id)
    /// </summary>
    /// <param name="id"></param>
    /// <param name="person"></param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchPerson(int id, [FromBody] JsonPatchDocument<StuntmanModel> person)
    {
        var entity = await _db.Stuntman.FindAsync(id);
        if (entity == null)
        {
            return NotFound();
        }
        person.ApplyTo(entity, ModelState);
        await _db.SaveChangesAsync();

        return Ok(entity);
    }

    // POST: api/Stuntman
    /// <summary>
    /// Create new stuntman
    /// </summary>
    /// <param name="stuntman"></param>
    /// <returns></returns>4
    [HttpPost]
    public async Task<ActionResult<StuntmanModel>> PostStuntman(StuntmanModel stuntman)
    {
        _db.Stuntman.Add(stuntman);
        await _db.SaveChangesAsync();

        return CreatedAtAction("GetStuntman", new { id = stuntman.Id }, stuntman);
    }

    // DELETE: api/Stuntman/5
    /// <summary>
    /// Delete stuntman (by Id)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStuntman(int id)
    {
        var stuntman = await _db.Stuntman.FindAsync(id);
        if (stuntman == null)
        {
            return NotFound();
        }

        _db.Stuntman.Remove(stuntman);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}
