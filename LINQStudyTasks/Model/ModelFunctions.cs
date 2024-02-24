namespace LINQStudyTasks.Model;

public class ModelFunctions(
	List<Company> companies,
	List<Trip> trips,
	List<PassengerTrip> passengerTrips,
	List<Passenger> passengers)
{
	private List<Company> companies = companies;
	private List<Trip> trips = trips;
	private List<PassengerTrip> passengerTrips = passengerTrips;
	private List<Passenger> passengers = passengers;

	
	/// <summary>
	/// Возвращает список компаний из указанной страны
	/// </summary>
	/// <param name="country"></param>
	/// <returns></returns>
	public IEnumerable<Company> GetCompaniesFromCountry(string country)
	{
		return companies.Where(company => company.Country == country).ToList();
	}

	
	/// <summary>
	/// Возвращает список пассажиров, которые путешествовали на самолетах указанной компании
	/// </summary>
	/// <param name="departureCity"></param>
	/// <param name="arrivalCity"></param>
	/// <returns></returns>
	public IEnumerable<Trip> GetTripsFromCityToCity(string departureCity, string arrivalCity)
	{
		return trips.Where(trip => trip.ArrivalCity == arrivalCity && trip.DepartureCity == departureCity)
			.ToList();
	}

	/// <summary>
	/// Возвращает список пассажиров, которые путешествовали на самолетах указанной компании
	/// </summary>
	/// <param name="age"></param>
	/// <returns></returns>
	public List<Passenger> GetPassengersWithAgeAbove(int age)
	{
		return passengers.Where(passenger => passenger.Age > age).ToList();
	}

	/// <summary>
	/// Возвращает поезку с максимальной ценой билета
	/// </summary>
	/// <returns></returns>
	public Trip GetTripWithMaximumTicketPrice()
	{
		return trips.First(trip => trip.Id == passengerTrips
							.OrderByDescending(passengerTrip => passengerTrip.TicketPrice).First().TripId);
	}

	/// <summary>
	/// Возвращает пассажира с самым дорогим билетом
	/// </summary>
	/// <returns></returns>
	public Passenger GetPassengerWithMostExpensiveTicket()
	{
		var maxTicketPrice = passengerTrips.Max(passengerTrip => passengerTrip.TicketPrice);
		var passengerId = passengerTrips.First(passengerTrip => passengerTrip.TicketPrice == maxTicketPrice).PassengerId;
		return passengers.First(passenger => passenger.Id == passengerId);
	}

	
	/// <summary>
	/// возвращает список компаний, у которых есть рейсы после указанной даты
	/// </summary>
	/// <param name="date"></param>
	/// <returns></returns>
	public List<Company> GetCompaniesWithTripsAfterDate(DateTime date)
	{
		return companies.Where(
			company => trips.Any(trip => trip.CompanyId == company.Id && trip.DepartureTime > date)
			).ToList(); 
	}

	
	/// <summary>
	/// Возвращает среднюю цену билета для указанной компании
	/// </summary>
	/// <param name="companyId"></param>
	/// <returns></returns>
	/// <exception cref="NotImplementedException"></exception>
	public decimal GetAverageTicketPriceForCompany(int companyId)
	{
		List<PassengerTrip> passengerTripsForCompany = 
			passengerTrips.Where(
				passengerTrip => trips.Where(
					trip => trip.CompanyId == companyId
					).Any(trip => trip.Id == passengerTrip.TripId)
			).ToList();
		return passengerTripsForCompany.Average(passengerTrip => passengerTrip.TicketPrice);
	}

	public Passenger GetPassengerWithMostTrips()
	{
		throw new NotImplementedException();
	}

	public List<Passenger> GetPassengersOnTrip(int tripId)
	{
		throw new NotImplementedException();
	}

	
	/// <summary>
	/// все пассажиры, у которых есть билеты на рейсы указанной компании
	/// </summary>
	/// <param name="i"></param>
	/// <returns></returns>
	public List<Passenger> GetPassengersWithTicketsForCompany(string i)
	{
		return passengers.Where(
			passenger => 
				passengerTrips.Where(
						passengerTrip => trips.Where(
							trip => trip.CompanyId == companies.First(company => company.Name == i).Id
						).Any(trip => trip.Id == passengerTrip.TripId)
					).Any(passengerTrip => passengerTrip.PassengerId == passenger.Id)
			).ToList();
	}

	public (string, List<PassengerTrip>) GetPassengerCompanyInfo(int id)
	{
		throw new NotImplementedException();
	}
}