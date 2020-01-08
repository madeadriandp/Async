using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace async_json
{   
    public class Cart2
    {
        public int price{get; set;}
        public string category{get;set;}
        public string name{get;set;}
    }

    public class JsonCategoryFruit
    {
        static HttpClient client = new HttpClient();
       
        public async static Task<List<Cart2>> getFruit()
        {
            var result = await client.GetStringAsync("https://res.cloudinary.com/sivadass/raw/upload/v1535817394/json/products.json");

            return JsonConvert.DeserializeObject<List<Cart2>>(result); 
        }

    }

}
