using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Mg3.Json.JsonUtility;

public static class JsonUtility
{
	public static readonly DefaultContractResolver DefaultContractResolver = new()
	{
		NamingStrategy = new CamelCaseNamingStrategy(),
	};

	public static readonly JsonSerializerSettings JsonSerializerSettings = new()
	{
		ContractResolver = DefaultContractResolver,
		NullValueHandling = NullValueHandling.Ignore
	};
}
