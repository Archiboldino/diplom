using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class CalculationSeries
    {
        public int id;
        public string name;
        public string description;

        public CalculationSeries()
        {
        }

        public CalculationSeries(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }

        public override string ToString()
        {
            return name;
        }
    }

	public class CalculatoinSeriesMapper 
	{
		public static CalculationSeries Map(List<Object> row)
		{
			var calc = new CalculationSeries();
			calc.id = Int32.Parse(row[0].ToString());
			calc.name = row[1].ToString();
			calc.description = row[2].ToString();

			return calc;
		}
	}
}
