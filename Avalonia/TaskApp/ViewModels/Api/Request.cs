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
	private const string Url = "https://localhost:7063/";
	private static readonly IHttpClientFactory ClientFactory = new CustomHttpClientFactory();
	
	public static async Task<List<TaskItem>?> GetTasks()
	{
		using var client = ClientFactory.CreateHttpClient(Url);
		
		var response = await client.GetAsync("api/Task");

		if (!response.IsSuccessStatusCode) return null;
		
		var data = await response.Content.ReadAsStringAsync();
		Console.WriteLine(data);
		List<TaskItem>? responseTaskItems = JsonSerializer.Deserialize<List<TaskItem>>(data);
		
		if (responseTaskItems == null) return null;
		
		return responseTaskItems;
	}
}