using Newtonsoft.Json;
using System;
using System.IO;

namespace projectCS.Tools_class
{
    public class ComponentsDataSav
    {
        private string _extension;
        private string _completePath;
        private string _folderPath;
        
        public ComponentsDataSav() : this(".json")
        {
        }

        public ComponentsDataSav(string extension)
        {
            this._extension = extension;
            this._folderPath = (Directory.GetParent(Environment.CurrentDirectory).Parent.FullName).Replace("\\projectCS", "");
            this._folderPath += "\\data";
            this._completePath += _folderPath + "\\object" + _extension;
            createFolder();
        }

        public void savData(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);

            using (StreamWriter file = File.AppendText(_completePath))
            {
                file.WriteLine(json);
            }
        }

        public void resetFile()
        {
            if (Directory.Exists(_folderPath))
            {
                File.WriteAllText(_completePath, string.Empty);
            }
        }

        private void createFolder()
        {
            if (!(Directory.Exists(_folderPath)))
            {
                DirectoryInfo di = Directory.CreateDirectory(_folderPath);
            }
        }
    }
}
