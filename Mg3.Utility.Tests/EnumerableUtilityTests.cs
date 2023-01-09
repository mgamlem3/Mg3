using Mg3.Utility.EnumerableUtility;

namespace Mg3.Utility.Tests.EnumerableUtility;

public sealed class EnumerableUtilityTests
{
	[Theory]
	[MemberData(nameof(IsNullOrEmptyTestLists))]
	public void IsNullOrEmpty<T>(IEnumerable<T> enumerable, bool expectedResult) => Assert.Equal(expectedResult, enumerable.IsNullOrEmpty());

	[Theory]
	[MemberData(nameof(EmptyIfNullTestLists))]
	public void EmptyIfNull<T>(IEnumerable<T> enumerable, IEnumerable<T> expectedResult) => Assert.Equal(expectedResult, enumerable.EmptyIfNull());

	public static List<object[]> IsNullOrEmptyTestLists =>
		new()
		{
			new object[] { new List<int>() { 1, 2, 3 }, false },
			new object[] { new List<char> { 'a', 'b', 'c' }, false },
			new object[] { Array.Empty<object>(), true },
			// allow null because test method supports null enumerables
#pragma warning disable CS8625
			new object[] { null, true },
#pragma warning restore CS8625
		};

	public static List<object[]> EmptyIfNullTestLists =>
		new()
		{
			new object[] { new List<int>() { 1, 2, 3 }, new List<int>() { 1, 2, 3 } },
			// allow null because test method supports null enumerables
#pragma warning disable CS8625
			new object[] { null, Array.Empty<object>() }
#pragma warning restore CS8625
		};
}
