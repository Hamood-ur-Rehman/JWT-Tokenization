using Jwt_Authentication.Interface;
using Jwt_Authentication.Model;
using Jwt_Authentication.Utility;

namespace Jwt_Authentication.Business
{
    public class AuthenticateBusiness : IAuthentication
    {
        public async Task<ApiResponse<string>> GetAuthorize(UserModel userModel)
        {
            var user = CommonUtility.AuthenticateUser(userModel);
            if (user != null)
            {
                var token = CommonUtility.GenerateWebToken(user);
                return new ApiResponse<string>
                {
                    Data = token
                };
            }
            return new ApiResponse<string>
            {
                StatusCode = 400,
                Message = "Un Authorized",
                Data = null
            };
        }
    }
}
