using System;

namespace Gridnine.FlightCodingTest
{
    public class Segment
    {
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
		public override string ToString()
		{
			return $"{DepartureDate.ToString()} {ArrivalDate.ToString()}";
		}
	}
}
