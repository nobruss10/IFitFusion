using Newtonsoft.Json;

namespace IFitFusion.Infrastructure.CrossCutting.Helpers.Json
{
    public static class JConvert
    {
        public static string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
