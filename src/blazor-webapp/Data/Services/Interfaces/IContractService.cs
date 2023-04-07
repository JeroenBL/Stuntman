namespace Stuntman.Web.Data.Services.Interfaces;

public interface IContractService
{
    //Create
    //ContractModel Create(ContractModel contract);
    Task<ContractModel> CreateAsync(ContractModel contract);

    //Read
    //ContractModel Get(int id);
    Task<ContractModel> GetAsync(int id);

    //Update
    //ContractModel Update(ContractModel contract);
    Task<ContractModel> UpdateAsync(ContractModel contract);

    //Delete
    //void Delete(int id);
    Task DeleteAsync(int id);

    //List
    //List<ContractModel> ListAll();
    Task<List<ContractModel>> ListAllAsync();

    //Delete All
    //void DeleteAll();
    Task DeleteAllAsync();
}
