using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Owin.Hosting;

namespace AllHomeNode
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host   
            WebApp.Start<StartUp>(url: baseAddress);

            // Create HttpCient and make a request to api/user   
            //HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseAddress + "api/user").Result;
            //Console.WriteLine(response);
            //Console.WriteLine(response.Content.ReadAsStringAsync().Result);


            Console.ReadLine();
        }
    }
}
