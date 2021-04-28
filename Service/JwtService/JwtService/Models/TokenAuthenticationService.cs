using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JwtService.Models
{
    public class TokenAuthenticationService : IAuthenticateService
    {
        private readonly IUserService m_userService;
        private readonly TokenManagement m_tokenManagement;

        public TokenAuthenticationService(IUserService userService, IOptions<TokenManagement> tokenManagement)
        {
            m_userService = userService;
            m_tokenManagement = tokenManagement.Value;
        }

        #region Implementation of IAuthenticateService

        public bool IsAuthenticated(LoginRequestDTO request, out string token)
        {
            token = string.Empty;
            if (!m_userService.IsValid(request))
                return false;
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.Username)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(m_tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(m_tokenManagement.Issuer, m_tokenManagement.Audience, claims,
                expires: DateTime.Now.AddMinutes(m_tokenManagement.AccessExpiration),
                signingCredentials: credentials);
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return true;
        }

        #endregion
    }
}
