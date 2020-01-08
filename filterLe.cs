using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace async_json
{   
    public class Users2
    {
        // public Address address{get; set;}
        public string name{ get; set;}
    }

    // public class Address 
    // {
    //     public string street{get;set;}
    //     public string suite{get;set;}
    //     public string city{get;set;}
    //     public string zipcode{get;set;}
    // }

    // public class Resp
    // {
    //     // [JsonProperty("title")]
        // public List<Users> users{get; set;}
    // }
    
    public class JsonFilterLe
    {
     static HttpClient client = new HttpClient();
     public async static Task<List<Users2>> getLe()
        {
            var result = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");

            return JsonConvert.DeserializeObject<List<Users2>>(result); 
        }

    }

    
        }

       
    // }

