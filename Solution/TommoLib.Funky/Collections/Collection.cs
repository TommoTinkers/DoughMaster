using System.Collections.Immutable;
using TommoLib.Funky.Exceptions;

namespace TommoLib.Funky.Collections;

public sealed class Collection<T> : IEquatable<Collection<T>> where T: IEquatable<T>
{
	public readonly ImmutableArray<T> Items;
	
	public Collection(IEnumerable<T> items)
	{
		Items = items.ToImmutableArray();
	}

	public T this[uint i] => i switch
	{
		_ when i < Items.Length => Items[(int)i],
		_ => throw new InvalidCollectionIndexException()
	};
	
	public bool Equals(Collection<T>? other)
	{
		return other switch
		{
			not null => Items.SequenceEqual(other.Items),
			_ => false
		};
	}

	public override bool Equals(object? obj)
	{
		return ReferenceEquals(this, obj) || obj is Collection<T> other && Equals(other);
	}

	public override int GetHashCode()
	{
		return Items.Aggregate(0, (accumulator, next) => accumulator + next.GetHashCode());
	}

	public static bool operator ==(Collection<T>? left, Collection<T>? right)
	{
		return Equals(left, right);
	}

	public static bool operator !=(Collection<T>? left, Collection<T>? right)
	{
		return !Equals(left, right);
	}
}