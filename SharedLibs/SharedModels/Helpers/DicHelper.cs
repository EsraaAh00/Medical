using JwtAuthenticationManager;
using Newtonsoft.Json.Linq;
namespace SharedModels.Helpers
{
    public static class DicHelper
    {
        public static JObject? DicLocalized { set; get; }
        public static JObject? Dic { set; get; }
        public static string GetMessage(string Key)
        {
            try
            {
                if (AuthenticationHelper.GetLanuage() == 1)
                {
                    if (DicHelper.Dic == null)
                    {
                        var myJsonString = File.ReadAllText("Dic/en.json");
                        DicHelper.Dic = JObject.Parse(myJsonString);
                    }
                    return DicHelper.Dic?.SelectToken(Key)?.Value<string>() ?? "";
                }
                if (DicHelper.DicLocalized == null)
                {
                    var myJsonString = File.ReadAllText("Dic/ar.json");
                    DicHelper.DicLocalized = JObject.Parse(myJsonString);
                }
                return DicHelper.DicLocalized?.SelectToken(Key)?.Value<string>() ?? "";
            }
            catch (Exception)
            {
                return Key;
            }
        }

        public static void Init()
        {
            var myJsonString = File.ReadAllText("Dic/en.json");
            Dic = JObject.Parse(myJsonString);
            var myJsonStringAr = File.ReadAllText("Dic/ar.json");
            DicLocalized = JObject.Parse(myJsonStringAr);

        }

    }
}