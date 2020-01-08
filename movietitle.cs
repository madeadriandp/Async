using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace async_json
{   
    public class Movie
    {
        public string title {get; set;}
    }

    
    public class Response
    {
        [JsonProperty("results")]
        public List<Movie> movie{get; set;}
    }
    
    public class JsonMovieTitle
    {
     static HttpClient client = new HttpClient();
     public async static Task<Response> getMovieTitle()
        {
            var result = await client.GetStringAsync("https://api.themoviedb.org/3/movie/top_rated?api_key=031d552115e70a64acab51b8f6b9d9d3&language=en-US&page=1");


            return JsonConvert.DeserializeObject<Response>(result); 
        }

    }

    
        }

       
    // }

