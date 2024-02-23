using LINQStudyTasks.Model;

namespace LINQStudyTasks;

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class LINQTests
{
    private List<Company> companies;
    private List<Trip> trips;
    private List<PassengerTrip> passengerTrips;
    private List<Passenger> passengers;

    public LINQTests()
    {
        // Инициализация данных (оставлено без изменений)
    }

    /// <summary>
    /// Условие: Вернуть список компаний из указанной страны
    /// Сигнатура: public List<Company> GetCompaniesFromCountry(string country)
    /// </summary>
    [Fact]
    public void Task1_ReturnCompaniesFromCountry()
    {
        var result = GetCompaniesFromCountry("United States");
        Assert.Single(result);
    }

    
    /// <summary>
    /// Условие: Вернуть список рейсов из одного города в другой
    /// Сигнатура: public List<Trip> GetTripsFromCityToCity(string departureCity, string arrivalCity) 
    /// </summary>
    [Fact]
    public void Task2_ReturnTripsFromCityToCity()
    {
        var result = GetTripsFromCityToCity("New York", "Los Angeles");
        Assert.Single(result);
    }

    [Fact]
    public void Task3_ReturnPassengersWithAgeAbove30()
    {
        var result = GetPassengersWithAgeAbove(30);
        Assert.Equal(3, result.Count);
    }
    
    // Нормальные задачи
    [Fact]
    public void Task4_ReturnTripWithMaximumTicketPrice()
    {
        var result = GetTripWithMaximumTicketPrice();
        Assert.Equal("Boeing 787", result.PlaneModel);
    }

    [Fact]
    public void Task5_ReturnPassengerWithMostExpensiveTicket()
    {
        var result = GetPassengerWithMostExpensiveTicket();
        Assert.Equal("John Smith", result.Name);
    }

    [Fact]
    public void Task6_ReturnCompaniesWithTripsAfterDate()
    {
        var result = GetCompaniesWithTripsAfterDate(new DateTime(2023, 8, 1));
        Assert.Equal(3, result.Count);
    }

    // Сложные задачи
    [Fact]
    public void Task7_ReturnAverageTicketPriceForCompany()
    {
        var result = GetAverageTicketPriceForCompany(1);
        Assert.Equal(225, result);
    }

    [Fact]
    public void Task8_ReturnPassengerWithMostTrips()
    {
        var result = GetPassengerWithMostTrips();
        Assert.Equal("John Smith", result.Name);
    }

    [Fact]
    public void Task9_ReturnPassengersOnTrip()
    {
        var result = GetPassengersOnTrip(2);
        Assert.Single(result);
    }

    // Сигнатуры методов для выполнения задач

    // Легкие задачи
    public List<Company> GetCompaniesFromCountry(string country)
    {
        return companies.Where(c => c.Country == country).ToList();
    }

    public List<Trip> GetTripsFromCityToCity(string departureCity, string arrivalCity)
    {
        return trips.Where(t => t.DepartureCity == departureCity && t.ArrivalCity == arrivalCity).ToList();
    }

    public List<Passenger> GetPassengersWithAgeAbove(int age)
    {
        return passengers.Where(p => p.Age > age).ToList();
    }

    // Нормальные задачи
    public Trip GetTripWithMaximumTicketPrice()
    {
        return trips.OrderByDescending(t => passengerTrips.Where(pt => pt.TripId == t.Id).Max(pt => pt.TicketPrice)).First();
    }

    public Passenger GetPassengerWithMostExpensiveTicket()
    {
        return passengers.Join(passengerTrips, p => p.Id, pt => pt.PassengerId, (p, pt) => new { Passenger = p, TicketPrice = pt.TicketPrice })
                         .OrderByDescending(x => x.TicketPrice).Select(x => x.Passenger).First();
    }

    public List<Company> GetCompaniesWithTripsAfterDate(DateTime date)
    {
        return companies.Where(c => trips.Any(t => t.CompanyId == c.Id && t.DepartureTime > date)).ToList();
    }

    // Сложные задачи
    public decimal GetAverageTicketPriceForCompany(int companyId)
    {
        return passengerTrips.Where(pt => trips.Any(t => t.Id == pt.TripId && t.CompanyId == companyId)).Average(pt => pt.TicketPrice);
    }

    public Passenger GetPassengerWithMostTrips()
    {
        return passengers.Join(passengerTrips, p => p.Id, pt => pt.PassengerId, (p, pt) => new { Passenger = p, TripCount = passengerTrips.Count(x => x.PassengerId == p.Id) })
                         .OrderByDescending(x => x.TripCount).Select(x => x.Passenger).First();
    }

    public List<Passenger> GetPassengersOnTrip(int tripId)
    {
        return passengers.Join(passengerTrips, p => p.Id, pt => pt.PassengerId, (p, pt) => new { Passenger = p, TripId = pt.TripId })
                         .Where(x => x.TripId == tripId).Select(x => x.Passenger).ToList();
    }
}

// Оставшиеся классы без изменений
