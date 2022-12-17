namespace Mg3.Utility.StringUtility;

public static class StringUtility
{
	/// <summary>
	/// Implements <c>string.IsNullOrEmpty(...)</c> as extension method.
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>
	public static bool IsNullOrEmpty(this string s) => string.IsNullOrEmpty(s);

	/// <summary>
	/// Implements <c>string.IsNullOrWhitespace(...)</c> as extension method.
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>
	public static bool IsNullOrWhitespace(this string s) => string.IsNullOrWhiteSpace(s);

	/// <summary>
	/// Checks to see if string contains whitespace
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>
	public static bool ContainsWhitespace(this string s) => s.Any(char.IsWhiteSpace);
}

