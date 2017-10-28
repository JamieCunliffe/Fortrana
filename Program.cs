using System;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace test_app
{
    public class Program
    {
        [DllImport("libmain.so")]
        public static extern int move_(ref int x);
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();


	   int g1;
	    g1 = 148;
	    Console.WriteLine(move_( ref g1));
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(options => {
                    options.Listen(IPAddress.Any, 443, listenOptions =>
                    {
                        listenOptions.UseHttps("certificate.pfx", "password");

                    });
                })
                .UseStartup<Startup>()
		.UseUrls("https://0.0.0.0:443")
                .Build();
    }
}
