using Mg3.Utility.StringUtility;

namespace Mg3.Utility.Tests.StringUtility;
public sealed class StringUtilityTests
{
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
}
