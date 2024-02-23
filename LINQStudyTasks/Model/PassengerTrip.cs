namespace LINQStudyTasks.Model;

public class PassengerTrip
{
	public int Id { get; set; }
	public int TripId { get; set; }
	public int PassengerId { get; set; }
	public string SeatNumber { get; set; }
	public decimal TicketPrice { get; set; }
	public string TicketClass { get; set; }
	public DateTime BoardingTime { get; set; }
	// Другие поля по вашему выбору
}