using FluentAssertions;
using NUnit.Framework;
using TommoLib.Funky.Collections;
using TommoLib.Funky.Exceptions;

namespace TommoLib.Funky.Tests.Collections;

[TestFixture]
public class CollectionTests
{
	[Test]
	public void Empty_Collection_Is_Equal_To_A_Collection_Created_With_New()
	{
		var left = new Collection<int>(Enumerable.Empty<int>());
		var right = Collection<int>.Empty;

		left.Should().Be(right);
	}
	
	[Test]
	public void Two_Collections_With_The_Same_Element_Have_Equality([Random(1u, 100u, 10)] uint numberOfElements)
	{
		var elements = Enumerable.Range(0, (int)numberOfElements);
		var elements2 = Enumerable.Range(0, (int)numberOfElements);
		var collection = new Collection<int>(elements);
		var collection2 = new Collection<int>(elements2);

		collection.Should().Be(collection2);
	}

	[Test]
	public void Two_Collections_With_Differing_Elements_Do_Not_Have_Equality([Random(1u, 100u, 10)] uint numberOfElements)
	{
		var elements = Enumerable.Range(0, (int)numberOfElements);
		var elements2 = Enumerable.Range((int)numberOfElements+1, (int)numberOfElements);
		var collection = new Collection<int>(elements);
		var collection2 = new Collection<int>(elements2);

		collection.Should().NotBe(collection2);
	}

	[Test]
	public void Indexer_Equal_To_Length_Or_Greater_Throws_An_Invalid_Collection_Index_Exception([Random(1u, 10000u, 10)] uint numberOfElements)
	{
		var elements = Enumerable.Range(0, (int)numberOfElements).Select(_ => Random.Shared.Next());
		var collection = new Collection<int>(elements);

		var TryAccessInvalidIndex = () =>
		{
			var invalidIndex = (uint)Random.Shared.Next((int)collection.Length(), int.MaxValue);
			_ = collection[invalidIndex];
		};

		TryAccessInvalidIndex.Should().ThrowExactly<InvalidCollectionIndexException>();

	}
}