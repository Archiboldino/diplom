using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
	public class Resource
	{
		public int id;
		public string name;
		public string description;
		public int value;

        public override bool Equals(object obj)
        {
            var resource = obj as Resource;
            return resource != null &&
                   id == resource.id;
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

	public class ResourceMapper 
	{
		public static Resource Map(List<Object> row)
		{
			var r = new Resource();
			r.id = Int32.Parse(row[0].ToString());
			r.name = row[1].ToString();
			r.description = row[2].ToString();

			return r;
		}
	}
}
