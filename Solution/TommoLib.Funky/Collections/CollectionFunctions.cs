namespace TommoLib.Funky.Collections;

public static class CollectionFunctions
{
	public static Collection<T> Add<T>(this Collection<T> collection, T item) where T : IEquatable<T> => new(collection.Items.Add(item));

	public static Collection<T> Add<T>(this Collection<T> collection, IEnumerable<T> additional) where T : IEquatable<T> => new(collection.Items.Concat(additional));
	
	public static uint Length<T>(this Collection<T> collection) where T : IEquatable<T> => (uint)collection.Items.Length;
}