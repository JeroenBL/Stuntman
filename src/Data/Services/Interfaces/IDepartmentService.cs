namespace Stuntman.Web.Data.Services.Interfaces;

public interface IDepartmentService
{
    //Create
    //DepartmentModel Create(DepartmentModel department);
    Task<DepartmentModel> CreateAsync(DepartmentModel department);

    //Read
    //DepartmentModel Get(int id);
    Task<DepartmentModel> GetAsync(int id);

    //Update
    //DepartmentModel Update(DepartmentModel department);
    Task<DepartmentModel> UpdateAsync(DepartmentModel department);

    //Delete
    //void Delete(int id);
    Task DeleteAsync(int id);

    //List
    //List<DepartmentModel> ListAll();
    Task<List<DepartmentModel>> ListAllAsync();
 
    //Delete All
    //void DeleteAll();
    Task DeleteAllAsync();    
}
