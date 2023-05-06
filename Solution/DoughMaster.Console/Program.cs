using System.Collections.Immutable;

Console.WriteLine("Dough Master");


Console.ReadKey(true);

sealed record Person(string Name);
sealed record People(ImmutableArray<Person> Persons);