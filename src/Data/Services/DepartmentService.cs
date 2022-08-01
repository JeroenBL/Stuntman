namespace Stuntman.Web.Data.Services;

public class DepartmentService : IDepartmentService
{
    private readonly ApplicationDbContext _db;
    
    public DepartmentService(ApplicationDbContext db)
    {
        _db = db;
    }
    
    /// <summary>
    /// Deprecated
    /// </summary>
    /// <param name="department"></param>
    /// <returns></returns>
    //public DepartmentModel Create(DepartmentModel department)
    //{
    //    var newDepartment = _db.Departments.Add(department);
    //    _db.SaveChanges();

    //    return newDepartment.Entity;
    //}

    /// <summary>
    /// Creates a new department async
    /// </summary>
    /// <param name="department"></param>
    /// <returns></returns>
    public async Task<DepartmentModel> CreateAsync(DepartmentModel department)
    {
        var newDepartment = await _db.Departments.AddAsync(department);
        await _db.SaveChangesAsync();

        return newDepartment.Entity;
    }

    /// <summary>
    /// Deprecated
    /// </summary>
    /// <param name="id"></param>
    //public void Delete(int id)
    //{
    //    var department = _db.Departments.Find(id);
    //    if (department != null)
    //    {
    //        _db.Departments.Remove(department);
    //        _db.SaveChanges();
    //    };
    //}

    /// <summary>
    /// Deletes a department async
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task DeleteAsync(int id)
    {
        var department = await _db.Departments.FindAsync(id);
        if (department != null)
        {
            _db.Departments.Remove(department);
            await _db.SaveChangesAsync();
        };
    }

    /// <summary>
    /// Deprecated
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    //public DepartmentModel Get(int id)
    //{
    //    return _db.Departments.Find(id);
    //}

    /// <summary>
    /// Gets a department async
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<DepartmentModel> GetAsync(int id)
    {
        return await _db.Departments.FindAsync(id);
    }

    /// <summary>
    /// Deprecated
    /// </summary>
    /// <returns></returns>
    //public List<DepartmentModel> ListAll()
    //{
    //    return _db.Departments.ToList();
    //}

    /// <summary>
    /// Gets all departments async
    /// </summary>
    /// <returns></returns>
    public async Task<List<DepartmentModel>> ListAllAsync()
    {
        return await _db.Departments.ToListAsync();
    }

    /// <summary>
    /// Deprecated
    /// </summary>
    /// <param name="department"></param>
    /// <returns></returns>
    //public DepartmentModel Update(DepartmentModel department)
    //{
    //    var dbDepartment = _db.Departments.Find(department.Id);
    //    if (dbDepartment != null)
    //    {
    //        dbDepartment = department;
    //        _db.SaveChanges();
    //    }

    //    return dbDepartment;
    //}

    /// <summary>
    /// Updates a department async
    /// </summary>
    /// <param name="department"></param>
    /// <returns></returns>
    public async Task<DepartmentModel> UpdateAsync(DepartmentModel department)
    {
        var dbDepartment = await _db.Departments.FindAsync(department.Id);
        if (dbDepartment != null)
        {
            dbDepartment = department;
            await _db.SaveChangesAsync();
        }

        return dbDepartment;
    }

    /// <summary>
    /// Deprecated
    /// </summary>
    //public void DeleteAll()
    //{
    //    var departments = _db.Departments.ToList();
    //    if (departments != null)
    //    {
    //        _db.Departments.RemoveRange(departments);
    //        _db.SaveChanges();
    //    }
    //}

    /// <summary>
    /// Deletes all departments async
    /// </summary>
    /// <returns></returns>
    public async Task DeleteAllAsync()
    {
        var departments = await _db.Departments.ToListAsync();
        if (departments != null)
        {
            _db.Departments.RemoveRange(departments);
            await _db.SaveChangesAsync();
        }
    }
}
