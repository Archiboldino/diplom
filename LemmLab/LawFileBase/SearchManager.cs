using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LemmLab;
using FileBase;
namespace LawFileBase
{
    public class SearchManager
    {
        /// <summary>
        /// Об'єкт классу LemmManager, що використовується для нормалізації слів.
        /// </summary>
        private LemmManager e = new LemmManager();
        /// <summary>
        /// Об'єкт классу FileBaseManager, що використовується для доступу до файлової бази данних.
        /// </summary>
        public FileBaseManager LawBaseManager = new FileBaseManager(".\\FB");
        /// <summary>
        /// Отримання списку TF-індексів та назв документів в яких є задане слово.
        /// </summary>
        /// <param name="word">Слово, по якому потрібно проводити пошук. Повинне бути в словнику.</param>
        /// <returns>Список TF-індексів та назв документів.</returns>
        public string[] GetDocsWithWord(string word)
        {
            string[] li = LawBaseManager.GetDictionary();
            string filename = "";
            foreach (string g in li)
            {
                if ((g.Split(' '))[1] == word) { filename = (g.Split(' '))[0]; break; }
            }
            return LawBaseManager.GetWordFile(filename);
        }
        /// <summary>
        /// Отримання списку TF/IDF-індексів та назв документів в яких є задане слово.
        /// </summary>
        /// <param name="word">Слово, по якому потрібно проводити пошук. Повинне бути в словнику.</param>
        /// <returns>Список TF/IDF-індексів та назв документів.</returns>
        public Dictionary<string, double> GetDocsWithWordTFIDF(string word)
        {
            string[] li = LawBaseManager.GetDictionary();
            string filename = "";
            foreach (string g in li)
            {
                if ((g.Split(' '))[1] == word) { filename = (g.Split(' '))[0]; break; }
            }
            var res = new Dictionary<string, double>();
            if (filename != "")
            {
                li = LawBaseManager.GetWordFile(filename);
                string[] all = LawBaseManager.GetListOfFiles();

                foreach (var g in li)
                {
                    res.Add(g.Split(' ')[0], Convert.ToDouble(g.Split(' ')[1]));
                }
                foreach (var g in all)
                {
                    if (res.ContainsKey(g.Split(' ')[0]))
                    {
                        res[g.Split(' ')[0]] *= (Math.Log((double)all.Length / (double)li.Length) + 0.01) / Convert.ToDouble(g.Split(' ')[1]);
                    }
                }
            }
            return res;
        }
        /// <summary>
        /// Додавання до існуючого списку з назв та IDF/TF-індексів документів ще одного такого списку шляхом додавання значень індексів IDF/TF, що належать одному і тому ж документу.
        /// </summary>
        /// <param name="a">Список з імен та IDF/TF-індексів документів.</param>
        /// <param name="b">Список з імен та IDF/TF-індексів документів.</param>
        /// <returns>Результат додавання.</returns>
        private Dictionary<string, double> CocQueris(Dictionary<string, double> a, Dictionary<string, double> b)
        {
            foreach (var g in b)
            {
                if (a.ContainsKey(g.Key))
                {
                    a[g.Key] += g.Value;
                }
                else
                {
                    a.Add(g.Key, g.Value);
                }
            }
            return a;
        }
        /// <summary>
        /// Проводить пошук за заданою стрічкою по документам.
        /// </summary>
        /// <param name="searchLine">Стрічка, по якій проводиться пошук.</param>
        /// <returns>Список з імен документів.</returns>
        public string[] SearchLine(string searchLine)
		{
			var resList = new Dictionary<string, double>();
			var wordsList = e.ToWords(searchLine);
			var lemmList = new List<string>();
			foreach (var g in wordsList)
			{
				lemmList.Add(e.ToLemm(g));
			}
			foreach (var g in lemmList)
			{
				resList = CocQueris(resList, GetDocsWithWordTFIDF(g));
			}
			var sortedOneList = from pair in resList
								orderby pair.Value descending
								select pair.Key;
			return sortedOneList.ToArray();
        }
		public string[] SearchAll()
		{
			var resList = new Dictionary<string, double>();
			var AllList = LawBaseManager.GetListOfFiles();
			foreach (var t in AllList)
			{
				resList[t.Split(' ')[0]] = 0;
			}
			var sortedOneList = from pair in resList
								orderby pair.Value descending
								select pair.Key;
			return sortedOneList.ToArray();
		}
        /// <summary>
        /// Отримання назви законодавчого документу.
        /// </summary>
        /// <param name="name">Назва файлу документу.</param>
        /// <returns>Назва законодавчого документу.</returns>
        public string GetPrewiew(string name)
        {
            return LawBaseManager.GetName(name);
        }
        /// <summary>
        /// Отримання змісту законодавчого документу.
        /// </summary>
        /// <param name="name">Ім'я файлу законодавчого документу.</param>
        /// <returns>Зміст законодавчого документу.</returns>
        public string GetPage(string name)
        {

            var list = LawBaseManager.GetHtm(name);
            string page = "";
            foreach(var g in list)
            {
                page += g;
            }
            return page;
        }
		public void doit()
		{
			LawBaseManager.doit();
		}
    }
}
