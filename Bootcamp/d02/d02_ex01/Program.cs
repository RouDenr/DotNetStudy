// See https://aka.ms/new-console-template for more information

using d02_ex01.Tasks;
using Task = d02_ex01.Tasks.Task;

const string inputError = "Input error. Check the input data and repeat the request.";
const string taskNotFound = "Input error. The task with this title was not found";
const string taskListEmpty = "The task list is still empty.";


List<Task> tasks = new();
string input = string.Empty;

while (!input.Equals("quit", StringComparison.OrdinalIgnoreCase) &&
       !input.Equals("q", StringComparison.OrdinalIgnoreCase))
{
	Print("Enter a command");
	input = Read();

	try
	{
		switch (input)
		{
			case "add":
				tasks.Add(NewTaskFromConsole());
				break;
			case "list":
				PrintTasks(tasks);
				break;
			case "done":
				DoneTask(tasks);

				break;
			case "wontdo":
				WontDoTask(tasks);

				break;
			case "quit":
				break;
		}
	}
	catch (ArgumentException e)
	{
		Console.WriteLine(e.Message);
	}
	catch (InvalidOperationException e)
	{
		Console.WriteLine(e.Message);
	}
	catch (Exception e)
	{
		Console.WriteLine(e);
		throw;
	}
}

return;


Task NewTaskFromConsole()
{
	Print("Enter a title");
	string title = Read();
	if (string.IsNullOrEmpty(title))
	{
		throw new ArgumentException(inputError);
	}
	Print("Enter a description");
	string summary = Read();
	Print("Enter the deadline");
	DateTime? dueDate = DateTime.TryParse(Read(), out DateTime date) ? date : null;
	Print("Enter the type");
	TaskType type = Enum.TryParse(Read(), out TaskType t) ? t 
		: throw new ArgumentException(inputError);
	Print("Assign the priority");
	TaskPriority priority = Enum.TryParse(Read(), out TaskPriority p) ? p : TaskPriority.Normal;
	
	return new Task(title, summary, dueDate, type, priority);
}


void PrintTasks(List<Task> list)
{
	if (list.Count == 0)
	{
		throw new ArgumentException(taskListEmpty);
	}
	
	foreach (Task task in list)
	{
		Console.WriteLine($"- {task}");
	}
}


void DoneTask(List<Task> list)
{
	Print("Enter a title");
	string title = Read();
	if (string.IsNullOrEmpty(title))
	{
		throw new ArgumentException(inputError);
	}


	Task? task = list.FirstOrDefault(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
	if (task is null)
	{
		throw new ArgumentException(taskNotFound);
	}
	
	task.Done();
	Console.WriteLine($"The task [{title}] is completed!"); 
}


void WontDoTask(List<Task> list)
{
	Print("Enter a title");
	string title = Read();
	if (string.IsNullOrEmpty(title))
	{
		throw new ArgumentException(inputError);
	}

	Task? task = list.FirstOrDefault(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
	if (task is null)
	{
		throw new ArgumentException(taskNotFound);
	}
	
	task.Close();
	Console.WriteLine($"The task [{title}] is no longer relevant!");
}

void Print(string str)
{
	Console.WriteLine($"> {str}");
}

string Read()
{
	Console.Write("> ");
	return Console.ReadLine() ?? string.Empty;
}