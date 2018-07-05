using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Pivotal.Extensions.Configuration;
using Pivotal.Extensions.Configuration.ConfigServer;
//using Steeltoe.Extensions.Configuration.CloudFoundry;

namespace WordFetch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
               WebHost.CreateDefaultBuilder(args)
                .UseCloudFoundryHosting()
                .ConfigureAppConfiguration((webHostBuilderContext, configurationBuilder) => {
                  


                    var hostingEnvironment = webHostBuilderContext.HostingEnvironment;
                    configurationBuilder.AddConfigServer(hostingEnvironment);
                    
                })
                .UseStartup<Startup>()
                .Build();
    }
}

