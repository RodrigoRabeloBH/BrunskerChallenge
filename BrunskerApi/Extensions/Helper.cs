using Microsoft.AspNetCore.Http;

namespace BrunskerApi.Extensions
{
    public static class Helper
    {
        public static void AddApplicationError(this HttpResponse res, string message)
        {
            res.Headers.Add("Application-Error",message);
            res.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            res.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}