using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

//instanciation lel plane1 b constructeur par defaut
//Plane plane1 = new Plane();
//plane1.Capacity = 100;
//plane1.ManufactureDate = new DateTime(2024, 05, 23);
//plane1.PlaneType = PlaneType.Airbus;
//plane1.PlaneId = 1;
//Console.WriteLine(plane1.ToString());
//Plane plane2 = new Plane(PlaneType.Airbus,200,DateTime.Now);
//Console.WriteLine(plane2.ToString());


//initilisateur d'objet 
Plane plane3 = new Plane {ManufactureDate=DateTime.Now,Capacity=150,PlaneId=3};
Console.WriteLine(plane3.ToString());
Passenger passenger = new Passenger { FirstName = "eya", LastName = "yengui", EmailAdress = "eya.yengui@esprit.tn"};
Console.WriteLine("Avant extension");
Console.WriteLine(passenger.ToString());
passenger.UpperFullName();
Console.WriteLine("Apres extension");
Console.WriteLine(passenger.ToString());
Console.WriteLine(passenger.ToString());
Console.WriteLine(passenger.CheckProfile("eya","yengui")); 
Console.WriteLine(passenger.CheckProfile("Mariem", "Yengui"));
Console.WriteLine(passenger.CheckProfile("eya", "yengui","eya.yengui@esprit.tn"));
Staff staff1 = new Staff { FirstName="StaffName", LastName="LastNameStaff"};
Traveller traveller1 = new Traveller {Nationality="Nationality", FirstName="FirstNameTraveller" };
passenger.PassengerType();
staff1.PassengerType();
traveller1.PassengerType();
//deuxième atelier
//Q5
//testdata liste vide en flightMethods et listflights fama des vols fel testdata
FlightMethods flightMethods = new FlightMethods
{
    Flights=TestData.listFlights
};
//Q7
foreach (var item in flightMethods.GetFlightDates("Paris"))
{
    Console.WriteLine(item);
}
Console.WriteLine("question8");
flightMethods.GetFlights("Destination", "Paris");
//Q10
flightMethods.ShowFlightDetails(TestData.BoingPlane);
Console.WriteLine("question10");
//Q11
Console.WriteLine(flightMethods.ProgrammedFlightNumber(new DateTime(2022, 01, 01, 21, 10, 10)));
Console.WriteLine("question 11");
//Q12
Console.WriteLine(flightMethods.DurationAverage("Madrid"));
Console.WriteLine("question 12");
//Q13
Console.WriteLine(flightMethods.OrderdDurationFlights());
Console.WriteLine("question 12");
Console.WriteLine("-----------------------question 14-----------------------");
foreach (var item in flightMethods.SeniorTravellers(TestData.flight1))
{
    Console.WriteLine(item);
}
Console.WriteLine("-----------------------question 15-----------------------");
flightMethods.DestinationGroupedFlights();
Console.WriteLine("-----------------------question 16 sans delegate-----------------------");
flightMethods.ShowFlightDetails(TestData.Airbusplane);
Console.WriteLine("-----------------------question 16 avec delegate-----------------------");
flightMethods.FlightDetailsDel(TestData.Airbusplane);

