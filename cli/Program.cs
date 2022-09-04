using rtc;
using System.Runtime.InteropServices;

// Watch when file is changed, then update its copy file

namespace cli
{
    internal class Program
    {
        [DllImport("Kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int cmdShow);

        private static Rtc rtc = new();

        private static string source = @"C:\Users\roman\git\roman-koshchei\rtc\test\real\";
        private static string destination = @"C:\Users\roman\git\roman-koshchei\rtc\test\copy\";

        private static Dictionary<string, Action<List<string>>> commands = new();

        private static void Main(string[] args)
        {
            IntPtr hWnd = GetConsoleWindow();
            if (hWnd != IntPtr.Zero)
            {
                ShowWindow(hWnd, 0);
            }

            AddDir("test", source, destination);

            while (true)
            {
            }
            //if (args.Length == 0)
            //{
            //}
            //else
            //{
            //    List<string> argList = new(args);
            //    string command = argList[0];
            //    argList.RemoveAt(0);

            //    if (commands.ContainsKey(command))
            //    {
            //        commands[command](argList);
            //    }
            //    else
            //    {
            //        Console.WriteLine("Command doesn't exist");
            //    }
            //}

            //foreach (string arg in args)
            //{
            //    Console.WriteLine(arg);
            //}            //string[] files = { "f.txt" };
            ////AddDir("test", source, destination); //, files);

            //Console.WriteLine("Press enter to exit.");
            //Console.ReadLine();
        }

        private static void AddDir(string name, string source, string target)
        {
            try
            {
                rtc.AddDir(name, source, target);
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"name {name} already exists");
            }
        }

        private static void AddFiles(string name, string source, string target, string[] files)
        {
            try
            {
                rtc.AddFiles(name, source, target, files);
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"name {name} already exists");
            }
        }
    }
}