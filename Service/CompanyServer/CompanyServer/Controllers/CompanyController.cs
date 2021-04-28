using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyServer.Entities;
using CompanyServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository m_companyRepository;
        public CompanyController(ICompanyRepository companyRepository)
        {
            m_companyRepository = companyRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Company>>> Get()
        {
            var companies = await m_companyRepository.GetCompanies();
            return Ok(companies);
        }

    }
}
