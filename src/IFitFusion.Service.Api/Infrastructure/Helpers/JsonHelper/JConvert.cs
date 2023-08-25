using Newtonsoft.Json;

namespace IFitFusion.Service.Api.Infrastructure.Helpers.JsonHelper
{
    public static class JConvert
    {
        public static string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
