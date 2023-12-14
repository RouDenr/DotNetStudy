using System.Net.Http;

namespace TaskApp.ViewModels.Api;

public interface IHttpClientFactory
{
	HttpClient CreateHttpClient(string url);
}