using System;
using System.Collections.Generic;
using System.Linq;

namespace Gridnine.FlightCodingTest
{
    public class FlightBuilder
    {
        private DateTime _threeDaysFromNow;

        public FlightBuilder()
        {
            _threeDaysFromNow = DateTime.Now.AddDays(3);
        }

        public IList<Flight> GetFlights()
        {
            var flights = new List<Flight>();
            for (int i = 0; i < 1; i++)
            {
				//A normal flight with two hour duration
				flights.Add(CreateFlight(_threeDaysFromNow, _threeDaysFromNow.AddHours(2)));
				//A normal multi segment flight
				flights.Add(CreateFlight(_threeDaysFromNow, _threeDaysFromNow.AddHours(2),
										 _threeDaysFromNow.AddHours(3), _threeDaysFromNow.AddHours(5)));
				//A flight departing in the past
				flights.Add(CreateFlight(_threeDaysFromNow.AddDays(-6), _threeDaysFromNow));
				//A flight that arrives before it departs
				flights.Add(CreateFlight(_threeDaysFromNow, _threeDaysFromNow.AddHours(-6)));
				//Another flight that arrives before it departs //wasnt in the original set//
				flights.Add(CreateFlight(_threeDaysFromNow.AddDays(-4), _threeDaysFromNow.AddDays(-4).AddHours(-6)));
				//A flight with more than two hours ground time
				flights.Add(CreateFlight(_threeDaysFromNow, _threeDaysFromNow.AddHours(2), 
                                         _threeDaysFromNow.AddHours(5), _threeDaysFromNow.AddHours(6)));
				//Another flight with more than two hours ground time
				flights.Add(CreateFlight(_threeDaysFromNow, _threeDaysFromNow.AddHours(2),
										 _threeDaysFromNow.AddHours(3), _threeDaysFromNow.AddHours(4),
										 _threeDaysFromNow.AddHours(6), _threeDaysFromNow.AddHours(7)));
			}
            return flights;
        }

        private static Flight CreateFlight(params DateTime[] dates)
        {
            if (dates.Length % 2 != 0) throw new ArgumentException("You must pass an even number of dates,", "dates");

            var departureDates = dates.Where((date, index) => index % 2 == 0);
            var arrivalDates = dates.Where((date, index) => index % 2 == 1);

            var segments = departureDates.Zip(arrivalDates,
                                              (departureDate, arrivalDate) =>
                                              new Segment { DepartureDate = departureDate, ArrivalDate = arrivalDate }).ToList();

            return new Flight { Segments = segments };
        }
    }
}

