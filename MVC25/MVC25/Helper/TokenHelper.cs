using MVC25.DataModel;
using MVC25.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC25.Helper
{
    public class TokenHelper
    {

        public readonly RestSharpHelper restSharpHelper;

        public TokenHelper()
        {
            restSharpHelper = new RestSharpHelper();
        }

        public Token GetRefreshToken(string login, string password)
        {

            var response = restSharpHelper.Execute<Token>(Helper.RestServiceNames.GetAccessToken, Method.POST,
                new Dictionary<string, object>()
                {
                    { "application/json", $"grant_type=password&username={login}&password={password}"}
                },false,DataFormat.None);

            return response.Data;
        }
    }
}