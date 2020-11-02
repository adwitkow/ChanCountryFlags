using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ChanCountryFlags.Model
{
    public partial class Boards
    {
        [JsonProperty("boards")]
        public Board[] BoardList { get; set; }

        [JsonProperty("troll_flags")]
        public Dictionary<string, string> TrollFlags { get; set; }

        public IEnumerable<Board> GetFlagBoards()
        {
            return BoardList.Where(board => board.HasFlags());
        }
    }

    public partial class Board
    {
        [JsonProperty("board")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("ws_board")]
        public bool Worksafe { get; set; }

        [JsonProperty("meta_description")]
        public string MetaDescription { get; set; }

        [JsonProperty("is_archived", NullValueHandling = NullValueHandling.Include)]
        public bool IsArchived { get; set; }

        [JsonProperty("user_ids", NullValueHandling = NullValueHandling.Include)]
        public bool UserIds { get; set; }

        [JsonProperty("country_flags", NullValueHandling = NullValueHandling.Include)]
        public bool CountryFlags { get; set; }

        [JsonProperty("troll_flags", NullValueHandling = NullValueHandling.Include)]
        public bool TrollFlags { get; set; }

        public bool HasFlags()
        {
            return CountryFlags || TrollFlags;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
