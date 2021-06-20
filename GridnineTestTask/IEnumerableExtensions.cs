using System;
using System.Collections.Generic;
using System.Text;

namespace Gridnine.FlightCodingTest
{
	public static class IEnumerableExtensions
	{
		public static string ToStringExt(this IEnumerable<Flight> enumerable)
		{
			if (enumerable == null)
				throw new ArgumentNullException(nameof(enumerable));

			var strBuilder = new StringBuilder();
			int i = 0;
			foreach (var e in enumerable)
			{
				strBuilder.Append($"[{i++}] ");
				strBuilder.Append(e.ToString());
				strBuilder.AppendLine();
			}
			return strBuilder.ToString();
		}
	}
}
