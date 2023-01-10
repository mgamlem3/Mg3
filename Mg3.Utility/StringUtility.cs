using System.Collections.ObjectModel;

namespace Mg3.Utility.StringUtility;

public static class StringUtility
{
	/// <summary>
	/// Implements <c>string.IsNullOrEmpty(...)</c> as extension method.
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>
	public static bool IsNullOrEmpty(this string? s) => string.IsNullOrEmpty(s);

	/// <summary>
	/// Implements <c>string.IsNullOrWhitespace(...)</c> as extension method.
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>
	public static bool IsNullOrWhitespace(this string? s) => string.IsNullOrWhiteSpace(s);

	/// <summary>
	/// Checks to see if string contains whitespace
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>
	public static bool ContainsWhitespace(this string s) => s.Any(char.IsWhiteSpace);


	/// <summary>
	/// Checks to see if string contains at least one character from supplied collection
	/// </summary>
	/// <param name="s">string to compare</param>
	/// <param name="characters">characters to search for</param>
	/// <param name="ignoreCase">allows case insensitive operation</param>
	/// <returns></returns>
	public static bool ContainsCharacterFromCollection(this string s, ReadOnlyCollection<char> characters, bool ignoreCase = false)
	{
		if (ignoreCase)
			return s.Any(x => characters.Any(c => char.ToLowerInvariant(c) == char.ToLowerInvariant(x)));

		return s.Any(x => characters.Any(c => c == x));
	}

	/// <summary>
	/// Checks to see if string contains only characters from supplied collection
	/// </summary>
	/// <param name="s">string to compare</param>
	/// <param name="characters">characters to search for</param>
	/// <param name="ignoreCase">allows case insensitive operation</param>
	/// <returns></returns>
	public static bool ContainsOnlyCharactersFromCollection(this string s, ReadOnlyCollection<char> characters, bool ignoreCase = false)
	{
		if (ignoreCase)
			return s.All(x => characters.Any(c => char.ToLowerInvariant(c) == char.ToLowerInvariant(x)));

		return s.All(x => characters.Any(c => c == x));
	}

	/// <summary>
	/// Checks to see if string contains upper case characters
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>
	public static bool ContainsUpperCase(this string s) => s.Any(char.IsUpper);

	/// <summary>
	/// Checks to see if string contains lower case characters
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>
	public static bool ContainsLowerCase(this string s) => s.Any(char.IsLower);

	/// <summary>
	/// Checks to see if string contains upper and lower case characters
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>
	public static bool ContainsMixedCase(this string s) => s.ContainsUpperCase() && s.ContainsLowerCase();
}

