using System;

namespace Data
{
    public static class DBUtil
    {
        public static string AddQuotes(String i)
        {
            return "'" + i + "'";
        }
    }
}