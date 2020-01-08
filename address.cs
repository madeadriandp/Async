using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace async_json
{   
    public class Users
    {
        public Address address{get; set;}
        public int id{get;set;}
    }

    public class Address1
    {
        public string street{get;set;}
        public string suite{get;set;}
        public string city{get;set;}
        public string zipcode{get;set;}
    }

    // public class Resp
    // {
    //     // [JsonProperty("title")]
        // public List<Users> users{get; set;}
    // }
    
    public class JsonAddress
    {
     static HttpClient client = new HttpClient();
     public async static Task<List<Users>> getAddress()
        {
            var result = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");

            return JsonConvert.DeserializeObject<List<Users>>(result); 
        }

    }

    
        }

       
    // }

