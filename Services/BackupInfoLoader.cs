using FastRestorer.Models;

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
        public Backup Load(string bakPath)
        {
            return new Backup("SampleDatabase", DateTime.Now, 104857600); // 100 MB
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
        public IEnumerable<Backup> LoadMany(IEnumerable<string> bakPaths)
        {
            foreach (var path in bakPaths)
                yield return Load(path);
        }
    }
}
