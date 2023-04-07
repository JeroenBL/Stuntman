namespace Stuntman.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public DepartmentController(ApplicationDbContext db)
    {
        _db = db;
    }

    // GET: api/Department
    /// <summary>
    /// Get all departments
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DepartmentModel>>> GetDepartments()
    {
        if (_db.Departments == null)
        {
            return NotFound();
        }
        return await _db.Departments.ToListAsync();
    }

    // GET: api/Department/5
    /// <summary>
    /// Get a department (by Id)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<DepartmentModel>> GetDepartment(int id)
    {
        var departmentModel = await _db.Departments.FindAsync(id);

        if (departmentModel == null)
        {
            return NotFound();
        }

        return departmentModel;
    }

    // PATCH: api/Department/5
    /// <summary>
    /// Patch a department (by id)
    /// </summary>
    /// <param name="id"></param>
    /// <param name="contract"></param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    public async Task<IActionResult> PaatchDepartment(int id, [FromBody] JsonPatchDocument<DepartmentModel> department)
    {
        var entity = await _db.Departments.FindAsync(id);
        if (entity == null)
        {
            return NotFound();
        }
        department.ApplyTo(entity, ModelState);
        await _db.SaveChangesAsync();

        return Ok(entity);
    }

    // POST: api/Department
    /// <summary>
    /// Create new department
    /// </summary>
    /// <param name="contractModel"></param>
    /// <returns></returns>
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<DepartmentModel>> PostDepartment(DepartmentModel departmentModel)
    {
        _db.Departments.Add(departmentModel);
        await _db.SaveChangesAsync();

        return CreatedAtAction("GetDepartment", new { id = departmentModel.Id }, departmentModel);
    }

    // DELETE: api/Department/5
    /// <summary>
    /// Delete a department (by Id)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDepartment(int id)
    {
        var departmentModel = await _db.Departments.FindAsync(id);
        if (departmentModel == null)
        {
            return NotFound();
        }

        _db.Departments.Remove(departmentModel);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}
