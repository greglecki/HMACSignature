using HMACSignature.WebAPIService.Filters;
using System.Collections.Generic;
using System.Web.Http;

namespace HMACSignature.WebAPIService.Controllers
{
    [HMACAuthentication]
    public class ValuesController : ApiController
    {
        public IEnumerable<string> GetValues()
        {
            return new string[] { "value1", "value2", "value3", "value4", "value5", "value6" };
        }

        public string GetValueByID(int id)
        {
            return "value " + id;
        }
    }
}
