namespace Jwt_Authentication.Utility
{
    public class AppSettingHelper
    {
        private static IConfiguration _configuration;
        public static  void  AppSettingConfigure(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public static string GetConfigValue(string Key)
        {
            return _configuration.GetSection(Key).Value;
        }
    }
}
