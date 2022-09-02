namespace rtc
{
    public class Rtc
    {

        public void Dir(string path)
        {
            using var watcher = new FileSystemWatcher(path);

            watcher.EnableRaisingEvents = true;
        }

        public void Undir(string path)
        {
        }
    }
}