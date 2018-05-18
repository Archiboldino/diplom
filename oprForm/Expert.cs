using System;
using System.Collections.Generic;

namespace oprForm
{
    public class Expert
    {
        public int id;
        public string name;

        public override string ToString()
        {
            return name;
        }
    }

    public class ExpertMapper
    {
        public static Expert Map(List<Object> row)
        {
            var i = new Expert();
            i.id = Int32.Parse(row[0].ToString());
            i.name = row[1].ToString();

            return i;
        }
    }
}