using System;
using System.Collections.Generic;

namespace Data.Entity
{
    public class Event
    {
        public int id;
        public string name;
        public string description;
        public string lawyerVer;
        public string dmVer;
        public int userId;
        public int issueId;

        public override string ToString()
        {
            return name;
        }
    }

    public class EventMapper
    {
        public static Event Map(List<Object> row)
        {
            var e = new Event
            {
                id = Int32.Parse(row[0].ToString()),
                name = row[1].ToString(),
                description = row[2].ToString(),
                lawyerVer = row[3]?.ToString(),
                dmVer = row[4]?.ToString(),
                userId = row[5].ToString().Length != 0 ? Int32.Parse(row[5].ToString()) : -1,
                issueId = row[6].ToString().Length != 0 ? Int32.Parse(row[6].ToString()) : -1
            };

            return e;
        }
    }

    public class EventTemplateMapper
    {
        public static Event Map(List<Object> row)
        {
            var e = new Event
            {
                id = Int32.Parse(row[0].ToString()),
                name = row[1].ToString(),
                description = row[2].ToString()
            };

            return e;
        }
    }
}