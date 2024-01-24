using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.HttpManager
{
    public  class GET_Request
    {
        public RestResponse get_Request(string apiEndpoint) 
        {
            //sending GET request tp api endpoint
            var client = new RestClient(apiEndpoint);
            var request = new RestRequest("");
            var response = client.Get(request);
            return response;
        }
    }
}
