using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Stuntman.Web.Components.Forms
{
    public partial class ContractDetailsForm : ComponentBase
    {
        [Parameter]
        public int? Id { get; set; }

        [Parameter]
        public int? UserId { get; set; }

        private ContractModel _contract = new ContractModel();

        private bool _isManager { get; set; } = false;

        private string[] _departments;

        protected override async Task OnParametersSetAsync()
        {
            var allDepartments = await _departmentService.ListAllAsync();
            _departments = allDepartments.Select(d => d.DisplayName).Distinct().ToArray();
        }

        protected override async Task OnInitializedAsync()
        {
            if (Id != null)
            {
                _contract = await _contractService.GetAsync(Id.Value);
            }
        }

        protected async Task Save()
        {
            try
            {
                var department = _departmentService.ListAllAsync().GetAwaiter().GetResult().Where(d => d.DisplayName == _contract.Department).FirstOrDefault();
                _contract.DepartmentExternalId = department.ExternalId;
                _contract.CostCenter = department.DisplayName.Substring(0, 1);
                if (Id != null)
                {
                    await _contractService.UpdateAsync(_contract);
                    _snackbar.Add("Contract updated successfully", severity: Severity.Success);
                }
                else
                {
                    if (_isManager == false)
                    {
                        _contract.IsManager = 0;
                    }
                    else
                    {
                        _contract.IsManager = 1;
                    }
                    _contract.UserId = UserId.Value;
                    _contract.UserExternalId = $"STUNTMAN{_contract.UserId}";
                    await _contractService.CreateAsync(_contract);
                    _snackbar.Add("Contract created successfully", severity: Severity.Success);
                }
            }
            catch (Exception ex)
            {
                _snackbar.Add($"Error: {ex.Message}", severity: Severity.Error);
            }
        }

        private async Task<IEnumerable<string>> SearchDepartment(string value)
        {
            return _departments.Search(value);
        }

        private async void NavigateBack()
        {
            await _jsRuntime.InvokeVoidAsync("history.go", -1);
        }
    }
}
