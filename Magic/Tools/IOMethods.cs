using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Magic.Tools
{
    class IOMethods
    {
        private static IOMethods instance;

        private IOMethods()
        {

        }

        public static IOMethods Instance
        {
            get
            {
                if (instance == null)
                    instance = new IOMethods();
                return instance;
            }
            private set { }
        }

        public void ReadData<T>(string path, ref Dictionary<int, T> list)
        {
            if (File.Exists(path))
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    string input;
                    input = reader.ReadLine();
                    list = JsonConvert.DeserializeObject<Dictionary<int, T>>(input);
                }
            }
        }

        public void WriteData<T>(string path, Dictionary<int, T> list)
        {
            string tempfile = Path.GetTempFileName();
            using (var sw = new StreamWriter(tempfile))
            {
                    sw.WriteLine(JsonConvert.SerializeObject(list));
            }
            File.Delete(path);
            File.Move(tempfile, path);
        }

    }
}
