using System.Net.Sockets;

namespace WormsFinder.Utils;

public class RollingBuffer
{
	private readonly Queue<byte> _queue;
	private readonly int _capacity;

	public RollingBuffer(int capacity)
	{
		_capacity = capacity;
		_queue = new Queue<byte>(capacity);
	}

	public void  Add(IEnumerable<byte> items)
	{
		foreach (var item in items)
		{
			if (_queue.Count == _capacity)
			{
				_queue.Dequeue();
			}

			_queue.Enqueue(item);
		}
	}

	
	public byte[] ToArray()
	{
		return _queue.ToArray();
	}
}