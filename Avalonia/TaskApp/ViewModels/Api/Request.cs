using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace TaskApp.ViewModels.Api;

public static class Request
{
	private const string Url = "https://localhost:7063/api/Task";

	[Serializable]
	public struct ResponseTaskItem
	{
		public int id;
		public string title;
		[JsonPropertyName("description")]
		public string description;
		[JsonPropertyName("isDone")]
		public bool isDone;
	}
	
	public static async Task<List<TaskItem>?> GetTasks()
	{
		using var handler = new HttpClientHandler();
		handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
		
		using var client = new HttpClient(handler);
		
		
		var response = await client.GetAsync(Url);

		if (!response.IsSuccessStatusCode) return null;
		
		var data = await response.Content.ReadAsStringAsync();
		Console.WriteLine(data);
		List<TaskItem>? responseTaskItems = JsonSerializer.Deserialize<List<TaskItem>>(data);
		
		if (responseTaskItems == null) return null;
		
		return responseTaskItems;
	}
}