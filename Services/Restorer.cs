using FastRestorer.Models;

namespace FastRestorer.Services
{
    public class Restorer
    {
        private readonly Backup _backup;

        public Restorer(Backup backup)
        {
            _backup = backup;
        }

        public void Restore()
        {

        }
    }
}
