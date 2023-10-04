using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using Newtonsoft.Json;


//using dsharp+
namespace discordbot.config
{
    public class JSONReader
    {   
        public string token { 
            get; 
            
            set;
        }
        public string prefix {
            get; 
            set;
        }

        public async Task ReadJSON() {
            using (StreamReader sr = new StreamReader("bin/Debug/net7.0/config.json")){
                string json = await sr.ReadToEndAsync();
                JSONStructure data = JsonConvert.DeserializeObject<JSONStructure>(json);

                this.token = data.token;
                Console.WriteLine(data.token);
                this.prefix = data.prefix;
            }
        }
    }

    internal sealed class JSONStructure {
        public string token { get; set;}
        public string prefix {get; set;}
    }
}