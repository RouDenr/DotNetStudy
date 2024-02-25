using LINQStudyTasks.Model;

namespace LINQStudyTasks;

using System;
using Xunit;

public class LinqTests
{
    private readonly ModelFunctions _modelFunctions;

    public LinqTests()
    {
        // Инициализация данных
        List<Company> companies =
        [
            new Company
            {
                Id = 1, Name = "SkyHigh Airlines", Country = "United States",
                RegistrationDate = new DateTime(2010, 5, 15), FleetSize = 20
            },
            new Company
            {
                Id = 2, Name = "AirLux", Country = "France", RegistrationDate = new DateTime(2005, 10, 20),
                FleetSize = 15
            },
            new Company
            {
                Id = 3, Name = "FlightMaster", Country = "Germany", RegistrationDate = new DateTime(2015, 3, 8),
                FleetSize = 25
            },
            new Company
            {
                Id = 4, Name = "JetStream Airways", Country = "United Kingdom",
                RegistrationDate = new DateTime(2012, 8, 30), FleetSize = 18
            },
            new Company
            {
                Id = 5, Name = "Pacific Wings", Country = "Australia", RegistrationDate = new DateTime(2018, 12, 10),
                FleetSize = 22
            }
        ];

        List<Trip> trips =
        [
            new Trip
            {
                Id = 1, CompanyId = 1, PlaneModel = "Boeing 737", DepartureCity = "New York",
                ArrivalCity = "Los Angeles", DepartureTime = new DateTime(2023, 6, 1, 8, 0, 0),
                ArrivalTime = new DateTime(2023, 6, 1, 11, 0, 0), PassengerCapacity = 150
            },
            new Trip
            {
                Id = 2, CompanyId = 2, PlaneModel = "Airbus A320", DepartureCity = "Paris", ArrivalCity = "Berlin",
                DepartureTime = new DateTime(2023, 7, 15, 9, 0, 0),
                ArrivalTime = new DateTime(2023, 7, 15, 11, 30, 0),
                PassengerCapacity = 180
            },
            new Trip
            {
                Id = 3, CompanyId = 3, PlaneModel = "Boeing 787", DepartureCity = "Berlin", ArrivalCity = "Rome",
                DepartureTime = new DateTime(2023, 8, 20, 10, 0, 0),
                ArrivalTime = new DateTime(2023, 8, 20, 13, 0, 0),
                PassengerCapacity = 200
            },
            new Trip
            {
                Id = 4, CompanyId = 1, PlaneModel = "Airbus A350", DepartureCity = "Los Angeles", ArrivalCity = "Tokyo",
                DepartureTime = new DateTime(2023, 9, 10, 11, 0, 0),
                ArrivalTime = new DateTime(2023, 9, 11, 14, 0, 0),
                PassengerCapacity = 300
            },
            new Trip
            {
                Id = 5, CompanyId = 4, PlaneModel = "Boeing 777", DepartureCity = "London", ArrivalCity = "Sydney",
                DepartureTime = new DateTime(2023, 10, 5, 12, 0, 0),
                ArrivalTime = new DateTime(2023, 10, 6, 16, 0, 0),
                PassengerCapacity = 250
            },
            
        ];

        List<PassengerTrip> passengerTrips =
        [
            new PassengerTrip
            {
                Id = 1, TripId = 1, PassengerId = 1, SeatNumber = "A1", TicketPrice = 200, TicketClass = "Business",
                BoardingTime = new DateTime(2023, 6, 1, 7, 0, 0)
            },
            new PassengerTrip
            {
                Id = 2, TripId = 2, PassengerId = 2, SeatNumber = "B2", TicketPrice = 150, TicketClass = "Economy",
                BoardingTime = new DateTime(2023, 7, 15, 8, 0, 0)
            },
            new PassengerTrip
            {
                Id = 3, TripId = 3, PassengerId = 3, SeatNumber = "C3", TicketPrice = 300, TicketClass = "First Class",
                BoardingTime = new DateTime(2023, 8, 20, 9, 0, 0)
            },
            new PassengerTrip
            {
                Id = 4, TripId = 4, PassengerId = 2, SeatNumber = "D4", TicketPrice = 250, TicketClass = "Business",
                BoardingTime = new DateTime(2023, 9, 10, 10, 0, 0)
            },
            new PassengerTrip
            {
                Id = 5, TripId = 5, PassengerId = 4, SeatNumber = "E5", TicketPrice = 180, TicketClass = "Economy",
                BoardingTime = new DateTime(2023, 10, 5, 11, 0, 0)
            },
            new PassengerTrip
            {
                Id = 6, TripId = 4, PassengerId = 2, SeatNumber = "F6", TicketPrice = 300, TicketClass = "Business",
                BoardingTime = new DateTime(2023, 6, 1, 7, 0, 0)
            },
        ];

        List<Passenger> passengers =
        [
            new Passenger
            {
                Id = 1, Name = "John Smith", Age = 35, Gender = "Male", Nationality = "American",
                PassportNumber = "US123456", Citizenship = "American", BirthDate = new DateTime(1988, 4, 20)
            },
            new Passenger
            {
                Id = 2, Name = "Emma Johnson", Age = 28, Gender = "Female", Nationality = "French",
                PassportNumber = "FR789012", Citizenship = "French", BirthDate = new DateTime(1995, 10, 15)
            },
            new Passenger
            {
                Id = 3, Name = "Max Müller", Age = 45, Gender = "Male", Nationality = "German",
                PassportNumber = "DE345678", Citizenship = "German", BirthDate = new DateTime(1978, 7, 5)
            },
            new Passenger
            {
                Id = 4, Name = "Sophia Lee", Age = 30, Gender = "Female", Nationality = "Australian",
                PassportNumber = "AU567890", Citizenship = "Australian", BirthDate = new DateTime(1993, 1, 12)
            },
            new Passenger
            {
                Id = 5, Name = "Alexander Wang", Age = 40, Gender = "Male", Nationality = "Chinese",
                PassportNumber = "CN901234", Citizenship = "Chinese", BirthDate = new DateTime(1982, 12, 30)
            }
        ];
        
        _modelFunctions = new ModelFunctions(companies, trips, passengerTrips, passengers);
    }

