using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var mapper = new Dictionary<string, string>() { { "-n", "name" }, { "-a", "age" } };
            var configContent = new ConfigurationBuilder().AddCommandLine(args).Build();
            var a = configContent["SecurityKey"];
            var services=new IServiceCollection
            services.AddOptions()
             .Configure<configclass>(a =>
             {
                 a.name = configContent["name"];
                 a.age = configContent["age"];
             }).Validate(t=>t.name.)
             ;
        }
    }
}
