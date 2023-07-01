using Mg3.Utility.EnumerableUtility;
using System.Collections.ObjectModel;

namespace Mg3.Utility.Tests.EnumerableUtility;

public sealed class EnumerableUtilityTests
{
	[Theory]
	[MemberData(nameof(IsNullOrEmptyTestLists))]
	public void IsNullOrEmpty<T>(IEnumerable<T> enumerable, bool expectedResult) => Assert.Equal(expectedResult, enumerable.IsNullOrEmpty());

	[Theory]
	[MemberData(nameof(EmptyIfNullTestLists))]
	public void EmptyIfNull<T>(IEnumerable<T> enumerable, IEnumerable<T> expectedResult) => Assert.Equal(expectedResult, enumerable.EmptyIfNull());

	[Fact]
	public void ListAsReadOnlyList()
	{
		// AsIReadOnlyList should not rewrap a List
		var list = new List<int> { 1, 2 };
		Assert.Equivalent(list, list.AsIReadOnlyList());
	}

	[Fact]
	public void ReadOnlyCollectionAsReadOnlyList()
	{
		// AsReadOnlyList should not rewrap a ReadOnlyCollection
		var list = new List<int> { 1, 2 };
		IEnumerable<int> readOnlyList = new ReadOnlyCollection<int>(list);
		Assert.Equivalent(readOnlyList, readOnlyList.AsIReadOnlyList());
	}

	[Fact]
	public void MutateListAsReadOnlyList()
	{
		// AsIReadOnlyList does not guarantee that the collection can't be mutated by someone else
		var list = new List<int> { 1, 2 };
		var readOnlyList = list.AsIReadOnlyList();
		list.Add(3);
		Assert.Equivalent(3, readOnlyList.Count);
	}

	[Fact]
	public void DictionaryAsReadOnlyList()
	{
		// AsIReadOnlyList must duplicate a non-IList
		var dictionary = new Dictionary<int, int> { { 2, 4 } };
		var readOnlyList = dictionary.AsIReadOnlyList();
		dictionary.Add(3, 9);
		Assert.Equivalent(1, readOnlyList.Count);
		Assert.Equivalent(new KeyValuePair<int, int>(2, 4), readOnlyList[0]);
	}

	[Theory]
	[MemberData(nameof(AsReadOnlyCollectionLists))]
	public void AsReadOnlyCollection<T>(IEnumerable<T> enumerable)
	{
		var transformedEnumerable = enumerable.AsReadOnlyCollection();
		Assert.Equal(typeof(ReadOnlyCollection<T>), transformedEnumerable.GetType());
	}

	[Fact]
	public void WhereNotNullDoesNotModifyNonNullable()
	{
		var list = new List<Number>() { GetRandomNumber(), GetRandomNumber(), GetRandomNumber() };
		Assert.Equivalent(list, list.WhereNotNull());
	}

	[Fact]
	public void WhereNotNullRemovesNull()
	{
		var list = new List<Number?>() { null, GetRandomNumber(), GetRandomNumber() };
		Assert.True(list.WhereNotNull().All(x => x is not null));
	}

	[Fact]
	public void LazyWhereNotNullDoesNotModifyNonNullable()
	{
		var list = new List<Number>() { GetRandomNumber(), GetRandomNumber(), GetRandomNumber() };
		Assert.Equivalent(list, list.LazyWhereNotNull());
	}

	[Fact]
	public void LazyWhereNotNullRemovesNull()
	{
		var list = new List<Number?>() { null, GetRandomNumber(), GetRandomNumber() };
		Assert.True(list.LazyWhereNotNull().All(x => x is not null));
	}

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

	public static List<object[]> AsReadOnlyCollectionLists => new()
	{
		new object[] { new List<int>() { 1, 2, 3 } },
		new object[] { new List<int>() { } },
		new object[] { new ReadOnlyCollection<int>(new List<int>() { 1, 2, 3 }) },
		new object[] { new ReadOnlyCollection<int>(new List<int>() { }) },
	};

	public class Number
	{
		public int Value { get; set; }
	}

	public Number GetRandomNumber() => new()
	{
		Value = m_rand.Next(),
	};

	private readonly Random m_rand = new();
}
