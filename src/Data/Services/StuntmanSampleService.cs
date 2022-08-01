namespace Stuntman.Web.Data.Services;

public class StuntmanSampleService
{
    private readonly Random _random = new();

    /// <summary>
    /// Public method to create the faker data
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="locale"></param>
    /// <returns></returns>
    public List<StuntmanModel> CreateStuntman(int amount, string locale)
    {
        var _locale = string.IsNullOrEmpty(locale) ? $"nl" : locale;
        var _companyName = GetRandomCompany();

        List<StuntmanModel> stuntman = new List<StuntmanModel>();

        int userId = _random.Next(10000, 90000);
        Faker<StuntmanModel> faker = new Faker<StuntmanModel>(_locale)
            .CustomInstantiator(f => new StuntmanModel(userId++))
            .RuleFor(s => s.UserId, f => userId)
            .RuleFor(s => s.ExternalId, (f, s) => $"STUNTMAN{userId}")
            .RuleFor(s => s.GivenName, f => f.Person.FirstName)
            .RuleFor(s => s.FamilyName, f => f.Person.LastName)
            .RuleFor(s => s.DisplayName, (f, s) => $"{s.GivenName} {s.FamilyName}")
            .RuleFor(s => s.UserName, (f, s) => $"{s.GivenName.Substring(0, 1)}.{s.FamilyName}@{_companyName}.nl")
            .RuleFor(s => s.Initials, (f, s) => $"{s.GivenName.Substring(0, 1)}.{s.FamilyName.Substring(0, 1)}")
            .RuleFor(s => s.PersonalEmailAddress, f => f.Person.Email)
            .RuleFor(s => s.PersonalPhoneNumber, f => f.Person.Phone)
            .RuleFor(s => s.BusinessEmailAddress, (f, s) => $"{s.GivenName.Substring(0, 1)}.{s.FamilyName}@{_companyName}.nl")
            .RuleFor(s => s.BusinessPhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(s => s.BirthDate, f => f.Person.DateOfBirth)
            .RuleFor(s => s.BirthPlace, f => f.Address.City())
            .RuleFor(s => s.Language, f => f.Locale)
            .RuleFor(s => s.City, f => f.Address.City())
            .RuleFor(s => s.Street, f => f.Address.StreetName())
            .RuleFor(s => s.HouseNumber, (f, s) => (_random.Next(0, 200)))
            .RuleFor(s => s.ZipCode, f => f.Address.ZipCode())
            .RuleFor(s => s.IsActive, f => f.PickRandomParam(new int[] { 0, 1 }))
            .RuleFor(s => s.UserGuid, f => Guid.NewGuid().ToString())
            .RuleFor(s => s.Company, f => _companyName);

        return stuntman = faker.Generate(amount);
    }

    /// <summary>
    /// Craete the fake contracts
    /// </summary>
    /// <param name="locale"></param>
    /// <param name="userId"></param>
    /// <param name="maxContracts"></param>
    /// <returns></returns>
    public List<ContractModel> CreateContract(string locale, int userId, int maxContracts = 3)
    {
        var _locale = string.IsNullOrEmpty(locale) ? $"nl" : locale;
        int maxAcountOfContracts = _random.Next(1, maxContracts);

        List<ContractModel> contracts = new List<ContractModel>();

        while (contracts.Count < maxAcountOfContracts)
        {
            Faker<ContractModel> faker = new Faker<ContractModel>(_locale)
                .CustomInstantiator(f => new ContractModel(userId))
                .RuleFor(s => s.UserId, f => userId)
                .RuleFor(s => s.UserExternalId, (f, s) => $"STUNTMAN{userId}")
                .RuleFor(s => s.Title, f => f.Name.JobTitle())

                // Assign a startDate between this day and 5 years back
                .RuleFor(s => s.StartDate, f => f.Date.Past(5))

                // Assign the endDate between this day and 5 years in the future
                .RuleFor(s => s.EndDate, f => f.Date.Future(5))

                .RuleFor(s => s.HoursPerWeek, f => f.PickRandom<int>(8, 16, 20))
                .RuleFor(s => s.Department, f => f.PickRandom<EnumDepartments>().ToString())
                .RuleFor(s => s.CostCenter, (f, s) => $"{s.Department.Substring(0, 2).ToUpper()}")
                .RuleFor(s => s.ContractGuid, f => Guid.NewGuid().ToString());

            contracts = faker.Generate(maxAcountOfContracts);
        }
        return contracts; 
    }

    /// <summary>
    /// Create departments and assign managers to departments based on data from the contract model
    /// </summary>
    /// <param name="contracts"></param>
    /// <returns></returns>
    public List<DepartmentModel> CreateDepartmentsAndAssignManager(List<ContractModel> contracts)
    {
        List<DepartmentModel> departments = new List<DepartmentModel>();
        var departmentExternalId = 100000;
        var groupContractsByDepartment = contracts.GroupBy(s => s.Department);
        foreach (var contractDepartment in groupContractsByDepartment)
        {
            departmentExternalId++;

            var currentContract = contractDepartment.ElementAt(_random.Next(0));
            currentContract.IsManager = 1;

            foreach (var ct in contractDepartment)
            {
                ct.DepartmentExternalId = departmentExternalId;
            }

            departments.Add(new DepartmentModel
            {
                DisplayName = currentContract.Department,
                ExternalId = departmentExternalId,
                ManagerExternalId = currentContract.UserExternalId
            });
        }

        return departments;
    }

    private string GetRandomCompany()
    {
        var companies = Enum.GetValues(typeof(EnumCompanies));
        var companyName = companies.GetValue(_random.Next(companies.Length)).ToString();

        return companyName;
    }

    private enum EnumCompanies
    {
        Bluejam,
        Buzzdog,
        Topiczoom,
        Realcube,
        Yodoo,
        Fivechat,
        Katz,
        Edgeify,
        Skibox,
        Yabadooda,
        Kayveo,
        Skilith,
        Tavu,
        Browsebug,
        Kwimbee,
        Eabox,
        Quatz,
        Realpoint,
        Yata,
        Flashspan,
        Yadel,
        Eare,
        Divanoodle,
        Jabbersphere,
        Tagchat
    }
    
    public enum EnumDepartments
    {
        Engineering,
        HR,
        RD,
        Support,
        Legal,
        Marketing,
        Accounting,
        Finance,
        IT,
        Staffing,
        Sales,
        Recruitment,
        Management
    }
}
