namespace Stuntman.Web.Data.Models;

public class ContractModel
{
    public ContractModel(int userId)
    {
        UserId = userId;
    }

    public ContractModel() { }

    public int Id { get; set; }
    public int UserId { get; set; }
    public string UserExternalId { get; set; }
    public string Title { get; set; }
    public int IsManager { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int HoursPerWeek { get; set; }
    public string Department { get; set; }
    public int DepartmentExternalId { get; set; }
    public string CostCenter { get; set; }
    public string ContractGuid { get; set; }
}
