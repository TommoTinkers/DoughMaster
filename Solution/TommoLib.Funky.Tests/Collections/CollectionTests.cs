using FluentAssertions;
using NUnit.Framework;
using TommoLib.Funky.Collections;

namespace TommoLib.Funky.Tests.Collections;

[TestFixture]
public class CollectionTests
{
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
}