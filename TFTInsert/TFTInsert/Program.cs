using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using data = TFTInsert.Models;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace TFTInsert
{
    class Program
    {
        public static IServiceProvider Provider { get; set; }
        public static data.mytftdbContext db { get; set; }
        static void Main(string[] args)
        {
            ConfigureServices();
            DeleteDbValues();
            InsertOrigins();
        }
        static void ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            IConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configBuilder.AddJsonFile("appsettings.json");
            IConfiguration config = configBuilder.Build();
            services.AddSingleton(config);
            services.AddDbContext<data.mytftdbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("TFTAppDB")));  
            Provider = services.BuildServiceProvider();
            db = Provider.GetService<data.mytftdbContext>();
        }
        static void DeleteDbValues()
        {
            db.Database.ExecuteSqlCommand(Constants.DeleteOriginBonusLink);
            db.Database.ExecuteSqlCommand(Constants.DeleteOrigin);
            db.Database.ExecuteSqlCommand(Constants.DeleteOriginBonus);
        }


        static void InsertAll()
        {

        }
        static void InsertOrigins()
        {

        }
    }
}
