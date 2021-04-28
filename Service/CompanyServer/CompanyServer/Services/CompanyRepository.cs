using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyServer.Entities;

namespace CompanyServer.Services
{
    public class CompanyRepository : ICompanyRepository
    {
        public CompanyRepository()
        {
            InitCompany();
        }

        private List<Company> m_companies;

        private void InitCompany()
        {
            m_companies = new List<Company>
            {
                new Company{ID = 1, Name = "震有科技", Address = "南山区粤海街道高新南社区彩讯科创中心"},
                new Company{ID = 2, Name = "海能达", Address = "南山区北环大道1008号海能达大厦"},
            };
        }

        #region Implementation of ICompanyRepository

        /// <summary>
        /// 获取所有公司
        /// </summary>
        /// <returns></returns>
        public async Task<List<Company>> GetCompanies()
        {
            return m_companies;
        }

        #endregion
    }
}
