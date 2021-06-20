using System;
using System.Linq;

namespace Gridnine.FlightCodingTest
{
	public class GroundTimeMoreThanRule : BaseFlightFilterRule
	{
		private TimeSpan _groundTime;
		public TimeSpan GroundTime
		{
			get { return _groundTime; }
			set { 
				if (value.Ticks < 0) throw new ArgumentOutOfRangeException();
				_groundTime = value; 
				}
		}
		
		public GroundTimeMoreThanRule(TimeSpan grndTime)
		{
			GroundTime = grndTime;
		}
		public override bool DoesMatch(Flight flight)
		{
			TimeSpan grndTime = new TimeSpan();
			var segCount = flight.Segments.Count();
			for (int i = 0; i < segCount - 1; i++)
			{
				grndTime += (flight.Segments[i + 1].DepartureDate - flight.Segments[i].ArrivalDate);
			}
			if (grndTime > GroundTime)
				return true;
			return false;
		}
	}
}
