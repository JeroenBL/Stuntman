using PSStuntman.Models;
using PSStuntman.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuntmanAPI
{
    public class DataAccess
    {
        private SqliteDataAccessService _slqliteDataAccessService;

        public DataAccess()
        {
            _slqliteDataAccessService = new SqliteDataAccessService();
        }

        public async Task<List<StuntmanModel>> GetStuntman()
        {
            var stuntman = await _slqliteDataAccessService.GetRecordFromDatabase<StuntmanModel>("select * from Stuntman").ConfigureAwait(false);

            return stuntman;
        }

        public async Task<StuntmanModel> GetStuntmanById(int Id)
        {
            var stuntman = await _slqliteDataAccessService.GetRecordFromDatabase<StuntmanModel>($"select * from Stuntman where Id = {Id}").ConfigureAwait(false);

            return stuntman[0];
        }

        public async Task<List<DepartmentModel>> GetDepartments()
        {
            var departments = await _slqliteDataAccessService.GetRecordFromDatabase<DepartmentModel>("select * from Departments").ConfigureAwait(false);

            return departments;
        }

        public async Task<DepartmentModel> GetDepartmentById(int Id)
        {
            var department = await _slqliteDataAccessService.GetRecordFromDatabase<DepartmentModel>($"select * from Departments where Id = {Id}").ConfigureAwait(false);

            return department[0];
        }
    }
}
