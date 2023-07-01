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
	public static bool IsNullOrEmpty<T>(this IEnumerable<T>? enumerable) => enumerable is null || !enumerable.Any();

	/// <summary>
	/// Returns an empty <c>Collection<T></c> if enumerable is null
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="enumerable"></param>
	/// <returns></returns>
	public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T>? enumerable) => enumerable is null ? new Collection<T>() : enumerable;

	/// <summary>
	/// Turns an IEnumerable<T> into a IReadOnlyList<T>
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="enumerable"></param>
	/// <returns></returns>
	public static IReadOnlyList<T> AsIReadOnlyList<T>(this IEnumerable<T> enumerable) =>
			enumerable as IReadOnlyList<T> ??
			(enumerable is IList<T> list ? (IReadOnlyList<T>) list : enumerable.ToList().AsReadOnly());

	/// <summary>
	/// Turns an IEnumerable<T> into a ReadOnlyCollection<T>
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="enumerable"></param>
	/// <returns></returns>
	public static ReadOnlyCollection<T> AsReadOnlyCollection<T>(this IEnumerable<T> enumerable) => new(enumerable.ToList());

	/// <summary>
	/// Returns a non nullable IEnumerable<T> without null values
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="enumerable"></param>
	/// <returns></returns>
	public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> enumerable) where T : class => enumerable.Where(e => e is not null).Select(e => e!);

	/// <summary>
	/// Returns a non nullable IEnumerable<T> without null values. Lazily evaluates enumerable.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="enumerable"></param>
	/// <returns></returns>
	/// <exception cref="ArgumentNullException"></exception>
	public static IEnumerable<T> LazyWhereNotNull<T>(this IEnumerable<T?> enumerable) where T : class
	{
		if (enumerable is null)
			throw new ArgumentNullException(nameof(enumerable));

		foreach (var element in enumerable)
		{
			if (element is not null)
				yield return element;
		}
	}
}
