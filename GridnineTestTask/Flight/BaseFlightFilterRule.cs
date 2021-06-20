using System;

namespace Gridnine.FlightCodingTest
{
	abstract public class BaseFlightFilterRule : ICheck<Flight>
	{
		public bool Check(Flight flight)
		{
			if (flight == null)
				throw new ArgumentNullException(nameof(flight), "Flight can't be null");
			if (flight.Segments == null)
				throw new ArgumentException("Flight can't have no segments", nameof(flight));

			return DoesMatch(flight);
		}

		abstract public bool DoesMatch(Flight flight);
	}
}
