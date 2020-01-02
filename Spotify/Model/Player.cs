using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Model
{

    public class Artist
    {
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class Item
    {
        public string added_at { get; set; }
        public bool is_local { get; set; }
        public string name { get; set; }
        public List<Artist> artists { get; set; }
    }

    public class CurrentPlaying
    {
        public Item item { get; set; }
    }
}
