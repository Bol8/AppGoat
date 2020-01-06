using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace AppGoat.Application.Utils.Extensions
{
    public static class ObjectExtensions
    {
        public static StringContent AsJson(this object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}