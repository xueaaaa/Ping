using System.IO;
using System.Text.Json;

namespace Ping.Models
{
    internal static class StorageManager
    {
        private const string STORAGE_PATH = "storage";

        private static string GetFilePath(string filename) =>
            $"{Directory.GetCurrentDirectory()}\\{STORAGE_PATH}\\{filename}.json";

        public static async void SaveAsJson<T>(T obj, string filename)
        {
            string json = JsonSerializer.Serialize(obj);

            using (StreamWriter sw = new(GetFilePath(filename)))
            {
                await sw.WriteAsync(json);
            }
        }

        public static async Task<T?> ReadFromJson<T>(string filename)
        {
            using (StreamReader sr = new(GetFilePath(filename)))
            {
                string json = await sr.ReadToEndAsync();
                T? obj = JsonSerializer.Deserialize<T>(json);

                return obj;
            }
        }

        public static async Task<List<T?>> ReadFromJson<T>(string[] filenames)
        {
            List<T?> list = new();

            foreach (string filename in filenames)
                list.Add(await ReadFromJson<T>(filename));

            return list;
        }

        public static void Delete(string filename)
        {
            if (File.Exists(GetFilePath(filename)))
                File.Delete(GetFilePath(filename));
        }
    }
}
