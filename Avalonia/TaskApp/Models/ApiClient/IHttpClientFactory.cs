using System.Net.Http;

namespace TaskApp.Models.ApiClient;

public interface IHttpClientFactory
{
	HttpClient CreateHttpClient(string url);
}