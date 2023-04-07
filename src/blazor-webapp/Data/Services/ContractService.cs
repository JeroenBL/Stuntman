namespace Stuntman.Web.Data.Services;

public class ContractService : IContractService
{
    private readonly ApplicationDbContext _db;
    
    public ContractService(ApplicationDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// Deprecated
    /// </summary>
    /// <param name="contract"></param>
    /// <returns></returns>
    //public ContractModel Create(ContractModel contract)
    //{
    //    var newContract = _db.Contracts.Add(contract);
    //    newContract.Entity.ContractGuid = new Guid().ToString();
    //    _db.SaveChanges();

    //    return newContract.Entity;
    //}

    /// <summary>
    /// Creates a new contract async
    /// </summary>
    /// <param name="contract"></param>
    /// <returns></returns>
    public async Task<ContractModel> CreateAsync(ContractModel contract)
    {
        var newContract = await _db.Contracts.AddAsync(contract);
        await _db.SaveChangesAsync();

        return newContract.Entity;
    }

    /// <summary>
    /// Deprecated
    /// </summary>
    /// <param name="id"></param>
    //public void Delete(int id)
    //{
    //    var contract = _db.Contracts.Find(id);
    //    if (contract != null)
    //    {
    //        _db.Contracts.Remove(contract);
    //        _db.SaveChanges();
    //    };
    //}

    /// <summary>
    /// Deletes a contract async
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task DeleteAsync(int id)
    {
        var contract = await _db.Contracts.FindAsync(id);
        if (contract != null)
        {
            _db.Contracts.Remove(contract);
            await _db.SaveChangesAsync();
        };
    }

    /// <summary>
    /// Deprecated
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    //public ContractModel Get(int id)
    //{
    //    return _db.Contracts.Find(id);
    //}

    /// <summary>
    /// Gets a contract async
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ContractModel> GetAsync(int id)
    {
        return await _db.Contracts.FindAsync(id);
    }

    /// <summary>
    /// Deprecated
    /// </summary>
    /// <returns></returns>
    public List<ContractModel> ListAll()
    {
        return _db.Contracts.ToList();
    }

    /// <summary>
    /// Gets all contracts async
    /// </summary>
    /// <returns></returns>
    public async Task<List<ContractModel>> ListAllAsync()
    {
        return await _db.Contracts.ToListAsync();
    }

    /// <summary>
    /// Deprecated
    /// </summary>
    /// <param name="contract"></param>
    /// <returns></returns>
    public ContractModel Update(ContractModel contract)
    {
        var dbContract = _db.Contracts.Find(contract.Id);
        if (dbContract != null)
        {
            dbContract = contract;
            _db.SaveChanges();
        }

        return dbContract;
    }

    /// <summary>
    /// Updates a contract async
    /// </summary>
    /// <param name="contract"></param>
    /// <returns></returns>
    public async Task<ContractModel> UpdateAsync(ContractModel contract)
    {
        var dbContract = await _db.Contracts.FindAsync(contract.Id);
        if (dbContract != null)
        {
            dbContract = contract;
            await _db.SaveChangesAsync();
        }

        return dbContract;
    }

    /// <summary>
    /// Deprecated
    /// </summary>
    //public void DeleteAll()
    //{
    //    var contracts = _db.Contracts.ToList();
    //    if (contracts != null)
    //    {
    //        _db.Contracts.RemoveRange(contracts);
    //        _db.SaveChanges();
    //    }
    //}

    /// <summary>
    /// Deletes all contracts async
    /// </summary>
    /// <returns></returns>
    public async Task DeleteAllAsync()
    {
        var contracts = await _db.Contracts.ToListAsync();
        if (contracts != null)
        {
            _db.Contracts.RemoveRange(contracts);
            await _db.SaveChangesAsync();
        }
    }
}
