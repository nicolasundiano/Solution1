using Ardalis.GuardClauses;
using Solution1.Domain.Common;
using Solution1.Domain.CustomerAggregate.ValueObjects;

namespace Solution1.Domain.CustomerAggregate.Entities;

public sealed class Contact : Entity<ContactId>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Phone { get; private set; }

    private Contact(ContactId id, string firstName, string lastName, string phone)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
    }

    public static Contact Create(string firstName, string lastName, string phone)
    {
        ValidateNew(firstName, lastName, phone);

        return new Contact(ContactId.CreateUnique(), firstName, lastName, phone);
    }

    internal void Update(string firstName, string lastName, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;

        Validate();
    }

    private static void ValidateNew(string firstName, string lastName, string phone)
    {
        ValidateFirstName(firstName);
        ValidateLastName(lastName);
        ValidatePhone(phone);
    }

    private void Validate()
    {
        ValidateFirstName(FirstName);
        ValidateLastName(LastName);
        ValidatePhone(Phone);
    }

    private static void ValidateFirstName(string firstName)
    {
        Guard.Against.NullOrEmpty(firstName, nameof(firstName));
        Guard.Against.InvalidInput(firstName, nameof(firstName), x => firstName.Length <= 100);
    }

    private static void ValidateLastName(string lastName)
    {
        Guard.Against.NullOrEmpty(lastName, nameof(lastName));
        Guard.Against.InvalidInput(lastName, nameof(lastName), x => lastName.Length <= 100);
    }

    private static void ValidatePhone(string phone)
    {
        Guard.Against.NullOrEmpty(phone, nameof(phone));
        Guard.Against.InvalidInput(phone, nameof(phone), x => phone.Length <= 100);
    }

    #pragma warning disable CS8618
    private Contact()
    {
    }
    #pragma warning restore CS8618
}
