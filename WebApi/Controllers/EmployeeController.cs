using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        // GET: api/Employee
        public async Task<IEnumerable<EmployeeDto>> Get()
        {
            var items = await _employeeService.GetAllEmployee();
            return _mapper.Map<IEnumerable<EmployeeDto>>(items);
        }

        // POST: api/Employee
        public async Task<bool> Post([FromBody] EmployeeInfo employeeDto)
        {
            EmployeeInfo employeeInfo = _mapper.Map<EmployeeInfo>(employeeDto);
            var item = await _employeeService.AddEmployee(employeeInfo);
            return _mapper.Map<bool>(item);
        }
    }
}
