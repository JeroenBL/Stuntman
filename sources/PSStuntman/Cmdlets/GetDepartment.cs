using PSStuntman.Models;
using PSStuntman.Services;
using System;
using System.Management.Automation;

namespace PSStuntman.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "Department")]
    [OutputType(typeof(DepartmentModel))]
    public class GetDepartment : PSCmdlet
    {
        private SqliteDataAccessService _sqliteDataAccessService;

        public GetDepartment()
        {
            _sqliteDataAccessService = new SqliteDataAccessService();
        }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Retrieve a department by Id"
        )]
        public string Id { get; set; }

        protected async override void ProcessRecord()
        {
            var query = string.IsNullOrEmpty(Id) ? "select * from Departments" : $"select * from Departments where Id = {Id}";

            try
            {
                var departments = await _sqliteDataAccessService.GetRecordFromDatabase<DepartmentModel>(query).ConfigureAwait(false);
                if (departments.Count < 1)
                {
                    WriteWarning($"Unable to obtain department. Make sure the database is not empty and that the department with id '{Id}' exists.");
                }
                else
                {
                    WriteObject(departments);
                }
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, "Could not retrieve data", ErrorCategory.NotSpecified, null));
            }
        }
    }
}
