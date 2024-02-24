namespace LINQStudyTasks.Model;

public class Trip
{
	public int Id { get; set; }
	public int CompanyId { get; set; }
	public string PlaneModel { get; set; }
	public string DepartureCity { get; set; }
	public string ArrivalCity { get; set; }
	public DateTime DepartureTime { get; set; }
	public DateTime ArrivalTime { get; set; }
	public string TicketClass { get; set; }

	public int PassengerCapacity { get; set; }
	// Другие поля по вашему выбору
}