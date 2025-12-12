using FastRestorer.Models;
using System.IO;

namespace FastRestorer.Services
{
    /// <summary>
    /// Provides methods for loading backup metadata from one or more SQL Server .bak files.
    /// </summary>
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
            DateTime backupFinishDate = PH.ToDateTime(dr["BackupFinishDate"]);
            long backupSize = PH.ToLong(dr["BackupSize"]);

            return new Backup(databaseName, backupFinishDate, bakPath, backupSize);
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
