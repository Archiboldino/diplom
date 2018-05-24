using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LemmLab
{
    public class LemmManager
    {
        List<Regex> lemmListEnd;
        /// <summary>
        /// Перетворює стрічку в регулярний вираз та додає умову знаходження в кінці тексту.
        /// </summary>
        /// <param name="end">Стрічка, що перетворюється.</param>
        /// <returns>Регулярний вираз.</returns>
        private Regex RegExEnd(string end)
        {
            return new Regex( end +"$");
        }
		private Regex RegExBegin(string begin)
		{
			return new Regex("^" + begin);
		}
		/// <summary>
		/// Конструктор.
		/// </summary>
		public LemmManager()
        {
            lemmListEnd = new List<Regex>();
            lemmListEnd.Add(RegExEnd("ському"));
            lemmListEnd.Add(RegExEnd("ськими"));
            lemmListEnd.Add(RegExEnd("ської"));
            lemmListEnd.Add(RegExEnd("ською"));
            lemmListEnd.Add(RegExEnd("ським"));
            lemmListEnd.Add(RegExEnd("ська"));
            lemmListEnd.Add(RegExEnd("тись"));
            lemmListEnd.Add(RegExEnd("тися"));
            lemmListEnd.Add(RegExEnd("ого"));
            lemmListEnd.Add(RegExEnd("ити"));
            lemmListEnd.Add(RegExEnd("ись"));
            lemmListEnd.Add(RegExEnd("ою"));
            lemmListEnd.Add(RegExEnd("ам"));
            lemmListEnd.Add(RegExEnd("ом"));
            lemmListEnd.Add(RegExEnd("ами"));
            lemmListEnd.Add(RegExEnd("ах"));
            lemmListEnd.Add(RegExEnd("ої"));
            lemmListEnd.Add(RegExEnd("ії"));
            lemmListEnd.Add(RegExEnd("ія"));
            lemmListEnd.Add(RegExEnd("ій"));
            lemmListEnd.Add(RegExEnd("ти"));
            lemmListEnd.Add(RegExEnd("ть"));
            lemmListEnd.Add(RegExEnd("ів"));
            lemmListEnd.Add(RegExEnd("им"));
            lemmListEnd.Add(RegExEnd("а"));
            lemmListEnd.Add(RegExEnd("и"));
            lemmListEnd.Add(RegExEnd("і"));
            lemmListEnd.Add(RegExEnd("у"));
            lemmListEnd.Add(RegExEnd("о"));
            lemmListEnd.Add(RegExEnd("я"));
            lemmListEnd.Add(RegExEnd("ь"));
            lemmListEnd.Add(RegExEnd("є"));
			lemmListEnd.Add(RegExBegin("пре"));
			lemmListEnd.Add(RegExBegin("все"));
			lemmListEnd.Add(RegExBegin("до"));
			lemmListEnd.Add(RegExBegin("по"));
		}
        /// <summary>
        /// Нормалізує слово.
        /// </summary>
        /// <param name="str">Слово, що потребує нормалізації.</param>
        /// <returns>Нормалізоване слово.</returns>
        public string ToLemm(string str)
        {
            foreach( Regex re in lemmListEnd)
            {
                if (re.IsMatch(str))
                {
                    str = re.Replace(str, "");
                }
            }
            return str;
        }
		/// <summary>
		/// Перевіряє, чи потрібно слово індексувати
		/// </summary>
		/// <param name="str">Слово, що потребує перевірки.</param>
		/// <returns>Результат</returns>
		public bool IsWorthy(string str)
		{
			bool res = false;
			if (str.Count() > 2) res = true;
			return res;
		}
		/// <summary>
		/// Перетворює стрічку в масив слів.
		/// </summary>
		/// <param name="str">Стрічка, що потребує перетворення.</param>
		/// <returns>Список слів.</returns>
		public string[] ToWords(string str)
        {
            
            Regex re = new Regex("(\\s)|[.,:;\"\"()]");
            return re.Split(str.ToLower());
        }
        /// <summary>
        /// Перетворює зміст html-сторінки в масив слів. Зміст html-тегів при цьому ігнорується.
        /// </summary>
        /// <param name="str">Зміст html-сторінки.</param>
        /// <returns>Масив слів.</returns>
        public string[] ToWordsHTML(string str)
        {
            Regex re1 = new Regex("(\\s)|[.,:;\"()]");
            Regex re2 = new Regex("<(.|\\s|&quot)*?>");
            Regex re3 = new Regex("<style>(.|\\s)*?<\\/style>");
            return (from a in re1.Split(re2.Replace(re3.Replace(str.ToLower(), ""), "")) where a.Trim() != "" select a.Trim()).ToArray();
        }
    }
}
