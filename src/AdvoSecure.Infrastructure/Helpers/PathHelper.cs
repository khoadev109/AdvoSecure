using System.Reflection;

namespace AdvoSecure.Infrastructure.Helpers
{
    public class PathHelper
    {
        public void Ensure(string path)
        {
            if (File.Exists(path))
            {
                return;
            }

            var folder = Path.GetDirectoryName(path);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            using FileStream file = File.Create(path);
        }

        public string Get(string path)
        {
            var returnPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path);

            return returnPath;
        }
    }
}
