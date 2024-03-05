namespace d02_ex01.Tasks;

public class TaskState
{ 
	public enum State
	{
		New,
		Completed,
		Irrelevant
	}	
	
	public State CurrentState { get; private set; } = State.New;

	public void Resolve()
	{
		if (CurrentState == State.Irrelevant)
			throw new InvalidOperationException("Task is already irrelevant");
		CurrentState = State.Completed;
	}
	
	public void Close()
	{
		if (CurrentState == State.Completed)
			throw new InvalidOperationException("Task is already resolved");
		if (CurrentState == State.Irrelevant)
			throw new InvalidOperationException("Task is already irrelevant");
		CurrentState = State.Irrelevant;
	}
	
	public void Reopen()
	{
		CurrentState = State.New;
	}
	
	public override string ToString()
	{
		return CurrentState.ToString();
	}
}