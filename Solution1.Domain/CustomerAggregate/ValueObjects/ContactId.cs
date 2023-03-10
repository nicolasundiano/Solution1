using Solution1.Domain.Common;

namespace Solution1.Domain.CustomerAggregate.ValueObjects;

public sealed class ContactId : ValueObject
{
    public Guid Value { get; }

    private ContactId(Guid value)
    {
        Value = value;
    }

    public static ContactId Create(Guid value)
    {
        return new ContactId(value);
    }

    public static ContactId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
