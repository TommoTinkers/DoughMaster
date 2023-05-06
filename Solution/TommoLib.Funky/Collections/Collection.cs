using System.Collections.Immutable;

namespace TommoLib.Funky.Collections;

public sealed class Collection<T> : IEquatable<Collection<T>> where T: IEquatable<T>
{
	private readonly ImmutableArray<T> items;
	
	public Collection(IEnumerable<T> items)
	{
		this.items = items.ToImmutableArray();
	}

	public bool Equals(Collection<T>? other)
	{
		return other switch
		{
			not null => items.SequenceEqual(other.items),
			_ => false
		};
	}

	public override bool Equals(object? obj)
	{
		return ReferenceEquals(this, obj) || obj is Collection<T> other && Equals(other);
	}

	public override int GetHashCode()
	{
		return items.Aggregate(0, (accumulator, next) => accumulator + next.GetHashCode());
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