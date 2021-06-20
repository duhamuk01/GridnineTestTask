using System.Collections.Generic;
using System.Text;

namespace Gridnine.FlightCodingTest
{
    public class Flight
    {
        public IList<Segment> Segments { get; set; }
		public override string ToString()
		{
			StringBuilder strBuilder = new StringBuilder();
			foreach (var e in Segments)
			{
				strBuilder.Append(e.ToString());
				strBuilder.Append("\n");
			}
			strBuilder.Remove(strBuilder.Length - 1, 1);
			return strBuilder.ToString();
		}
	}
}
