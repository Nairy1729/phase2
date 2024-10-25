using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign13
{
    public class Program
    {
        public static void Main()
        {
            var manager = new TransportManager();

            // Adding sample schedules
            manager.AddSchedule(new TransportSchedule
            {
                TransportType = "Bus",
                Route = "City A to City B",
                DepartureTime = DateTime.Parse("2024-10-26 09:00"),
                ArrivalTime = DateTime.Parse("2024-10-26 12:00"),
                Price = 50,
                SeatsAvailable = 20
            });
            manager.AddSchedule(new TransportSchedule
            {
                TransportType = "Flight",
                Route = "City C to City D",
                DepartureTime = DateTime.Parse("2024-10-26 14:00"),
                ArrivalTime = DateTime.Parse("2024-10-26 16:00"),
                Price = 150,
                SeatsAvailable = 5
            });

            // LINQ Operations Examples
            var searchResults = manager.SearchSchedules(transportType: "Bus");
            var groupedByType = manager.GroupSchedulesByTransportType();
            //var orderedByPrice = manager.OrderSchedules("price");
            var filteredSchedules = manager.FilterSchedules(minSeatsAvailable: 10);
            var aggregateInfo = manager.GetAggregateInfo();
            var routesWithTimes = manager.GetRoutesWithDepartureTimes();

            // Display results
            Console.WriteLine("Search Results:");
            foreach (var schedule in searchResults)
                Console.WriteLine($"{schedule.TransportType} - {schedule.Route}");

            Console.WriteLine("\nGrouped By Transport Type:");
            foreach (var group in groupedByType)
            {
                Console.WriteLine($"\n{group.Key}:");
                foreach (var schedule in group.Value)
                    Console.WriteLine($"  {schedule.Route}");
            }

            Console.WriteLine("\nTotal Seats and Average Price:");
            Console.WriteLine($"Total Seats: {aggregateInfo.TotalSeats}, Average Price: {aggregateInfo.AveragePrice}");

            Console.WriteLine("\nRoutes and Departure Times:");
            foreach (var route in routesWithTimes)
                Console.WriteLine($"Route: {route.Route}, Departure: {route.DepartureTime}");

            Console.ReadKey();
        }
    }

}
