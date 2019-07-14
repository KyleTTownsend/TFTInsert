using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using data = TFTInsert.DataModels;
using TFTInsert.Entities;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace TFTInsert
{
    class Program
    {
        const string resourcePath = "C:\\Users\\KyleT\\Desktop\\Engineering\\TFTInsert\\TFTInsert\\TFTInsert\\res\\";
        public static IServiceProvider Provider { get; set; }
        public static data.mytftdbContext db { get; set; }
        static void Main(string[] args)
        {
            ConfigureServices();
            DeleteDbValues();
            InsertAll();
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
            db.Database.ExecuteSqlCommand(Constants.DeleteChampionClassLink);
            db.Database.ExecuteSqlCommand(Constants.DeleteChampionOriginLink);
            db.Database.ExecuteSqlCommand(Constants.DeleteAbilityStats);
            db.Database.ExecuteSqlCommand(Constants.DeleteAbility);
            db.Database.ExecuteSqlCommand(Constants.DeleteChampionStats);
            db.Database.ExecuteSqlCommand(Constants.DeleteChampions);
            db.Database.ExecuteSqlCommand(Constants.DeleteOriginBonus);
            db.Database.ExecuteSqlCommand(Constants.DeleteOrigin);
            db.Database.ExecuteSqlCommand(Constants.DeleteClassBonus);
            db.Database.ExecuteSqlCommand(Constants.DeleteClass);
            db.Database.ExecuteSqlCommand(Constants.DeleteItemComponentStats);
            db.Database.ExecuteSqlCommand(Constants.DeleteItemLink);
            db.Database.ExecuteSqlCommand(Constants.DeleteItemComponent);
            db.Database.ExecuteSqlCommand(Constants.DeleteItemFull);
        }


        static void InsertAll()
        {
            InsertOrigins();
            InsertClasses();
            db.SaveChanges();
            InsertChampions();
            InsertItems();
            db.SaveChanges();
        }
        static void InsertOrigins()
        {
            string json = "";
            using (StreamReader r = new StreamReader(resourcePath + "origins.json"))
            {   
                json = r.ReadToEnd();
            }
            tftOrigins origins = JsonConvert.DeserializeObject<tftOrigins>(json);

            IList<data.Origin> allOrigins = Map(origins).Cast<data.Origin>().ToList();
            foreach(data.Origin origin in allOrigins)
            {
                db.Origin.Add(origin);
            }
        }
        static void InsertClasses()
        {
            string json = "";
            using (StreamReader r = new StreamReader(resourcePath + "classes.json"))
            {
                json = r.ReadToEnd();
            }
            tftClasses classes = JsonConvert.DeserializeObject<tftClasses>(json);
            IList<data.Class> allClasses = Map(classes).Cast<data.Class>().ToList();
            foreach(data.Class cl in allClasses)
            {
                db.Class.Add(cl);
            }
        }
        static void InsertChampions()
        {
            string json = "";
            using (StreamReader r = new StreamReader(resourcePath + "champions.json"))
            {
                json = r.ReadToEnd();
            }
            champions champs = JsonConvert.DeserializeObject<champions>(json);
            IList<object> allChamps = Map(champs);
            foreach(object obj in allChamps)
            {
                if(obj.GetType() == typeof(data.ChampionClassLink))
                {
                    db.ChampionClassLink.Add((data.ChampionClassLink) obj);
                }
                else
                {
                    db.ChampionOriginLink.Add((data.ChampionOriginLink) obj);
                }
            }
        }
        static void InsertItems()
        {
            string json = "";
            using (StreamReader r = new StreamReader(resourcePath + "items.json"))
            {
                json = r.ReadToEnd();
            }
            tftItems items = JsonConvert.DeserializeObject<tftItems>(json);
            IList<data.ItemLink> allItems = MapItems(items);

            foreach(data.ItemLink item in allItems)
            {
                db.ItemLink.Add(item);
            }
        }


        static IList<data.ItemLink> MapItems(tftItems items)
        {
            IList<data.ItemLink> links = new List<data.ItemLink>();
            IList<data.ItemComponent> itemComponents = new List<data.ItemComponent>();

            foreach(PropertyInfo prop in items.GetType().GetProperties())
            {
                object value = prop.GetValue(items);
                Type t = value.GetType();
                
                if(t == typeof(ItemComponent))
                {
                    ItemComponent temp = (ItemComponent)value;
                    data.ItemComponent itemComponent = new data.ItemComponent
                    {
                        Name = temp.name,
                        Type = temp.type,
                        Bonus = temp.bonus,
                        Tier = temp.tier,
                        Depth = temp.depth,
                        Kind = temp.kind
                    };
                    foreach(ItemStat stat in temp.stats)
                    {
                        data.ItemComponentStat val = new data.ItemComponentStat
                        {
                            Name = stat.name,
                            Title = stat.title,
                            Amount = stat.amount
                        };
                        itemComponent.ItemComponentStat.Add(val);
                    }
                    itemComponents.Add(itemComponent);
                }
                else if (t == typeof(ItemFull))
                {
                    ItemFull temp = (ItemFull)value;
                    data.ItemFull item = new data.ItemFull
                    {
                        Name = temp.name,
                        Type = temp.type,
                        Bonus = temp.bonus,
                        Tier = temp.tier,
                        Depth = temp.depth,
                        Kind = temp.kind
                    };
                    temp.buildsFrom = temp.buildsFrom.Distinct().ToList();
                    foreach (string buildComponent in temp.buildsFrom)
                    {
                            Regex pattern = new Regex("[.,' ]");

                            data.ItemComponent comp = itemComponents.First(x => pattern.Replace(x.Name.ToLower(), "") == buildComponent);
                            data.ItemLink link = new data.ItemLink
                            {
                                ItemComponent = comp,
                                ItemFull = item
                            };
                            links.Add(link);
                    }

                }
            }

            return links;
        }

        static IList<object> Map(object input)
        {
            IList<object> response = new List<object>();
            foreach(PropertyInfo prop in input.GetType().GetProperties())
            {
                object value = prop.GetValue(input, null);
                Type t = value.GetType();
                if(t == typeof(Origin))
                {
                    Origin o = (Origin)value;
                    data.Origin orig = new data.Origin
                    {
                        Name = o.name,
                        OriginDesc = o.description
                    };
                    orig.OriginBonus = new List<data.OriginBonus>();
                    foreach(OriginBonus b in o.bonuses)
                    {
                        data.OriginBonus originBonus = new data.OriginBonus
                        {
                            Needed = b.needed,
                            Effect = b.effect
                        };
                        orig.OriginBonus.Add(originBonus);
                    }
                    response.Add(orig);
                   
                }
                else if(t == typeof(tftClass))
                {
                    tftClass inputClass = (tftClass)value;
                    data.Class returnClass = new data.Class
                    {
                        Name = inputClass.name,
                        ClassDesc = inputClass.description
                    };
                    returnClass.ClassBonus = new List<data.ClassBonus>();
                    foreach(classBonus b in inputClass.bonuses)
                    {
                        data.ClassBonus bonus = new data.ClassBonus
                        {
                            Needed = b.needed,
                            Effect = b.effect
                        };
                        returnClass.ClassBonus.Add(bonus);
                    }
                    response.Add(returnClass);
                }
                else if(t == typeof(champion))
                {
                    champion champ = (champion)value;
                    data.Champion returnChamp = new data.Champion
                    {
                        Name = champ.name,
                        Cost = champ.cost,
                        Ability = new List<data.Ability>()
                    };

                    data.ChampionStat champStats = new data.ChampionStat()
                    {
                        Damage = champ.stats.offense.damage,
                        Dps = champ.stats.offense.dps,
                        AttackSpeed = champ.stats.offense.attackSpeed,
                        Range = champ.stats.offense.range,
                        Health = champ.stats.defense.health,
                        MagicResist = champ.stats.defense.magicResist,
                        Armor = champ.stats.defense.armor
                    };

                    returnChamp.ChampionStat.Add(champStats);
                    data.Ability ability = new data.Ability
                    {
                        Name = champ.ability.name,
                        AbilityDesc = champ.ability.description,
                        ManaCost = champ.ability.manaCost,
                        ManaStart = champ.ability.manaStart,
                        AbilityType = champ.ability.type,
                        AbilityStat = new List<data.AbilityStat>()
                    };
                    foreach(ability_stat stat in champ.ability.stats)
                    {
                        data.AbilityStat abilityStat = new data.AbilityStat
                        {
                            StatValue = stat.value,
                            StatType = stat.type
                        };
                        ability.AbilityStat.Add(abilityStat);
                    }
                    returnChamp.Ability.Add(ability);
                    IEnumerable<data.Origin> temp = new List<data.Origin>();
                    foreach(string origin in champ.origin)
                    {
                        temp = db.Origin.Where(x => x.Name == origin);
                    }
                    List<data.Origin> origins = temp.ToList();
                    foreach (data.Origin o in origins)
                    {
                        data.ChampionOriginLink link = new data.ChampionOriginLink();
                        link.Origin = o;
                        link.Champion = returnChamp;
                        response.Add(link);
                    }
                    IEnumerable<data.Class> temp2 = new List<data.Class>();
                    foreach (string class1 in champ.tft_class)
                    {
                        temp2 = db.Class.Where(x => x.Name == class1);
                    }
                    List<data.Class> classes = temp2.ToList();
                    foreach (data.Class c in classes)
                    {
                        data.ChampionClassLink link = new data.ChampionClassLink();
                        link.Class = c;
                        link.Champion = returnChamp;
                        response.Add(link);
                    }
                }
            }
            return response;
        }
    }
}
