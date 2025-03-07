using System.IO;
using System.Text.Json;

namespace Ping.Models
{
    internal static class StorageManager
    {
        internal const string STORAGE_PATH = "storage";
        internal const string TASKS_FOLDER = "tasks";

        private static string GetFilePath(string folder, string filename) =>
            $"{Directory.GetCurrentDirectory()}\\{STORAGE_PATH}\\{folder}\\{filename}.json";

        public static void EnsureCreated()
        {
            string tasksPath = $"{Directory.GetCurrentDirectory()}\\{STORAGE_PATH}\\{TASKS_FOLDER}";
            if (!Path.Exists(tasksPath))
                Directory.CreateDirectory(tasksPath);
        }

        public static async void SaveAsJson<T>(T obj, string folder, string filename)
        {
            string json = JsonSerializer.Serialize(obj);

            using (StreamWriter sw = new(GetFilePath(folder, filename)))
            {
                await sw.WriteAsync(json);
            }
        }

        public static async Task<T?> ReadFromJson<T>(string folder, string filename)
        {
            using (StreamReader sr = new(GetFilePath(folder, filename)))
            {
                string json = sr.ReadToEnd();
                T? obj = JsonSerializer.Deserialize<T>(json);

                return obj;
            }
        }

        public static async Task<List<T?>> ReadFromJson<T>(string folder)
        {
            List<T?> list = new();

            foreach (string filename in Directory.GetFiles($"{Directory.GetCurrentDirectory()}\\{STORAGE_PATH}\\{folder}"))
                list.Add(await ReadFromJson<T>(folder, Path.GetFileNameWithoutExtension(filename)));

            return list;
        }

        public static void Delete(string folder, string filename)
        {
            if (File.Exists(GetFilePath(folder, filename)))
                File.Delete(GetFilePath(folder, filename));
        }
    }
}
