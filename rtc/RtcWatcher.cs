using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtc
{
    public class RtcWatcher
    {
        private FileSystemWatcher watcher;
        private string target;
        private string source;

        /// <summary>
        /// For full directory watch
        /// </summary>
        /// <param name="source">Path to dir</param>
        public RtcWatcher(string source, string target, bool includeSubdirs)
        {
            this.target = target;
            this.source = source;
            watcher = new(source)
            {
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size
                | NotifyFilters.DirectoryName | NotifyFilters.FileName,
                EnableRaisingEvents = true,
                IncludeSubdirectories = includeSubdirs
            };

            watcher.Changed += OnChange;
        }

        public RtcWatcher(string dir, string target, string[] files) : this(dir, target, false)
        {
            foreach (string file in files)
            {
                watcher.Filters.Add(file);
            }
        }

        private void OnChange(object sender, FileSystemEventArgs e)
        {
            //if (e.ChangeType != WatcherChangeTypes.Changed) return;
            Console.WriteLine($"{e.Name}");
            string? sub = Path.GetDirectoryName(e.Name);
            if (sub != null)
            {
                string targetSub = Path.Join(target, sub);
                if (!Directory.Exists(targetSub))
                {
                    Directory.CreateDirectory(targetSub);
                }
            }

            string sourceFile = Path.Join(source, e.Name);
            string targetFile = Path.Join(target, e.Name);

            File.Copy(sourceFile, targetFile, true);
        }
    }
}