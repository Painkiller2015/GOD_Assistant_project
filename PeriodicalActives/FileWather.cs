namespace GOD_Assistant.PeriodicalActives
{
    public static class FileWatcher
    {
        private static FileSystemWatcher _Watcher;
        private static bool _doubleCall;
        static FileWatcher()
        {
            _Watcher = new FileSystemWatcher(@".\PeriodicalActives\", "*.json");

            _Watcher.NotifyFilter = NotifyFilters.LastWrite;
            _Watcher.EnableRaisingEvents = true;

            //SubscribeToFile(SomeMethod, "PeriodicalActivesSettings.json");
        }
        public static void SubscribeToFile(Delegate action, string FileName)
        {
            _Watcher.Changed += SomeMethod;
        }

        public static void SomeMethod(object sender, FileSystemEventArgs e)
        {
            _doubleCall = !_doubleCall;
            if (_doubleCall)
            {
                Console.WriteLine("double?");
            }
        }




        public static void UnSubscribeToFile()
        {

        }
    }
}
