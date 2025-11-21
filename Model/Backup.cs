namespace FastRestorer.Model
{
    public class Backup
    {
        private readonly long _sizeBytes;

        public string DatabaseName { get; }
        public DateTime BackupDate { get; }
        public double SizeMb => _sizeBytes / 1024d / 1024d;

        public Backup(string databaseName, DateTime backupDate, long sizeBytes)
        {
            DatabaseName = databaseName;
            BackupDate = backupDate;
            _sizeBytes = sizeBytes;
        }
    }
}