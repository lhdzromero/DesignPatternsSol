using System.IO;

namespace DesignPatterns.Solid
{
    public class Persintence {
        
        public void SaveToFile(Journal j, string filename, bool overwrite = false) {
            if(overwrite || !File.Exists(filename))
                File.WriteAllText(filename, j.ToString());
        }
        
    }
}