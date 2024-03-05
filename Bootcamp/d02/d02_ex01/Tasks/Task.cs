using System.Text;

namespace d02_ex01.Tasks;

public class Task
{
	public string Title { get; }
	private string Summary { get; }
	private DateTime? DueDate { get; }
	private TaskType Type { get; }
	private TaskPriority Priority { get; }
	
	private readonly TaskState _state;
	
	public Task(string title, string summary, DateTime? dueDate, TaskType type, TaskPriority priority)
	{
		Title = title;
		Summary = summary;
		DueDate = dueDate;
		Type = type;
		Priority = priority;
		_state = new TaskState();
	}

	public override string ToString()
	{
		StringBuilder sb = new();
		
		sb.AppendLine(Title);
		sb.AppendLine($"[{Type}] [{_state.CurrentState}]");
		string date = DueDate.HasValue ? DueDate.Value.ToString("dd/MM/yyyy") : string.Empty;
		sb.AppendLine($"Priority: {Priority}, Due till {date}");
		sb.AppendLine(Summary);
		
		return sb.ToString();
	}

	public void Done()
	{
		_state.Resolve();
	}

	public void Close()
	{
		_state.Close();
	}
}