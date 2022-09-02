using System.IO;

/*

    Watch when file is changed, then update its copy file

 */

namespace cli
{
    internal class Program
    {
        private static Dictionary<string, FileSystemWatcher> watchers = new();

        private static string source = @"C:\Users\roman\Git\roman-koshchei\dtos\";
        private static string destination = @"C:\Users\roman\Git\roman-koshchei\rtcopy\";

        private static void Main(string[] args)
        {
            var watcher = new FileSystemWatcher(source)
            {
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName,
                IncludeSubdirectories = true,
                EnableRaisingEvents = true,
            };

            watcher.Filters.Add("dto.txt");
            watcher.Filters.Add("tcrst.txt");
            watcher.Filters.Add("*.txt");

            watcher.Changed += OnChanged;

            watchers.Add(destination, watcher);

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            Console.WriteLine($"Changed: {e.Name}");

            string? sub = Path.GetDirectoryName(e.Name);

            if (sub != null && !Directory.Exists($"{destination}{sub}"))
            {
                Directory.CreateDirectory($"{destination}{sub}");
            }

            File.Copy($"{source}{e.Name}", $"{destination}{e.Name}", true);

            watchers[destination].Dispose();
            watchers.Remove(destination);
        }
    }
}