using Newtonsoft.Json;
using System;
using System.IO;

namespace projectCS.Tools_class
{
    public static class ComponentsDataSav
    {
        private static string _extension = ".json";
        private static string _folderPath = (Directory.GetParent(Environment.CurrentDirectory).Parent.FullName).Replace("\\projectCS", "") + "\\data";
        private static string _completePath = _folderPath + "\\object" + _extension;

        /// <summary>
        ///     Sav state of an object in .json file.
        /// </summary>
        /// <param name="obj">
        ///     Object whose sav data.
        /// </param>
        public static void savData(object obj)
        {
            createFolder();

            string json = JsonConvert.SerializeObject(obj);

            using (StreamWriter file = new StreamWriter(_completePath, true))
            {
                file.WriteLine(json);
            }
        }

        public static AngleBracket getAngleBracket()
        {
            AngleBracket obj = new AngleBracket();

            foreach (string line in File.ReadLines(_completePath))
            {
                obj = JsonConvert.DeserializeObject<AngleBracket>(line);
            }

            return obj;
        }

        /// <summary>
        ///     Reset the json file where the object data have been saved.
        /// </summary>
        public static void resetFile()
        {
            createFolder();

            if (Directory.Exists(_folderPath))
            {
                File.WriteAllText(_completePath, string.Empty);
            }
        }

        private static void createFolder()
        {
            if (!(Directory.Exists(_folderPath)))
            {
                Directory.CreateDirectory(_folderPath);
            }
        }
    }
}
