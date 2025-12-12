using FastRestorer.Models;
using System.IO;

namespace FastRestorer.Services
{
    public class BackupInfoLoader
    {
        /// <summary>
        /// Reads backup metadata from a .bak file.
        /// </summary>
        /// 
        /// <param name="bakPath">
        /// The full path to the .bak file.
        /// </param>
        /// 
        /// <returns>
        /// A <see cref="Backup"/> instance containing the backup metadata.
        /// </returns>
        public Backup? Load(string bakPath)
        {
            if (!File.Exists(bakPath))
                return null;

            string sql = $@"
                RESTORE HEADERONLY 
                FROM DISK = '{bakPath}'";

            var dr = SQL.FillDataTable(sql).Rows[0];

            string databaseName = dr["DatabaseName"].ToString() ?? string.Empty;
            DateTime backupDate = PH.ToDateTime(dr["BackupFinishDate"]);
            long sizeBytes = PH.ToLong(dr["BackupSize"]);

            return new Backup(databaseName, backupDate, sizeBytes);
        }

        /// <summary>
        /// Loads backup metadata for multiple .bak files.
        /// </summary>
        /// 
        /// <param name="bakPaths">
        /// A collection of full paths to .bak files.
        /// </param>
        /// 
        /// <returns>
        /// An enumerable sequence of <see cref="Backup"/> instances.
        /// </returns>
        public IEnumerable<Backup?> LoadMany(IEnumerable<string> bakPaths)
        {
            foreach (var path in bakPaths)
            {
                var backup = Load(path);

                if (backup != null)
                    yield return backup;
            }
        }
    }
}
