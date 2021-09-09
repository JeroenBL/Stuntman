using PSStuntman.Models;
using PSStuntman.Services;
using System.Collections.Generic;

namespace StuntmanAPI
{
    public class DataAccess
    {
        private SqliteDataAccessService _slqliteDataAccessService;

        public DataAccess()
        {
            _slqliteDataAccessService = new SqliteDataAccessService();
        }

        public List<StuntmanModel> GetStuntman()
        {
            var stuntman = _slqliteDataAccessService.ReadFromDatabase<StuntmanModel>("select * from Stuntman");

            return stuntman;
        }

        public List<DepartmentModel> GetDepartments()
        {
            var departments = _slqliteDataAccessService.ReadFromDatabase<DepartmentModel>("select * from Departments");

            return departments;
        }
    }
}
