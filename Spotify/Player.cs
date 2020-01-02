using Spotify.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Spotify
{
    public class Player
    {
        const string currentlyPlayingURL = "https://api.spotify.com/v1/me/player/currently-playing";

        public async Task<CurrentPlaying> GetCurrentlyPlaying(string token)
        {
            Auth auth = new Auth();
            CurrentPlaying currentPlaying = await auth.GetSpotifyType<CurrentPlaying>(token, currentlyPlayingURL);
            return currentPlaying;
        }
    }
}
