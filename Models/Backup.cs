namespace FastRestorer.Models
{
    public class Backup
    {
        private readonly long _sizeBytes;

        public string DatabaseName { get; }
        public DateTime FinishDate { get; }
        public string Path { get; }
        public double SizeMb => _sizeBytes / 1024d / 1024d;

        public Backup(string databaseName, DateTime finishDate, string path, long sizeBytes)
        {
            DatabaseName = databaseName;
            FinishDate = finishDate;
            Path = path;
            _sizeBytes = sizeBytes;
        }
    }
}