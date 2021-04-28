using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyServer.Entities;

namespace CompanyServer.Services
{
    public interface ICompanyRepository
    {
        /// <summary>
        /// 获取所有公司
        /// </summary>
        /// <returns></returns>
        Task<List<Company>> GetCompanies();
    }
}
