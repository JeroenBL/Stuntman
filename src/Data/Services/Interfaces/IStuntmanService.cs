namespace Stuntman.Web.Data.Services.Interfaces;

public interface IStuntmanService
{
    //Create
    //StuntmanModel Create(StuntmanModel stuntman);
    Task<StuntmanModel> CreateAsync(StuntmanModel stuntman);

    //Read
    //StuntmanModel Get(int id);
    Task<StuntmanModel> GetAsync(int id);

    //Update
    //StuntmanModel Update(StuntmanModel stuntman);
    Task<StuntmanModel> UpdateAsync(StuntmanModel stuntman);

    //Delete
    //void Delete(int id);
    Task DeleteAsync(int id);

    //List
    Task<List<StuntmanModel>> ListAllAsync();

    //Delete All
    //void DeleteAll();
    Task DeleteAllAsync();
}
