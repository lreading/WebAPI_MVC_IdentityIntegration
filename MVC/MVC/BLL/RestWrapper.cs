using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Web;
using MVC.Extensions;
using Newtonsoft.Json;
using MVC.Models;
using TestTypes;

namespace MVC.BLL
{
    public class RestWrapper
    {
        private String _Endpoint = "http://localhost:53080/";
        private IRestClient _Client;

        public RestWrapper()
        {
            _Client = GetClient();
        } // end rest wrapper

        public IEnumerable<String> GetValues()
        {
            IRestRequest ValuesRequest = new RestRequest("api/Values", Method.GET);
            ValuesRequest.AddHeader("Authorization", "Bearer " + HttpContext.Current.User.Identity.GetAPIToken().access_token);
            IRestResponse Response = _Client.Execute(ValuesRequest);
            return JsonConvert.DeserializeObject<List<String>>(Response.Content);
        }

        public BearerTokenModel GetAuthToken(String Email, String Password)
        {
            IRestRequest AuthRequest = new RestRequest("Token", Method.POST);
            var LogInData = new
            {
                grant_type = "password",
                username = Email,
                password = Password
            };
            AuthRequest.AddObject(LogInData);
            IRestResponse Response = _Client.Execute(AuthRequest);

            if (Response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new ArgumentException("Unable to log in with given credentials.");
            } // end if

            String ContentJson = Response.Content.Replace(".issued", "issued").Replace(".expires", "expires");
            BearerTokenModel Token = JsonConvert.DeserializeObject<BearerTokenModel>(ContentJson);

            return Token;
        } // end get auth token

        private IRestClient GetClient()
        {
            return new RestClient(_Endpoint);
        } // end get client
    } // end class rest wrapper
} // end namespace