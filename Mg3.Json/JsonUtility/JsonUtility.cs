using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Mg3.Json.JsonUtility;

public static class JsonUtility
{
	public static readonly DefaultContractResolver defaultContractResolver = new()
	{
		NamingStrategy = new SnakeCaseNamingStrategy()
	};

	public static readonly JsonSerializerSettings jsonSerializerSettings = new()
	{
		ContractResolver = defaultContractResolver,
		NullValueHandling = NullValueHandling.Ignore
	};
}
