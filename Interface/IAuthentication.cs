using Jwt_Authentication.Model;

namespace Jwt_Authentication.Interface
{
    public interface IAuthentication
    {
        public Task<ApiResponse<string>> GetAuthorize(UserModel userModel);
    }
}
