using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

namespace ChanCountryFlags.Model
{
    public partial class CatalogPage
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("threads")]
        public CatalogThread[] Threads { get; set; }
    }

    public partial class CatalogThread : Post
    {
        [JsonProperty("sticky", NullValueHandling = NullValueHandling.Include)]
        public bool Sticky { get; set; }

        [JsonProperty("closed", NullValueHandling = NullValueHandling.Include)]
        public bool Closed { get; set; }
    }

    internal static class CatalogConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            DateFormatString = "MM/dd/yy(ddd)HH:mm:ss",
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None
        };
    }
}
