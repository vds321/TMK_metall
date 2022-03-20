﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace TMK
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] Args)
        {
            return Host.CreateDefaultBuilder(Args)
                 .UseContentRoot(App.CurrentDirectory)
                 .ConfigureAppConfiguration((host, cfg) => cfg
                     .SetBasePath(App.CurrentDirectory)
                     .AddJsonFile("appsetting.json", optional: true, reloadOnChange: true))
                 .ConfigureServices(App.ConfigureServices);
        }

    }
}
