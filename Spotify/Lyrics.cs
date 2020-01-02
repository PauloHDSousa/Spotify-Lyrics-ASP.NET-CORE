using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Utils;

namespace Spotify
{
    public class Lyrics
    {
        const string lyricsURL = "https://www.letras.mus.br";

        public Model.Lyrics GetCurrentMusicLyrics(string artist, string music)
        {
            string fullLyricsURL = $"{lyricsURL}/{artist.ToCleanUrl()}/{music.ToCleanUrl()}";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fullLyricsURL);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string data = "";
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (String.IsNullOrWhiteSpace(response.CharacterSet))
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

            htmlDoc.LoadHtml(data);

            var musicHTML = htmlDoc.DocumentNode.Descendants(0).Where(n => n.HasClass("p402_premium")).FirstOrDefault().InnerHtml;

            //Fixing HTML Problems
            musicHTML = musicHTML.Replace("‘", "'");
            musicHTML = musicHTML.Replace("’", "'");

            return new Model.Lyrics() { Artist = artist, LyricsHTML = musicHTML, Music = music };
        }
    }
}
