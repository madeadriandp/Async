using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace async_json
{   
    public class PostUser
    {
        public int id {get;set;}
        public int userId{get;set;}
        public string title{get;set;}
        public string body{get;set;}
        public User user {get;set;}
    }
    public partial class User
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }
    }

    public partial class Address
    {
        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("suite")]
        public string Suite { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }

        [JsonProperty("geo")]
        public Geo Geo { get; set; }
    }

    public partial class Geo
    {
        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("lng")]
        public string Lng { get; set; }
    }

    public partial class Company
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("catchPhrase")]
        public string CatchPhrase { get; set; }

        [JsonProperty("bs")]
        public string Bs { get; set; }
    }

    public partial class User
    {
        public static List<User> FromJson(string json) => JsonConvert.DeserializeObject<List<User>>(json, async_json.Converter.Settings);
    }

    public static class UserSerialize
    {
        public static string ToJson(this List<User> self) => JsonConvert.SerializeObject(self, async_json.Converter.Settings);
    }

    internal static class Converter
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

    public class Post
    {
        public string title{get; set;}
        public int id{get;set;}
    }

    // public class Response
    // {
    //     // [JsonProperty("title")]
    //     public List<Post> posts{get; set;}
    // }

    public class JsonTitle
    {
        static HttpClient client = new HttpClient();
       
        public async static Task<List<Post>> getTitle()
        {
            var result = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");

            return JsonConvert.DeserializeObject<List<Post>>(result); 
        }

    }

    // class Program
    // {
        
    //     static void Main(string[] args)
    //     {
    //       var response =  getTitle().GetAwaiter().GetResult();
          
    //       foreach (var item in response.posts)
    //       {
    //           System.Console.WriteLine(item.title);
    //       }
    //     }

        
    // }
}
