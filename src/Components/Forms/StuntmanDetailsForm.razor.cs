using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Stuntman.Web.Components.Forms
{
    public partial class StuntmanDetailsForm : ComponentBase
    {
        [Parameter]
        public int? Id { get; set; }

        private StuntmanModel _stuntman = new StuntmanModel();

        private List<StuntmanModel> _allStuntman;

        private List<ContractModel> _contracts;

        private string _givenName;

        private string _familyName;

        private string _initials;

        private string _businessEmail;

        private string _company;

        private bool _isActive { get; set; } = false;

        private string[] _languages =
        {
            "af_ZA", "ar", "az", "cz",
            "de", "de_AT", "de_CH", "el",
            "en", "en_AU", "en_AU-ocker",
            "en_BORK", "en_CA", "en_GB", "en_IE", "en_IND",
            "en_NG", "en_ZA", "es", "es_MX", "fa",
            "fi", "fr", "fr_CA", "fr_CH",
            "ge", "hr", "id_ID", "it",
            "ja", "ko", "lv", "nb_NO",
            "ne", "nl", "nl_BE", "pl",
            "pl_BR", "pl_PT", "ro", "ru",
            "sk", "sv", "tr", "uk", "vi",
            "zh_CN", "zh_TW", "zu_ZA",
        };

        private string[] _companies;

        protected override void OnParametersSet()
        {
            _companies = _allStuntman.Select(m => m.Company).Distinct().ToArray();
        }

        protected override async Task OnInitializedAsync()
        {
            _allStuntman = await _stuntmanService.ListAllAsync();
            if (Id != null)
            {
                _stuntman = await _stuntmanService.GetAsync(Id.Value);
                _givenName = _stuntman.GivenName;
                _familyName = _stuntman.FamilyName;
                _initials = _stuntman.Initials;
                _company = _stuntman.Company;
                _businessEmail = _stuntman.BusinessEmailAddress;
                _contracts = _contractService.ListAllAsync().GetAwaiter().GetResult().Where(c => c.UserId == _stuntman.UserId).OrderByDescending(c => c.HoursPerWeek).ToList();
            }
        }

        protected async Task Save()
        {
            try
            {
                if (Id != null)
                {
                    _stuntman.DisplayName = $"{_stuntman.GivenName} {_stuntman.FamilyName}";
                    _stuntman.UserName = _stuntman.BusinessEmailAddress;
                    _stuntman.GivenName = _givenName;
                    _stuntman.FamilyName = _familyName;
                    _stuntman.Initials = _initials;
                    _stuntman.Company = _company;
                    _stuntman.BusinessEmailAddress = _businessEmail;
                    _stuntman.DisplayName = $"{_givenName} {_familyName}";
                    await _stuntmanService.UpdateAsync(_stuntman);
                    _snackbar.Add("Stuntman updated successfully", severity: Severity.Success);
                }
                else
                {
                    if (_isActive == false)
                    {
                        _stuntman.IsActive = 0;
                    }
                    else
                    {
                        _stuntman.IsActive = 1;
                    }

                    var lastUserId = _allStuntman.Select(s => s.UserId).Max();
                    lastUserId++;
                    _stuntman.UserId = lastUserId;
                    _stuntman.ExternalId = $"STUNTMAN{lastUserId}";
                    _stuntman.DisplayName = $"{_stuntman.GivenName} {_stuntman.FamilyName}";
                    _stuntman.UserName = _stuntman.BusinessEmailAddress;
                    _stuntman.GivenName = _givenName;
                    _stuntman.FamilyName = _familyName;
                    _stuntman.Initials = _initials;
                    _stuntman.Company = _company;
                    _stuntman.BusinessEmailAddress = _businessEmail;
                    _stuntman.DisplayName = $"{_givenName} {_familyName}";
                    var newStuntman = _stuntmanService.CreateAsync(_stuntman);
                    Id = newStuntman.Id;
                    await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false); ;
                    _snackbar.Add("Stuntman created successfully", severity: Severity.Success);
                }
            }
            catch (Exception ex)
            {
                _snackbar.Add($"Error: {ex.Message}", severity: Severity.Error);
            }
        }

        private async Task<IEnumerable<string>> SearchLanguage(string value)
        {
            return _languages.Search(value);
        }

        private async Task<IEnumerable<string>> SearchCompany(string value)
        {
            return _companies.Search(value);
        }
        
        private async Task Delete(int? Id)
        {
            var parameters = new DialogParameters();
            parameters.Add("Page", "contract");
            parameters.Add("ContentText", "Do you really want to delete the contract record for this stuntman? This process cannot be undone.");
            parameters.Add("Id", Id);

            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

            var dialog = DialogService.Show<ConfirmationDialog>($"Delete record", parameters, options);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                _snackbar.Add($"Contract has been deleted!", Severity.Success);
                await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
            }
        }

        private async void NavigateBack()
        {
            await _jsRuntime.InvokeVoidAsync("history.go", -1);
        }
    }
}
