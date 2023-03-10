using Solution1.Domain.Common;

namespace Solution1.Domain.CustomerAggregate.ValueObjects;

public sealed class Location : ValueObject
{
    public string Street { get; private set; }
    public int StreetNumber { get; private set; }

    private Location(string street, int streetNumber)
    {
        Street = street;
        StreetNumber = streetNumber;
    }

    public static Location Create(string street, int streetNumber)
    {
        return new Location(street, streetNumber);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return StreetNumber;
    }
}
