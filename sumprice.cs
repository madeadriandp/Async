using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace async_json
{   
    public class Cart
    {
        public int price{get; set;}
    }

    public class JsonShoppingCart
    {
        static HttpClient client = new HttpClient();
       
        public async static Task<List<Cart>> getPrice()
        {
            var result = await client.GetStringAsync("https://res.cloudinary.com/sivadass/raw/upload/v1535817394/json/products.json");

            return JsonConvert.DeserializeObject<List<Cart>>(result); 
        }

    }

}
