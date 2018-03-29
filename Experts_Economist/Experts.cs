using System;
using System.Collections.Generic;

namespace Experts_Economist
{
    public class Expert
    {
        public int id;
        public string name;

        public Expert(int id)
        {
            this.id = id;
        }

        public Expert(int id, string name) : this(id)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }

    public class ExpertMapper
    {
        public static Expert Map(List<Object> row)
        {
            var i = new Expert(Int32.Parse(row[0].ToString()))
            {
                name = row[1].ToString()
            };
            return i;
        }
    }
}