using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        //initialiser une liste initialisé à vide new List<Flight> { };
        public List<Flight> Flights { get; set; } = new List<Flight> { };
        //Q16

        //declaration delegeate 
        public Action<Domain.Plane> FlightDetailsDel;
        public Func<string, float> DurationAverageDel;

        public FlightMethods() {
            //16
            //FlightDetailsDel = ShowFlightDetails;
            //DurationAverageDel=DurationAverage;
            //17
            FlightDetailsDel=p =>
            {
                var query = from flight in Flights
                            where flight.MyPlane == p
                            select flight;
                foreach (var items in query)
                {
                    Console.WriteLine(items.FlightDate + items.Destination);
                }

            };
            DurationAverageDel = d =>
            {
                var query = from flight in Flights
                            where flight.Destination == d
                            select flight.EstimatedDuration;
                return query.Average();
            };
        }
        //////////// 
        public float DurationAverage(string destination)
        {
            //var query =from flight in Flights
            //           where flight.Destination == destination
            //           select flight.EstimatedDuration;
            //return query.Average();
            var lambdaquery = Flights
                .Where(f => f.Destination == destination)
                .Select(f => f.EstimatedDuration);
            return lambdaquery.Average();
        }
        

        //Q6
        //public IList<DateTime> GetFlightDates(string destination)
        //{
        //    IList<DateTime> dates = new List<DateTime> { };
        //    //for (int i = 0; i < Flights.Count; i++)
        //    //{
        //    //    if (Flights[i].Destination.Equals(destination))
        //    //    {
        //    //        dates.Add(Flights[i].FlightDate);
        //    //    }
        //    //}
        //    //Q7
        //    foreach (var flight in Flights) {
        //        if (flight.Destination.Equals(destination))
        //               {
        //                   dates.Add(flight.FlightDate);
        //               }
        //            }
        //            return dates;
        //}
        public IList<DateTime> GetFlightDates(string destination) { 

        //9
        //var query=from f in Flights
        //          where f.Destination == destination
        //          select f.FlightDate;
        //return query.ToList();
        //19
        var lambdaquery=Flights
                .Where(f=> f.Destination == destination)
                .Select(f => f.FlightDate);
            return lambdaquery.ToList();


                  }
        public void GetFlights(string FilterType, string filterValue)
        {
            switch (FilterType)
            {
                case "Destination":
                    foreach (var flight in Flights)
                    {
                        if (flight.Destination.Equals(filterValue))
                            Console.WriteLine(flight);
                    }
                    break;
                case "FlightDate":
                    foreach (var flight in Flights)
                    {
                        if (flight.FlightDate == DateTime.Parse(filterValue))
                            Console.WriteLine(flight);
                    }
                    break;
                case "EstimatedDuration":
                    foreach (var flight in Flights)
                    {
                        if (flight.EstimatedDuration == float.Parse(filterValue))
                            Console.WriteLine(flight);
                    }
                    break;
                case "Departure":
                    foreach (var flight in Flights)
                    {
                        if (flight.Departure .Equals(filterValue))
                            Console.WriteLine(flight);
                    }
                    break;
                case "EffectiveArrival":
                    foreach (var flight in Flights)
                    {
                        if (flight.EffectiveArrival==DateTime.Parse(filterValue))
                            Console.WriteLine(flight);
                    }
                    break;




            }
        }

        public void DestinationGroupedFlights()
        {
            //var query = from flight in Flights
            //            group flight by flight.Destination;
            //foreach (var g in query)
            //{
            //    Console.WriteLine("Destination:"+g.Key);
            //    foreach(var f in g)
            //        Console.WriteLine("Décolage:"+f.FlightDate);
            //}
            var lambdaquery = Flights
                .GroupBy(f => f.Destination);
            foreach (var g in lambdaquery)
            {
                Console.WriteLine("Destination:"+g.Key);
               foreach(var f in g)
                    Console.WriteLine("Décolage:"+f.FlightDate);
            }
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            ////premiere methode
            //var query = from flight in Flights
            //            where DateTime.Compare(flight.FlightDate, startDate) >0 && (flight.FlightDate-startDate).TotalDays<7
            //            select flight;
            //return query.Count();
            //deuxieme methode
            //var query = from flight in Flights
            //            where flight.FlightDate>=startDate && (flight.FlightDate < startDate.AddDays(7))
            //            select flight;
            //return query.Count();
            var lambdaquery = Flights
                .Where(f => f.FlightDate >= startDate 
                && f.FlightDate < startDate.AddDays(7));
            return lambdaquery.Count();
        }

        public void ShowFlightDetails(Domain.Plane plane)
        {
            //var query = from flight in Flights
            //            where flight.MyPlane == plane
            //            select flight;
            //foreach (var items in query)
            //{
            //    Console.WriteLine(items.FlightDate+items.Destination);
            //}
            //19
            var lambdaquery=Flights
                .Where(f=>f.MyPlane==plane)
                .Select(f => f);//optionnel 
            foreach (var items in lambdaquery)
            {
               Console.WriteLine(items.FlightDate+items.Destination);
            }



        }

        public IList<Flight> OrderdDurationFlights()
        {
            //var query = from flight in Flights
            //            orderby flight.EstimatedDuration descending
            //            select flight;
            //return query.ToList();
            var lambdaquery = Flights
                .OrderByDescending(f => f.EstimatedDuration);
            return lambdaquery.ToList();

        }

        public IList<Traveller> SeniorTravellers(Flight flight)
        {
            // var query = from p in flight.ListPassengers.OfType<Traveller>()
            //            orderby p.BirthDate ascending
            //            select p;
            //return query.Take(3).ToList(); 
            var lambdaquery = flight.ListPassengers.OfType<Traveller>()
                .OrderBy(p => p.BirthDate);
            return lambdaquery.Take(3).ToList();
        }

        public void DestinationGroupedFlighst()
        {
            throw new NotImplementedException();
        }
    }

}
