namespace Stuntman.Web.Data.Services;

public class StuntmanService : IStuntmanService
{
    private readonly ApplicationDbContext _db;

    public StuntmanService(ApplicationDbContext db)
    {
        _db = db;
    }
    
    /// <summary>
    /// Deprecated
    /// </summary>
    /// <param name="stuntman"></param>
    /// <returns></returns>
    //public StuntmanModel Create(StuntmanModel stuntman)
    //{
    //    Guid guid = Guid.NewGuid();
    //    var newStuntman = _db.Stuntman.Add(stuntman);
    //    newStuntman.Entity.UserGuid = guid.ToString();
    //    _db.SaveChanges();

    //    return newStuntman.Entity;
    //}

    /// <summary>
    /// Creates a new stuntman async
    /// </summary>
    /// <param name="stuntman"></param>
    /// <returns></returns>
    public async Task<StuntmanModel> CreateAsync(StuntmanModel stuntman)
    {
        var newStuntman = await _db.Stuntman.AddAsync(stuntman);
        await _db.SaveChangesAsync();

        return newStuntman.Entity;
    }

    /// <summary>
    /// Deprecated
    /// </summary>
    /// <param name="id"></param>
    //public void Delete(int id)
    //{
    //    var stuntman = _db.Stuntman.Find(id);
    //    if (stuntman != null)
    //    {
    //        _db.Stuntman.Remove(stuntman);
    //        _db.SaveChanges();
    //    };
    //}

    /// <summary>
    /// Deletes a stuntman async
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task DeleteAsync(int id)
    {
        var stuntman = await _db.Stuntman.FindAsync(id);
        if (stuntman != null)
        {
            _db.Stuntman.Remove(stuntman);
            await _db.SaveChangesAsync();
        };
    }

    /// <summary>
    /// Deprecated
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    //public StuntmanModel Get(int id)
    //{
    //    return _db.Stuntman.Find(id);
    //}
    
    /// <summary>
    /// Gets a stuntman async
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<StuntmanModel> GetAsync(int id)
    {
        return await _db.Stuntman.FindAsync(id);
    }

    /// <summary>
    /// Gets all stuntman async
    /// </summary>
    /// <returns></returns>
    public async Task<List<StuntmanModel>> ListAllAsync()
    {
        return await _db.Stuntman.ToListAsync();
    }

    //public StuntmanModel Update(StuntmanModel stuntman)
    //{
    //    var dbStuntman = _db.Stuntman.Find(stuntman.Id);
    //    if (dbStuntman != null)
    //    {
    //        dbStuntman = stuntman;
    //        _db.SaveChanges();
    //    }

    //    return dbStuntman;
    //}

    /// <summary>
    /// Updates a stuntman async
    /// </summary>
    /// <param name="stuntman"></param>
    /// <returns></returns>
    public async Task<StuntmanModel> UpdateAsync(StuntmanModel stuntman)
    {
        var dbStuntman = await _db.Stuntman.FindAsync(stuntman.Id);
        if (dbStuntman != null)
        {
            dbStuntman = stuntman;
            await _db.SaveChangesAsync();
        }

        return dbStuntman;
    }

    //public void DeleteAll()
    //{
    //    var stuntman = _db.Stuntman.ToList();
    //    if (stuntman != null)
    //    {
    //        _db.Stuntman.RemoveRange(stuntman);
    //        _db.SaveChanges();
    //    }
    //}

    /// <summary>
    /// Deletes all stuntman async
    /// </summary>
    /// <returns></returns>
    public async Task DeleteAllAsync()
    {
        var stuntman = await _db.Stuntman.ToListAsync();
        if (stuntman != null)
        {
            _db.Stuntman.RemoveRange(stuntman);
            await _db.SaveChangesAsync();
        }
    }
}
