using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
	public static class DBUtilNikita
	{
		public static string AddQuotes(String i)
		{
			return "'" + i + "'";
		}
	}
}
