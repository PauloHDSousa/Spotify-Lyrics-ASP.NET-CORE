using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using Spotify.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Spotify
{
    public class Auth
    {

        //Todo:Move to web.config.
        const string clientID = "";
        const string clientSecret = "";

        const string tokenURL = "https://accounts.spotify.com/api/token";
        const string authorizeURL = "https://accounts.spotify.com/authorize/";

        const string redirectURL = "https://localhost:44332/callback/";

        public SpotifyAuth GetSpotifyAuth(string code)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(clientID + ":" + clientSecret)));

                FormUrlEncodedContent formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("code", code),
                    new KeyValuePair<string, string>("redirect_uri", redirectURL),
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                });

                var response = client.PostAsync(tokenURL, formContent).Result;
                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<SpotifyAuth>(responseString);
            }
        }

        public string GetRedirectURL()
        {



            var qb = new QueryBuilder();
            qb.Add("response_type", "code");
            qb.Add("client_id", clientID);
            qb.Add("scope", "user-read-currently-playing");
            qb.Add("redirect_uri", redirectURL);

            return $"{authorizeURL}{qb.ToQueryString().ToString()}";
        }

        public async Task<T> GetSpotifyType<T>(string token, string url)
        {
            T type = default(T);

            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";
            request.Headers.Add("Authorization", "Bearer " + token);
            request.ContentType = "application/json; charset=utf-8";

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream dataStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        string responseFromServer = reader.ReadToEnd();
                        type = JsonConvert.DeserializeObject<T>(responseFromServer);
                    }
                }
            }

            return type;
        }
    }
}
