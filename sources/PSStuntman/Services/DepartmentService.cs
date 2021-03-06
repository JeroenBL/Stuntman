using PSStuntman.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PSStuntman.Services
{
    public class DepartmentService
    {
        private List<DepartmentModel> _departments;
        private Random _random;

        public DepartmentService()
        {
            _departments = new List<DepartmentModel>();
            _random = new Random();
        }

        public List<DepartmentModel> CreateDepartmentsAndAssignManager(List<StuntmanModel> stuntman)
        {
            var departmentExternalId = 100000;
            var groupedStuntmanByDepartment = stuntman.GroupBy(s => s.Department);
            foreach (var stman in groupedStuntmanByDepartment)
            {               
                departmentExternalId++;

                var currentStuntman = stman.ElementAt(_random.Next(0));
                currentStuntman.IsManager = 1;

                foreach (var st in stman)
                {
                    st.DepartmentExternalId = departmentExternalId;
                }

                _departments.Add(new DepartmentModel { DisplayName = currentStuntman.Department, ExternalId = departmentExternalId, ManagerExternalId = currentStuntman.ExternalId });                
            }

            return _departments;
        }
    }
}
