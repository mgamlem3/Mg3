using System.Collections.ObjectModel;

namespace Mg3.Utility.EnumerableUtility;

public static class EnumerableUtility
{
	/// <summary>
	/// Checks if IEnumerable is null or contains 0 values
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="enumerable"></param>
	/// <returns>true if collection is null or has 0 values; false otherwise</returns>
	public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable) => enumerable is null || !enumerable.Any();

	/// <summary>
	/// Returns an empty <c>Collection<T></c> if enumerable is null
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="enumerable"></param>
	/// <returns></returns>
	public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> enumerable) => enumerable is null ? new Collection<T>() : enumerable;
}
