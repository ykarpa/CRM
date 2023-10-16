using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBinit
{
	public static class DateExtension
	{
		public static Random random = new Random();
		public static DateTime GenerateRandomDate(this DateTime d)
		{
			DateTime start = new DateTime(1995, 1, 1);
			int range = (DateTime.Today - start).Days;
			return start.AddDays(random.Next(range));
		}
	}
}
