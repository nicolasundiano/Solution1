using Ardalis.GuardClauses;
using Solution1.Domain.Common;
using Solution1.Domain.CustomerAggregate.Entities;
using Solution1.Domain.CustomerAggregate.ValueObjects;

namespace Solution1.Domain.CustomerAggregate;

public sealed class Customer : Entity<CustomerId>, IAggregateRoot
{
    private readonly List<Contact> _contacts = new();
    public string BusinessName { get; private set; }
    public string Ssn { get; private set; }
    public Location Location { get; private set; }

    public IReadOnlyList<Contact> Contacts => _contacts.AsReadOnly();

    private Customer(CustomerId id, string businessName, string ssn, Location location, List<Contact> contacts)
       : base(id)
    {
        BusinessName = businessName;
        Ssn = ssn;
        Location = location;
        _contacts = contacts;
    }

    public static Customer Create(string businessName, string ssn, Location location, List<Contact> contacts)
    {
        ValidateNew(businessName, ssn, contacts);

        return new Customer(CustomerId.CreateUnique(), businessName, ssn, location, contacts);
    }

    public Contact? GetContact(ContactId contactId)
    {
        return this.Contacts.FirstOrDefault(x => x.Id == contactId);
    }

    public void UpdateContact(Contact contact, string newFirstName, string newLastName, string newPhone)
    {
        contact.Update(newFirstName, newLastName, newPhone);

        Validate();
    }

    public void AddContact(Contact contact)
    {
        _contacts.Add(contact);

        Validate();
    }

    private static void ValidateNew(string businessName, string ssn, IReadOnlyList<Contact> contacts)
    {
        ValidateBusinessName(businessName);
        ValidateSsn(ssn);
        ValidateContacts(contacts);
    }

    private void Validate()
    {
        ValidateBusinessName(BusinessName);
        ValidateSsn(Ssn);
        ValidateContacts(Contacts);
    }

    private static void ValidateBusinessName(string businessName)
    {
        Guard.Against.NullOrEmpty(businessName);
        Guard.Against.InvalidInput(businessName, nameof(businessName), x => businessName.Length <= 100);
    }

    private static void ValidateSsn(string ssn)
    {
        Guard.Against.NullOrEmpty(ssn);
        Guard.Against.InvalidInput(ssn, nameof(ssn), x => ssn.Length <= 100);
    }

    private static void ValidateContacts(IReadOnlyList<Contact> contacts)
    {
        Guard.Against.InvalidInput(
            contacts,
            nameof(contacts),
            x => !x.GroupBy(x => new { x.Phone }).Where(x => x.Skip(1).Any()).Any());
    }

#pragma warning disable CS8618
    private Customer()
    {
    }
#pragma warning restore CS8618
}
