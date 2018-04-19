using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace FileBase
{
    public class FileBaseManager
    {
        private string location;
        public FileBaseManager()
        {
            location = "";
        }
        public FileBaseManager(string path)
        {
            if (path[path.Length - 1] != '\\')
            {
                this.location = path + '\\';
            }
            else
            {
                this.location = path;
            }
        }
        public void SetLocation(string path)
        {
            if(path[path.Length-1] != '\\')
            {
                this.location = path + '\\';
            } else
            {
                this.location = path;
            }
        }

        public string[] GetFile(string name)
        {
            return File.ReadAllLines(location + name, Encoding.Default);
        }
        public string[] GetWordFile(string name)
        {
            return File.ReadAllLines(location + "TF\\" + name, Encoding.Default);
        }
        public string[] GetDictionary()
        {
            return File.ReadAllLines(location + "_dictionary", Encoding.Default);
        }
        public string GetHtm(string name)
        {
            return File.ReadAllText(location + name + ".htm", Encoding.GetEncoding(1251)); /*ReadAllLines*/
        }
        public string[] GetListOfFiles()
        {
            return File.ReadAllLines(location + "_listOfFiles", Encoding.Default);
        }

        public void WriteDef(string[] st)
        {
            File.WriteAllLines(location + "_out", st, Encoding.Default);
        }
        public void WriteToFile(string name ,string[] st)
        {
            File.WriteAllLines(location + name, st, Encoding.Default);
        }
        public string GetName(string name)
        {
            var mFile = GetFile(name);
            var re1 = new Regex("<span class=rvts70>(.*)</span>");
            var re2 = new Regex("<span class=rvts66>(.*)</span>");
            var re3 = new Regex("<span class=rvts23>(.*)</span>");
            string res = "";
            foreach(var g in mFile)
            {
                if(re1.IsMatch(g))
                {
                    res+= (re1.Match(g).Groups[1].Value) + " ";
                }
                if (re2.IsMatch(g))
                {
                    res += (re2.Match(g).Groups[1].Value) + " ";
                }
                if (re3.IsMatch(g))
                {
                    res += (re3.Match(g).Groups[1].Value) + " ";
                    return res;
                }
            }
            return "none";
        }
    }
}
