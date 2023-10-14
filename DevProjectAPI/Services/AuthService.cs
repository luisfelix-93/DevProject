using DevProjectAPI.Infrastructure.DTO;
using DevProjectAPI.Infrastructure.Entities;
using DevProjectAPI.Infrastructure.Helpers;
using DevProjectAPI.Infrastructure.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DevProjectAPI.Services
{
    public class AuthService
    {
        #region Constructor
        UserRepository _userRepository;
        AppSettings _appSettings;
        public AuthService(UserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }
        #endregion
        #region Methods

        public ReturnDTO Authenticate(string pUsername, string pPassword)
        {
            ReturnDTO returnDTO =
                new ReturnDTO { Success = false, Message = ConstantManager.DefMessageFailAuth, ResultObject = null };

            if(string.IsNullOrEmpty(pUsername) || string.IsNullOrEmpty(pPassword))
            {
                returnDTO.Message = ConstantManager.MessageFailAuthEmpty;
                return returnDTO;
            }

            if (_userRepository.AuthenticateUser(pPassword))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                DateTime dtExpiration = DateTime.UtcNow.AddMinutes(_appSettings.MinutesToExpire);
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                    new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, pUsername),
                        new Claim(ConstantManager.CodeHash, pPassword)
                    });

                SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = dtExpiration,
                    NotBefore = DateTime.UtcNow,
                    Subject = claimsIdentity,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);

                Token token = new Token
                {
                    AccessToken = tokenHandler.WriteToken(securityToken),
                    UserName = pUsername,
                    DateTimeExpiration = dtExpiration,
                    TotalSecondsExpiration = _appSettings.MinutesToExpire * 60
                };

                returnDTO.Success = true;
                returnDTO.ResultObject = token;
                returnDTO.Message = ConstantManager.MessageOK;
                return returnDTO;
            }

            return returnDTO;
        }
        #endregion
    }
}
