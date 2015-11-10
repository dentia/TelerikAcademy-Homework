namespace GuildWarsConsumer
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    using Newtonsoft.Json;

    public class Startup
    {
        public static void Main()
        {
            var actions = new Dictionary<string, Action<int>>
                              {
                                  { "items", i => { PrintItem("items", i, JsonConvert.DeserializeObject<Item>); } },
                                  { "skins", i => { PrintItem("skins", i, JsonConvert.DeserializeObject<Skin>); } }
                              };

            Console.WriteLine("Guild wars!");
            Console.Write("Enter what type you want to view(skins, items) - default one is items: ");
            var type = GetType(Console.ReadLine());

            Console.Write("Enter the ID of the item you want to view: ");
            int id;

            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid ID. I'll show you the 57th one. :)");
                id = 57;
            }

            actions[type](id);
        }

        public static string GetType(string type)
        {
            switch (type)
            {
                case "skins":
                case "items":
                    return type;
                default:
                    return "items";
            }
        }

        public static void PrintItem(string type, int id, Func<string, object> parse)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.guildwars2.com/v2/items/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync(id.ToString()).Result;

                if (response.IsSuccessStatusCode)
                {
                    var itemJson = response.Content.ReadAsStringAsync().Result;
                    var item = parse(itemJson);
                    Console.WriteLine(item);
                }
                else
                {
                    Console.WriteLine("No item with the given id exists.");
                }
            }
        }
    }
}