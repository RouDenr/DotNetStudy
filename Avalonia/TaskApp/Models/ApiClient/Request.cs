using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TaskApp.Models.ApiClient;

public static class Request
{
	private const string Url = "http://localhost:5032/";
	private static readonly IHttpClientFactory ClientFactory = new CustomHttpClientFactory();
	
	// GET: api/Task
	public static async Task<ObservableCollection<TaskItem>?> GetTasks()
	{
		using var client = ClientFactory.CreateHttpClient(Url);
		
		var response = await client.GetAsync("api/Task");

		if (!response.IsSuccessStatusCode) return null;
		
		var data = await response.Content.ReadAsStringAsync();
		Console.WriteLine(data);
		ObservableCollection<TaskItem>? responseTaskItems = JsonSerializer.Deserialize<ObservableCollection<TaskItem>>(data);
		
		if (responseTaskItems == null) return null;
		
		return responseTaskItems;
	}
	
	// GET: api/Task/{id}
	public static async Task<TaskItem?> GetTask(int id)
	{
		using var client = ClientFactory.CreateHttpClient(Url);
		
		var response = await client.GetAsync($"api/Task/{id}");

		if (!response.IsSuccessStatusCode) return null;
		
		var data = await response.Content.ReadAsStringAsync();
		Console.WriteLine(data);
		TaskItem? responseTaskItem = JsonSerializer.Deserialize<TaskItem>(data);
		
		if (responseTaskItem == null) return null;
		
		return responseTaskItem;
	}
	
	// POST: api/Task
	public static async Task<TaskItem?> PostTask(TaskItem taskItem)
	{
		using var client = ClientFactory.CreateHttpClient(Url);
		
		var json = JsonSerializer.Serialize(taskItem);
		Console.WriteLine(json);
		
		var response = await client.PostAsync("api/Task", new StringContent(JsonSerializer.Serialize(taskItem),
			Encoding.UTF8,
			"application/json"));

		if (!response.IsSuccessStatusCode)
		{
			Console.WriteLine($"Error: {response.StatusCode}");
			return null;
		}
		
		var data = await response.Content.ReadAsStringAsync();
		Console.WriteLine(data);
		TaskItem? responseTaskItem = JsonSerializer.Deserialize<TaskItem>(data);
		
		if (responseTaskItem == null) return null;
		
		return responseTaskItem;
	}
	
	// PUT: api/Task/{id}
	public static async Task<TaskItem?> PutTask(int id, TaskItem taskItem)
	{
		using var client = ClientFactory.CreateHttpClient(Url);
		
		var response = await client.PutAsync($"api/Task/{id}", new StringContent(JsonSerializer.Serialize(taskItem)));

		if (!response.IsSuccessStatusCode) return null;
		
		var data = await response.Content.ReadAsStringAsync();
		Console.WriteLine(data);
		TaskItem? responseTaskItem = JsonSerializer.Deserialize<TaskItem>(data);
		
		if (responseTaskItem == null) return null;
		
		return responseTaskItem;
	}
	
	// DELETE: api/Task/{id}
	public static async Task<bool> DeleteTask(int id)
	{
		using var client = ClientFactory.CreateHttpClient(Url);
		
		var response = await client.DeleteAsync($"api/Task/{id}");

		return response.IsSuccessStatusCode;
	}
}