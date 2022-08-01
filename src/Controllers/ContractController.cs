namespace Stuntman.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContractController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public ContractController(ApplicationDbContext db)
    {
        _db = db;
    }

    // GET: api/Contract
    /// <summary>
    /// Get all contracts
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContractModel>>> GetContracts()
    {
        if (_db.Contracts == null)
        {
            return NotFound();
        }
        return await _db.Contracts.ToListAsync();
    }

    // GET: api/Contract/5
    /// <summary>
    /// Get a contract (by Id)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ContractModel>> GetContract(int id)
    {
        var contractModel = await _db.Contracts.FindAsync(id);

        if (contractModel == null)
        {
            return NotFound();
        }

        return contractModel;
    }

    // PATCH: api/contract/5
    /// <summary>
    /// Patch a contract (by id)
    /// </summary>
    /// <param name="id"></param>
    /// <param name="contract"></param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchContract(int id, [FromBody] JsonPatchDocument<ContractModel> contract)
    {
        var entity = await _db.Contracts.FindAsync(id);
        if (entity == null)
        {
            return NotFound();
        }
        contract.ApplyTo(entity, ModelState);
        await _db.SaveChangesAsync();

        return Ok(entity);
    }

    // POST: api/Contract
    /// <summary>
    /// Create new contract
    /// </summary>
    /// <param name="contractModel"></param>
    /// <returns></returns>
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ContractModel>> PostContractModel(ContractModel contractModel)
    {
        _db.Contracts.Add(contractModel);
        await _db.SaveChangesAsync();

        return CreatedAtAction("GetContractModel", new { id = contractModel.Id }, contractModel);
    }

    // DELETE: api/Contract/5
    /// <summary>
    /// Delete a contract (by Id)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContractModel(int id)
    {
        var contractModel = await _db.Contracts.FindAsync(id);
        if (contractModel == null)
        {
            return NotFound();
        }

        _db.Contracts.Remove(contractModel);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}
