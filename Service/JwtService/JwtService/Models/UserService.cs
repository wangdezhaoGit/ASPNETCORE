using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtService
{
    public class UserService : IUserService
    {
        #region Implementation of IUserService

        public bool IsValid(LoginRequestDTO req)
        {
            //模拟测试，默认都是人为验证有效
            return true;
        }

        #endregion
    }
}
