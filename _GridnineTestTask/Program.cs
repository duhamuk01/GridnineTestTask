using System;

namespace Gridnine.FlightCodingTest
{
	public class Program
	{
		public static void Main()
		{
			var flightBuilder = new FlightBuilder();
			var testFlights = flightBuilder.GetFlights();

			var rule1 = new DepBeforeCertainTimeRule(DateTime.Now);
			var rule2 = new SegWithArrTimeBeforeDepRule();
			var rule3 = new GroundTimeMoreThanRule(new TimeSpan(2, 0, 0));

			var resultCollection1 = Filter<Flight>.FilterCollection(testFlights, rule1);
			var resultCollection2 = Filter<Flight>.FilterCollection(testFlights, rule2);
			var resultCollection3 = Filter<Flight>.FilterCollection(testFlights, rule3);

			var resultCollection4 = Filter<Flight>.FilterCollection(testFlights, rule1, rule2);

			Console.WriteLine("DepartureBeforeCertainTimeRule:\n" + resultCollection1.ToStringExt());
			Console.WriteLine("SegmentsWithArrivalTimeBeforeDepartureRule:\n" + resultCollection2.ToStringExt());
			Console.WriteLine("GroundTimeMoreThanRule:\n" + resultCollection3.ToStringExt());

			Console.WriteLine("SegmentsWithArrivalTimeBeforeDepartureRule +\n" +
							  "DepartureBeforeCertainTimeRule:\n" + resultCollection4.ToStringExt());

			Console.ReadKey(true);
		}
	}
}
