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

	public List<Company> GetCompaniesFromCountry(string country)
	{
		throw new NotImplementedException();
	}

	public List<Trip> GetTripsFromCityToCity(string departureCity, string arrivalCity)
	{
		throw new NotImplementedException();
	}

	public List<Passenger> GetPassengersWithAgeAbove(int age)
	{
		throw new NotImplementedException();
	}

	public Trip GetTripWithMaximumTicketPrice()
	{
		throw new NotImplementedException();
	}

	public Passenger GetPassengerWithMostExpensiveTicket()
	{
		throw new NotImplementedException();
	}

	public List<Company> GetCompaniesWithTripsAfterDate(DateTime date)
	{
		throw new NotImplementedException();
	}

	public decimal GetAverageTicketPriceForCompany(int companyId)
	{
		throw new NotImplementedException();
	}

	public Passenger GetPassengerWithMostTrips()
	{
		throw new NotImplementedException();
	}

	public List<Passenger> GetPassengersOnTrip(int tripId)
	{
		throw new NotImplementedException();
	}

	public List<Passenger> GetPassengersWithTicketsForCompany(string i)
	{
		throw new NotImplementedException();
	}

	public (string, List<PassengerTrip>) GetPassengerCompanyInfo(int id)
	{
		throw new NotImplementedException();
	}
}