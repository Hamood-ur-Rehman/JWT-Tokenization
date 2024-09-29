using Jwt_Authentication.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Jwt_Authentication.Utility
{
    public  class CommonUtility
    {

        public static UserModel AuthenticateUser(UserModel userModel)
        {
            UserModel userModelResponse = null;
            if (userModel.UserName.ToLower()=="hamood")
            {
                userModelResponse = new UserModel { UserName = userModel.UserName, EmailAddress = userModel.EmailAddress, Password = userModel.Password };
            }
            return userModelResponse;
        }
        public static string GenerateWebToken(UserModel userModel)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettingHelper.GetConfigValue("JWT:Key")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,userModel.UserName),
                new Claim("Password",userModel.Password),
                new Claim(JwtRegisteredClaimNames.Email,userModel.EmailAddress),
            };
            var token = new JwtSecurityToken(AppSettingHelper.GetConfigValue("JWT:Issuer"), AppSettingHelper.GetConfigValue("JWT:Issuer"), claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
