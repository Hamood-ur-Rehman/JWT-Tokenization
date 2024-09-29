using Jwt_Authentication.Business;
using Jwt_Authentication.Interface;
using Jwt_Authentication.Model;
using Jwt_Authentication.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IConfiguration _configuration;
        private IAuthentication _authenticateBusiness;
        public AuthenticationController(IConfiguration configuration, IAuthentication authenticateBusiness)
        {
            _configuration = configuration;
            _authenticateBusiness = authenticateBusiness;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<string>> Authenticate([FromBody] UserModel userModels)
        {
            return await _authenticateBusiness.GetAuthorize(userModels);
        }
    }
}
