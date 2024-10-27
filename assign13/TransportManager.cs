using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign13
{
    public class TransportManager
    {
        private List<TransportSchedule> schedules = new List<TransportSchedule>();

        public void AddSchedule(TransportSchedule schedule)
        {
            schedules.Add(schedule);
        }

        public List<TransportSchedule> GetAllSchedules()
        {
            return schedules;
        }


        public List<TransportSchedule> SearchSchedules(string transportType = null, string route = null, DateTime? time = null)
        {
            return schedules
                .Where(s =>
                    (transportType == null || s.TransportType.Equals(transportType, StringComparison.OrdinalIgnoreCase)) &&
                    (route == null || s.Route.Equals(route, StringComparison.OrdinalIgnoreCase)) &&
                    (time == null || s.DepartureTime == time))
                .ToList();
        }

        public Dictionary<string, List<TransportSchedule>> GroupSchedulesByTransportType()
        {
            return schedules
                .GroupBy(s => s.TransportType)
                .ToDictionary(g => g.Key, g => g.ToList());
        }


        public List<TransportSchedule> OrderSchedules(string orderBy)
        {
            orderBy = orderBy.ToLower();

            switch (orderBy)
            {
                case "departuretime":
                    return schedules.OrderBy(s => s.DepartureTime).ToList();

                case "price":
                    return schedules.OrderBy(s => s.Price).ToList();

                case "seatsavailable":
                    return schedules.OrderBy(s => s.SeatsAvailable).ToList();

                default:
                    return schedules; // Return unsorted if no valid criteria are specified
            }
        }





        public List<TransportSchedule> FilterSchedules(int? minSeatsAvailable = null, DateTime? startTime = null, DateTime? endTime = null)
        {
            return schedules
                .Where(s =>
                    (minSeatsAvailable == null || s.SeatsAvailable >= minSeatsAvailable) &&
                    (startTime == null || s.DepartureTime >= startTime) &&
                    (endTime == null || s.ArrivalTime <= endTime))
                .ToList();
        }

        public (int TotalSeats, decimal AveragePrice) GetAggregateInfo()
        {
            int totalSeats = schedules.Sum(s => s.SeatsAvailable);
            decimal averagePrice = schedules.Average(s => s.Price);
            return (totalSeats, averagePrice);
        }

        public List<(string Route, DateTime DepartureTime)> GetRoutesWithDepartureTimes()
        {
            return schedules.Select(s => (s.Route, s.DepartureTime)).ToList();
        }










    }
}
