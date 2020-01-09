namespace async_json
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Posts
    {
        [JsonProperty("userId")]
        public long UserId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }

    public partial class Posts
    {
        public static List<Posts> FromJson(string json) => JsonConvert.DeserializeObject<List<Posts>>(json, async_json.Converter2.Settings);
    }

    public static class PostSerialize
    {
        public static string ToJson(this List<Posts> self) => JsonConvert.SerializeObject(self, async_json.Converter2.Settings);
    }

    internal static class Converter2
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
