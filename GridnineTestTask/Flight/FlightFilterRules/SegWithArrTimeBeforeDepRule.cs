namespace Gridnine.FlightCodingTest
{
	class SegWithArrTimeBeforeDepRule : BaseFlightFilterRule
	{
		public override bool DoesMatch(Flight flight)
		{
			foreach (var segment in flight.Segments)
				if (segment.ArrivalDate < segment.DepartureDate)
					return true;
			return false;
		}
	}
}
