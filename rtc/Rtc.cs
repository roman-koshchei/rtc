namespace rtc
{
    public class Rtc
    {
        private Dictionary<string, RtcWatcher> watchers = new();

        public void AddDir(string name, string source, string target, bool includeSubdirs = true)
        {
            RtcWatcher watcher = new(source, target, includeSubdirs);
            watchers.Add(name, watcher);

            // TODO: add to local .json
        }

        public void RemoveDir(string name)
        {
            watchers.Remove(name);

            // TODO: remove from .json
        }

        public void AddFiles(string name, string source, string target, string[] files)
        {
            RtcWatcher watcher = new(source, target, files);
            watchers.Add(name, watcher);
        }
    }
}