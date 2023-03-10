using Ardalis.GuardClauses;
using Solution1.Domain.Common;
using Solution1.Domain.UserAggregate.ValueObjects;

namespace Solution1.Domain.UserAggregate;

public sealed class User : Entity<UserId>, IAggregateRoot

{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }

    private User(UserId id, string firstName, string lastName, string email)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public static User Create(string firstName, string lastName, string email)
    {
        ValidateFirstName(firstName);
        ValidateLastName(lastName);
        ValidateEmail(email);

        return  new User(UserId.CreateUnique(), firstName, lastName, email);
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

    private static void ValidateEmail(string email)
    {
        Guard.Against.NullOrEmpty(email, nameof(email));
        Guard.Against.InvalidFormat(email, nameof(email), @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
    }
}
