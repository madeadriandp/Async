using System.Runtime.Serialization.Json;
using System.Linq;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using AutoMapper;

namespace async_json
{   
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
        //   var response =  JsonTitle.getTitle().GetAwaiter().GetResult();
        //   var response =  JsonAddress.getAddress().GetAwaiter().GetResult();
        //   var response =  JsonMovieTitle.getMovieTitle().GetAwaiter().GetResult();
        //   var response =  JsonFilterLe.getLe().GetAwaiter().GetResult();
        //   var response =  JsonMovieTop.getMovieTop().GetAwaiter().GetResult();
        // var response = JsonShoppingCart.getPrice().GetAwaiter().GetResult().Sum(e=>e.price);
        //                 Console.WriteLine($"Total harga={response}");
        // var response = JsonCategoryFruit.getFruit().GetAwaiter().GetResult();

       

               
        // var joinUserAndPost = posts.Select(e => {
        //       var config = new MapperConfiguration(cfg => 
        //           cfg.CreateMap<Post, PostUser>()
        //             .ForMember
        //             ( d => d.User, 
        //                 d => d.MapFrom
        //                   (
        //                     x => users.Find(user => user.Id == e.UserId)
        //                   )
        //             )
        //         );
        //         var mapper = config.CreateMapper();
        //       return mapper.Map<Post, PostUser>(e) ;
        //     }).ToList();



        //   foreach (var item in userr)
        //   {
        //     //   System.Console.WriteLine(item.title);
        //     //   System.Console.WriteLine($"{item.address.street}, {item.address.suite}, {item.address.city}, {item.address.zipcode}");
        //     // System.Console.WriteLine(item.title);
            
        //     // if(item.name.Contains("le")){
        //     // System.Console.WriteLine(item.name);
        //     // }

        //     // if(item.vote_average>8.4){
        //     //     System.Console.WriteLine(item.title);
        //     //     System.Console.WriteLine(item.vote_average);
        //     // }

        //     // if(item.category=="fruits"){
        //     //     Console.WriteLine($"{item.name}, {item.category}");
        //     // }

        //     // if(item.price>70){
        //     //     Console.WriteLine($"{item.name}, {item.price}");
        //     // }

       
        //   }

        }

        async static Task getJoinUserPost()
        {
             var postResponse = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
             var userResponse = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");

             var users = User.FromJson(userResponse);
             var posts = Post.FromJson(postResponse);

             var joinUserPost = posts.Select(e=> {

                 var config = new MapperConfiguration (cfg=>
                 cfg.CreateMap<Post, PostUser>()
                 .ForMember
                 (
                     d => d.user,
                     d => d.MapFrom
                     (
                         x=> users.Find(users.Id == e.UserId)
                     )
                 )

                 );

                 var mapper = config.CreateMapper();

                 return mapper.Map<Post, PostUser>(e);


             }).ToList();


            //  ))

        }
       

        // public async static Task getUser()
        // {
        //     var user = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
        // }

        // public async static Task getPost()
        // {
        //     var post = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");
        // }

      
    }
}