    // Инициализация данных (оставлено без изменений)

    /// <summary>
    /// Условие: Вернуть список компаний из указанной страны<br/>
    /// Сигнатура: public List<Company> GetCompaniesFromCountry(string country)
    /// </summary>
    [Fact]
    public void Task1_ReturnCompaniesFromCountry()
    {
        var result = _modelFunctions.GetCompaniesFromCountry("United States");
        Assert.Single(result);
    }

    
    /// <summary>
    /// Условие: Вернуть список рейсов из одного города в другой<br/>
    /// Сигнатура: public List<Trip> GetTripsFromCityToCity(string departureCity, string arrivalCity) 
    /// </summary>
    [Fact]
    public void Task2_ReturnTripsFromCityToCity()
    {
        var result = _modelFunctions.GetTripsFromCityToCity("New York", "Los Angeles");
        Assert.Single(result);
    }

    /// <summary>
    /// Условие: Вернуть список пассажиров старше указанного возраста<br/>
    /// Сигнатура: public List<Passenger> GetPassengersWithAgeAbove(int age)
    /// </summary>
    [Fact]
    public void Task3_ReturnPassengersWithAgeAbove30()
    {
        var result = _modelFunctions.GetPassengersWithAgeAbove(30);
        Assert.Equal(3, result.Count);
    }
    
    
    
    // Нормальные задачи
    /// <summary>
    /// Условие: Вернуть рейс с максимальной стоимостью билета<br/>
    /// Сигнатура: public Trip GetTripWithMaximumTicketPrice()
    /// </summary>
    [Fact]
    public void Task4_ReturnTripWithMaximumTicketPrice()
    {
        var result = _modelFunctions.GetTripWithMaximumTicketPrice();
        Assert.Equal("Boeing 787", result.PlaneModel);
    }

    /// <summary>
    /// Условие: Вернуть пассажира с самым дорогим билетом<br/>
    /// Сигнатура: public Passenger GetPassengerWithMostExpensiveTicket()
    /// </summary>
    [Fact]
    public void Task5_ReturnPassengerWithMostExpensiveTicket()
    {
        var result = _modelFunctions.GetPassengerWithMostExpensiveTicket();
        Assert.Equal("Max Müller", result.Name);
    }

    /// <summary>
    /// Условие: Вернуть список компаний, у которых есть рейсы после указанной даты<br/>
    /// Сигнатура: public List<Company> GetCompaniesWithTripsAfterDate(DateTime date)
    /// </summary>
    [Fact]
    public void Task6_ReturnCompaniesWithTripsAfterDate()
    {
        var result = _modelFunctions.GetCompaniesWithTripsAfterDate(new DateTime(2023, 8, 1));
        Assert.Equal(3, result.Count);
    }

    /// <summary>
    /// Условие: Вернуть список пассажиров, у которых есть билеты на рейсы указанной компании<br/>
    /// Сигнатура: public List<Passenger> GetPassengersWithTicketsForCompany(int companyId)
    /// </summary>
    [Fact]
    public void Task7_ReturnPassengersWithTicketsForCompany()
    {
        var result = _modelFunctions.GetPassengersWithTicketsForCompany("SkyHigh Airlines");
        var expected = new List<string> {"John Smith", "Emma Johnson"};
        Assert.Equal(expected, result.Select(p => p.Name).ToList());
    }
    
    
    // Сложные задачи
    /// <summary>
    /// Условие: Вернуть среднюю стоимость билета для указанной компании<br/>
    /// Сигнатура: public double GetAverageTicketPriceForCompany(int companyId)
    /// </summary>
    [Fact]
    public void Task8_ReturnAverageTicketPriceForCompany()
    {
        var result = _modelFunctions.GetAverageTicketPriceForCompany(1);
        Assert.Equal(250, result);
    }

    /// <summary>
    /// Условие: Вернуть пассажира с наибольшим количеством рейсов<br/>
    /// Сигнатура: public Passenger GetPassengerWithMostTrips()
    /// </summary>
    [Fact]
    public void Task9_ReturnPassengerWithMostTrips()
    {
        var result = _modelFunctions.GetPassengerWithMostTrips();
        const string expected = "Emma Johnson";
        Assert.Equal(expected, result.Name);
    }
    
    /// <summary>
    /// Условие: Вернуть список пассажиров на указанном рейсе<br/>
    /// Сигнатура: public List<Passenger> GetPassengersOnTrip(int tripId)
    [Fact]
    public void Task10_ReturnPassengersOnTrip()
    {
        var result = _modelFunctions.GetPassengersOnTrip(2);
        Assert.Single(result);
    }
    
    /// <summary>
    /// Условие: Вернуть информацию по пассажиру (кампания, все билеты это пассажира с этой кампанией)<br/>
    /// Сигнатура: public PassengerInfo GetPassengerCompanyInfo(int passengerId, string companyName)
    /// </summary>
    [Fact]
    public void Task11_ReturnPassengerCompanyInfo()
    {
        // Возвращаемый тип tuple (string, List<PassengerTrip>)
        var result = _modelFunctions.GetPassengerCompanyInfo(1);
        // Проверка имени компании
        Assert.Equal("SkyHigh Airlines", result.Item1);
        
    }

}
