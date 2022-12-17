using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using WebApi.App_Start;
using WebApi.Models;


namespace WebApi.Controllers
{
    [CustomExceptionFilter]
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [Route("api/Company/GetAll")]
        // GET api/<controller>
        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            try
            {
                var items = await _companyService.GetAllCompanies();
                return _mapper.Map<IEnumerable<CompanyDto>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        // GET api/<controller>/5
        public async Task<CompanyDto> Get(string companyCode)
        {
            try
            {
            var item = await _companyService.GetCompanyByCode(companyCode);
                int i = 1;
                int d = i / 0;
            return _mapper.Map<CompanyDto>(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        // POST api/<controller>
        public async Task<bool> Post([FromBody] CompanyDto companyDto)
        {
            try
            {
            CompanyInfo companyInfo = _mapper.Map<CompanyInfo>(companyDto);
            var item = await _companyService.AddCompany(companyInfo);
            return _mapper.Map<bool>(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        // PUT api/<controller>/5
        public async Task<bool> Put([FromBody] CompanyDto companyDto)
        {
            CompanyInfo companyInfo = _mapper.Map<CompanyInfo>(companyDto);
            var item = await _companyService.AddCompany(companyInfo);
            return _mapper.Map<bool>(item);
        }

        
        // DELETE api/<controller>/5
        public async Task<bool> Delete(string companyCode)
        {
            var item = await _companyService.DeleteCompany(companyCode);
            return _mapper.Map<bool>(item);
        }
    }
}