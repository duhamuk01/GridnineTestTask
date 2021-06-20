using System;

namespace Gridnine.FlightCodingTest
{
	public class DepBeforeCertainTimeRule : BaseFlightFilterRule
	{
		public DateTime DepartureTime { get; set; }
		public DepBeforeCertainTimeRule(DateTime dateTime)
		{
			DepartureTime = dateTime;
		}
		public override bool DoesMatch(Flight flight)
		{
			return flight.Segments[0].DepartureDate < DepartureTime;
		}
	}
}
