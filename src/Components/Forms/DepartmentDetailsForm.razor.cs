using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Stuntman.Web.Components.Forms
{
    public partial class DepartmentDetailsForm : ComponentBase
    {
        [Parameter]
        public int? Id { get; set; }

        private DepartmentModel _department = new DepartmentModel();

        private List<DepartmentModel> _allDepartments = new List<DepartmentModel>();
        
        private List<ContractModel> _allContracts;

        private List<ContractModel> _allManagerContracts;

        private string[] _managerExternalIds;

        private string[] _departmentConnectedContractsExternalds;

        protected override async Task OnParametersSetAsync()
        {
            _allManagerContracts = _allContracts.Where(c => c.IsManager == 1).ToList();
            _managerExternalIds = _allManagerContracts.Select(m => m.UserExternalId).Distinct().ToArray();
        }

        protected override async Task OnInitializedAsync()
        {
            _allDepartments = await _departmentService.ListAllAsync();
            _allContracts = await _contractService.ListAllAsync();
            _allManagerContracts = _allContracts.Where(c => c.IsManager == 1).ToList();
            _managerExternalIds = _allManagerContracts.Select(m => m.UserExternalId).Distinct().ToArray();

            if (Id != null)
            {
                List<ContractModel> departmentConnectedContracts = new List<ContractModel>();
                _department = await _departmentService.GetAsync(Id.Value);
                var allContractsInDepartment = _allContracts.Where(c => c.Department == _department.DisplayName).ToList();
                foreach (var contract in allContractsInDepartment)
                {
                    departmentConnectedContracts.Add(contract);
                }

                _departmentConnectedContractsExternalds = departmentConnectedContracts.Select(c => c.UserExternalId).Distinct().ToArray();
            }
        }

        protected async Task Save()
        {
            try
            {
                if (Id != null)
                {
                    await _departmentService.UpdateAsync(_department);
                    _snackbar.Add("Department updated successfully", severity: Severity.Success);
                }
                else
                {
                    var lastDepartmentExternalId = _allDepartments.Select(d => d.ExternalId).Max();
                    lastDepartmentExternalId++;
                    _department.ExternalId = lastDepartmentExternalId;
                    await _departmentService.CreateAsync(_department);
                    _snackbar.Add("Department created successfully", severity: Severity.Success);
                }
            }
            catch (Exception ex)
            {
                _snackbar.Add($"Error: {ex.Message}", severity: Severity.Error);
            }
        }

        private async Task<IEnumerable<string>> SearchManager(string value)
        {
            return _managerExternalIds.Search(value);
        }

        private async Task<IEnumerable<string>> SearchMember(string value)
        {
            return _departmentConnectedContractsExternalds.Search(value);
        }

        private async void NavigateBack()
        {
            await _jsRuntime.InvokeVoidAsync("history.go", -1);
        }
    }
}
