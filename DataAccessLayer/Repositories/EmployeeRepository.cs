using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;

namespace DataAccessLayer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbWrapper<Employee> _employeeDbWrapper;

        public EmployeeRepository(IDbWrapper<Employee> employeeDbWrapper)
        {
            _employeeDbWrapper = employeeDbWrapper;
        }
        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _employeeDbWrapper.FindAllAsync();
        }

        public async Task<bool> SaveEmployee(Employee employee)
        {
            var itemRepo = await _employeeDbWrapper.FindAsync(t =>
                t.SiteId.Equals(employee.SiteId) && t.EmployeeCode.Equals(employee.EmployeeCode));
            if (itemRepo?.FirstOrDefault() != null)
            {
                var current = itemRepo?.FirstOrDefault();
                current.EmployeeName = employee.EmployeeName;
                current.Occupation = employee.Occupation;
                current.EmployeeStatus = employee.EmployeeStatus;
                current.EmailAddress = employee.EmailAddress;
                current.Phone = employee.Phone;
                current.LastModified = employee.LastModified;
                return await _employeeDbWrapper.UpdateAsync(current);
            }

            return await _employeeDbWrapper.InsertAsync(employee);
        }
    }
}
