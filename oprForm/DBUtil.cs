using System;

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