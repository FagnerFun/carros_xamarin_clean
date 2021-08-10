using carros_xamarin_clean.Core.Domain.Interface;
using System.IO;

namespace carros_xamarin_clean.Droid.Util
{
    public class DataBaseAccessService : IDataBaseAccessPlataform
    {
        public string GetDataBasePath()
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), AppSettings.OffLineDataBaseName);
            if (!File.Exists(path))
                File.Create(path).Dispose();
            return path;
        }
    }
}