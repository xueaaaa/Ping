using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json;

namespace Ping.Models.Core
{
    public static class StorageManager
    {
        private static readonly string PROGRAM_PATH = Directory.GetCurrentDirectory();

        public static async void SaveAsJson(string directory, string name, object data)
        {
            if(!Directory.Exists($"{PROGRAM_PATH}/{directory}"))
                Directory.CreateDirectory($"{PROGRAM_PATH}/{directory}");

            string content = JsonSerializer.Serialize(data);
            using(StreamWriter sw = new($"{PROGRAM_PATH}/{directory}/{name}.json"))
                await sw.WriteAsync(content);
        }

        public static async Task<object> ReadFromJson(string directory, string name, Type dataType)
        {
            if (!File.Exists($"{PROGRAM_PATH}/{directory}/{name}.json"))
                throw new FileNotFoundException(name);

            using (StreamReader sr = new($"{PROGRAM_PATH}/{directory}/{name}.json"))
            {
                string raw = await sr.ReadToEndAsync();
                var data = JsonSerializer.Deserialize<DataType>(raw);

                return data;
            }
        }
    }
}
