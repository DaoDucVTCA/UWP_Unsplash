using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;

namespace Unsflash.ViewModel
{
    class UserAuthorization
    {
        public static string token_uri = "https://unsplash.com/oauth/token?"
                + "client_id=" + RequestParameters.client_id
                + "&client_secret=" + RequestParameters.client_secret
                + "&redirect_uri=" + RequestParameters.redirect_uri
                + "&code=" + RequestParameters.code
                + "&grant_type=authorization_code";
        public async void Authorization()
        {
            Uri StartUri = new Uri(RequestParameters.api_url);
            Uri EndUri = new Uri(RequestParameters.redirect_uri);

            WebAuthenticationResult WebAuthenticationResult = await WebAuthenticationBroker.AuthenticateAsync(
                                                    WebAuthenticationOptions.None,
                                                    StartUri,
                                                    EndUri);
            if (WebAuthenticationResult.ResponseStatus == WebAuthenticationStatus.Success)
            {
                RequestParameters.code = WebAuthenticationResult.ResponseData.ToString();
                RequestParameters.code = RequestParameters.code.Substring(RequestParameters.code.IndexOf("code"));
            }
            else if (WebAuthenticationResult.ResponseStatus == WebAuthenticationStatus.ErrorHttp)
            {

            }
            else
            {

            }

            HttpClient httpClient = new HttpClient();
            
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, token_uri);
            HttpResponseMessage response = await httpClient.SendAsync(request);

            string responeData = await response.Content.ReadAsStringAsync();

            
        }
    }
}
