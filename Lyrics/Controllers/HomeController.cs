using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify;
using Spotify.Model;

namespace Lyrics.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string accessToken = GetAccessToken();

            if (!string.IsNullOrEmpty(accessToken))
                RedirectToAction("CallBack");

            string authorizeURL = new Auth().GetRedirectURL();

            return Redirect(authorizeURL);
        }

        [Route("/callback")]
        public ActionResult CallBack(string code)
        {
            //Get Acess Token from cookie if it still available
            string accessToken = GetAccessToken();

            if (string.IsNullOrEmpty(accessToken) && !string.IsNullOrEmpty(code))
            {
                Auth auth = new Auth();
                var spotifyAuth = auth.GetSpotifyAuth(code);

                if (spotifyAuth != null && !string.IsNullOrEmpty(spotifyAuth.access_token))
                    SaveAccessToken(spotifyAuth.access_token, spotifyAuth.expires_in);

                accessToken = spotifyAuth.access_token;
            }

            CurrentPlaying currentPlaying = new Player().GetCurrentlyPlaying(accessToken).Result;

            string artist = currentPlaying.item.artists[0].name;
            string song = currentPlaying.item.name;

            var lyrics = new Spotify.Lyrics().GetCurrentMusicLyrics(artist, song);

            return View(lyrics);
        }

        //TODO:move
        void SaveAccessToken(string token, int expires)
        {
            if (!string.IsNullOrEmpty(GetAccessToken()))
                return;

            var option = new CookieOptions();
            option.Expires = DateTime.Now.AddSeconds(expires);
            Response.Cookies.Append("spotifyAccessToken", token, option);
        }

        string GetAccessToken()
        {
            return Request.Cookies["spotifyAccessToken"];
        }

    }
}
