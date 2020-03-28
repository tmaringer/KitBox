using Newtonsoft.Json;
using projectCS.physical_components;
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
        
        public AngleBracket getCupboard()
        {
            AngleBracket obj = new AngleBracket();

            foreach (string line in File.ReadLines(_completePath))
            {
                obj = JsonConvert.DeserializeObject<AngleBracket>(line);
               // Console.WriteLine(obj);
                /*
                if (line.Contains("episode") & line.Contains("2006"))
                {
                    Console.WriteLine(line);
                }
                */
            }

            return obj;
        }

        public void test()
        {
            AngleBracket an = new AngleBracket();
            an.size = new ComponentSize(16, 15, 14);
            an.color = ComponentColor.brown;
            an.dimension = 3;
            //Console.WriteLine(an);

            string json = JsonConvert.SerializeObject(an);
            AngleBracket obj = JsonConvert.DeserializeObject<AngleBracket>(json);
            Console.WriteLine("après");
            Console.WriteLine(obj);

            te t = new te();
            t.s = new ComponentSize(5, 9, 7);

            string json2 = JsonConvert.SerializeObject(t);
            t = JsonConvert.DeserializeObject<te>(json2);
            //Console.WriteLine(t);
            /*
            Console.WriteLine(obj2.width);
            Console.WriteLine(obj2.height);
            Console.WriteLine(obj2.depth);
            */
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
