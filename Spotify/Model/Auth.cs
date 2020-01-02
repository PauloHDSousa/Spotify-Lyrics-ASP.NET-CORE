namespace Spotify.Model
{
    public class SpotifyAuth
    {
        //	An access token that can be provided in subsequent calls, for example to Spotify Web API services.
        public string access_token { get; set; }
        //	The time period (in seconds) for which the access token is valid.
        public int expires_in { get; set; }

        //TODO:Take a look at this for a better performance
        //A token that can be sent to the Spotify Accounts service in place of an authorization code. (When the access code expires, send a POST request to the Accounts service /api/token endpoint, but use this code in place of an authorization code.A new access token will be returned.A new refresh token might be returned too.)
        public string refresh_token { get;set;}
    }
}
