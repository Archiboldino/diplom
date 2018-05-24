using System;
using System.Collections.Generic;

namespace Data.Entity
{
    public class Issue
    {
        public int id;
        public string name;
        public string description;
        public DateTime creationDate;

        public Issue(int id)
        {
            this.id = id;
        }

        public Issue(int id, string name, string description, DateTime creationDate, string seriesId) : this(id)
        {
            this.name = name;
            this.description = description;
            this.creationDate = creationDate;
        }

        public override bool Equals(object obj)
        {
            var issue = obj as Issue;
            return issue != null &&
                   id == issue.id;
        }

        public override int GetHashCode()
        {
            return 1877310944 + id.GetHashCode();
        }

        public override string ToString()
        {
            return name;
        }
    }

    public class IssueMapper
    {
        public static Issue Map(List<Object> row)
        {
            var i = new Issue(Int32.Parse(row[0].ToString()))
            {
                name = row[1].ToString(),
                description = row[2].ToString(),
                creationDate = DateTime.Parse(row[3].ToString()),
            };

            return i;
        }
    }
}