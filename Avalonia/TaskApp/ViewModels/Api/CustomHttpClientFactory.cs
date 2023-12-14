using System;
using System.Net.Http;

namespace TaskApp.ViewModels.Api;

public class CustomHttpClientFactory : IHttpClientFactory
{
	public HttpClient CreateHttpClient(string url)
	{
		var handler = new HttpClientHandler();
		handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
		var client = new HttpClient(handler);
		client.BaseAddress = new Uri(url);
		
		// client.DefaultRequestHeaders.Add("Accept", "application/json");
		return client;
	}
}