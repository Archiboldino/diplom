﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
	public static class DBUtil
	{
		public static string AddQuotes(String i)
		{
			return "'" + i + "'";
        }
        public static string ValidateForSQL(object str)
        {
            if (str is string)
                return AddQuotes((string)str);
            return AddQuotes(str.ToString());
        }
    }
}
