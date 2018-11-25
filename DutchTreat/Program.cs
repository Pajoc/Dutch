using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DutchTreat
{
  public class Program
  {
    public static void Main(string[] args)
    {
      BuildWebHost(args).Run();
    }

    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(SetupConfiguration)
            .UseStartup<Startup>()
            .Build();

        private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            //Remove as opções de configuração por defeito
            builder.Sources.Clear();
            //assim fica mais versátil permite ter vários formatos de ficheiros de configuração
            builder.AddJsonFile("config.json", false, true)
                .AddXmlFile("config.xml", true)
                .AddEnvironmentVariables();//Junta todos esses ficheiros de config. num só (em caso de conflitos prevalece o último)!
        }
    }
}
