namespace TodoIpi.ConfigureServices.Api;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class ApiCommandAttribute(string route, string name, string httpMethod) : Attribute
{
	public string Route { get; } = route;
	public string Name { get; } = name;
	public string HttpMethod { get; } = httpMethod;
}
