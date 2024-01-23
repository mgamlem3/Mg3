using Mg3.Utility.StringUtility;
using System.Collections.ObjectModel;

namespace Mg3.Utility.Tests.StringUtility;
public sealed class StringUtilityTests
{
#pragma warning disable xUnit1012 // Allow passing null for testing purposes
	[Theory]
	[InlineData("")]
	[InlineData(null)]
	[InlineData("test")]
	public void IsNullOrEmpty(string s) => Assert.Equal(string.IsNullOrEmpty(s), s.IsNullOrEmpty());

	[Theory]
	[InlineData("")]
	[InlineData(null)]
	[InlineData("test")]
	[InlineData(" ")]
	[InlineData("	")]
	public void IsNullOrWhiteSpace(string s) => Assert.Equal(string.IsNullOrWhiteSpace(s), s.IsNullOrWhitespace());

	[Theory]
	[InlineData("")]
	[InlineData(null)]
	[InlineData("test")]
	[InlineData("test ")]
	[InlineData(" ")]
	[InlineData("	")]
	public void ContainsWhitespace(string s) => Assert.Equal(s?.Any(char.IsWhiteSpace), s?.ContainsWhitespace());

	[Theory]
	[MemberData(nameof(CharacterListTestData))]
	public void ContainsCharacterFromCollection(string s, ReadOnlyCollection<char> collection, bool ignoreCase = false)
	{
		if (ignoreCase)
			Assert.Equal(s.Any(x => collection.Any(c => char.ToLowerInvariant(c) == char.ToLowerInvariant(x))), s.ContainsCharacterFromCollection(collection, true));
		else
			Assert.Equal(s.Any(x => collection.Any(c => c == x)), s.ContainsCharacterFromCollection(collection));
	}

	[Theory]
	[MemberData(nameof(CharacterListTestData))]
	public void ContainsOnlyCharactersFromCollection(string s, ReadOnlyCollection<char> collection, bool ignoreCase = false)
	{
		if (ignoreCase)
			Assert.Equal(s.All(x => collection.Any(c => char.ToLowerInvariant(c) == char.ToLowerInvariant(x))), s.ContainsOnlyCharactersFromCollection(collection, true));
		else
			Assert.Equal(s.All(x => collection.Any(c => c == x)), s.ContainsOnlyCharactersFromCollection(collection));
	}

	[Theory]
	[MemberData(nameof(CharacterCaseTestData))]
	public void ContainsUpperCase(string s) => Assert.Equal(s.Any(char.IsUpper), s.ContainsUpperCase());

	[Theory]
	[MemberData(nameof(CharacterCaseTestData))]
	public void ContainsLowerCase(string s) => Assert.Equal(s.Any(char.IsLower), s.ContainsLowerCase());

	[Theory]
	[MemberData(nameof(CharacterCaseTestData))]
	public void ContainsMixedCase(string s) => Assert.Equal(s.ContainsUpperCase() && s.ContainsLowerCase(), s.ContainsMixedCase());

	[Theory]
	[InlineData("hello", "hello")]
	[InlineData("helloWorld", "hello_world")]
	[InlineData("HelloWorld", "hello_world")]
	[InlineData("hello_world", "hello_world")]
	[InlineData("hello__world", "hello_world")]
	[InlineData("hello_world_", "hello_world")]
	[InlineData("_hello_world", "hello_world")]
	[InlineData("_hello_world_", "hello_world")]
	[InlineData("_hello__world", "hello_world")]
	[InlineData("hello  world", "hello_world")]
	[InlineData("hello world", "hello_world")]
	[InlineData("hello_ world", "hello_world")]
	[InlineData("hello _world", "hello_world")]
	[InlineData("hello World", "hello_world")]
	[InlineData("", "")]
	public void ToSnakeCase(string s, string expected) => Assert.Equal(expected, s.ToSnakeCase());

	public static IEnumerable<object[]> CharacterListTestData =>
	new List<object[]>
	{
		new object[] { "", MatchingTestCharacterCollection },
		new object[] { "test", MatchingTestCharacterCollection },
		new object[] { "test", NotMatchingTestCharacterCollection },
		new object[] { "Test", MatchingTestCharacterCollection },
		new object[] { "Test", NotMatchingTestCharacterCollection },
		new object[] { "Test", MatchingTestCharacterCollection, true },
		new object[] { "Test", NotMatchingTestCharacterCollection, true },
		new object[] { "tesT", MatchingTestCharacterCollection },
		new object[] { "tesT", NotMatchingTestCharacterCollection },
		new object[] { "tesT", MatchingTestCharacterCollection, true },
		new object[] { "tesT", NotMatchingTestCharacterCollection, true },
		new object[] { "TesT", MatchingTestCharacterCollection },
		new object[] { "TesT", NotMatchingTestCharacterCollection },
		new object[] { "TesT", MatchingTestCharacterCollection, true },
		new object[] { "TesT", NotMatchingTestCharacterCollection, true }
	};

	public static IEnumerable<object[]> CharacterCaseTestData =>
	new List<object[]>
	{
		new object[] { "" },
		new object[] { "test" },
		new object[] { "Test" },
		new object[] { "tesT" },
		new object[] { "TesT" }
	};

	private static ReadOnlyCollection<char> MatchingTestCharacterCollection =>
	new List<char>
	{
		't',
		'e',
		's',
		't'
	}.AsReadOnly();

	private static ReadOnlyCollection<char> NotMatchingTestCharacterCollection =>
	new List<char>
	{
		'f',
		'o',
		'o',
	}.AsReadOnly();
}
