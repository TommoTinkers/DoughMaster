using System.Collections.Immutable;
using FluentAssertions;
using NUnit.Framework;
using TommoLib.Funky.Collections;

namespace TommoLib.Funky.Tests.Collections;

[TestFixture]
public class CollectionAddTests
{
	[Test]
	public void Add_To_Empty_Collection_Yields_A_Collection_With_A_Size_Of_One()
	{
		var collection = new Collection<int>(Enumerable.Empty<int>());

		var newCollection = collection.Add(1);

		newCollection.Length().Should().Be(1);
	}

	[Test]
	public void Add_To_Empty_Collection_Yields_A_Collection_With_The_First_Element_The_Same_As_The_One_That_Was_Added([Random(int.MinValue, int.MaxValue, 100)] int value)
	{
		var collection = new Collection<int>(Enumerable.Empty<int>());
		var newCollection = collection.Add(value);

		newCollection[0].Should().Be(value);
	}

	[Test]
	public void Add_N_Items_To_Collection_Of_Y_Size_Yields_A_Collection_With_Size_N_Plus_Y(
		[Random(1u, 2000u, 10)] uint nSize, [Random(1u, 2000u, 10)] uint ySize)
	{
		var n = Enumerable.Range(0, (int)nSize).Select(_ => Random.Shared.Next()).ToImmutableArray();
		var y = Enumerable.Range(0, (int)ySize).Select(_ => Random.Shared.Next()).ToImmutableArray();

		new Collection<int>(n).Add(y).Length().Should().Be(nSize + ySize);
	}

	[Test]
	public void Last_Y_Items_Of_Collection_Are_The_Same_As_The_Ones_In_Y_After_Adding(
		[Random(1u, 2000u, 10)] uint nSize, [Random(1u, 2000u, 10)] uint ySize)
	{
		var n = Enumerable.Range(0, (int)nSize).Select(_ => Random.Shared.Next()).ToImmutableArray();
		var y = Enumerable.Range(0, (int)ySize).Select(_ => Random.Shared.Next()).ToImmutableArray();

		var collection = new Collection<int>(n).Add(y);

		var actualY = collection.Items.Skip(n.Length).ToImmutableArray();

		actualY.Should().BeEquivalentTo(y);
	}

	[Test]
	public void First_N_Items_Of_Collection_Are_The_Same_As_The_Ones_In_N_After_Adding([Random(1u, 2000u, 10)] uint nSize, [Random(1u, 2000u, 10)] uint ySize)
	{
		var n = Enumerable.Range(0, (int)nSize).Select(_ => Random.Shared.Next()).ToImmutableArray();
		var y = Enumerable.Range(0, (int)ySize).Select(_ => Random.Shared.Next()).ToImmutableArray();

		var collection = new Collection<int>(n).Add(y);

		var actualN = collection.Items.Take(n.Length).ToImmutableArray();

		actualN.Should().BeEquivalentTo(n);
	}
}