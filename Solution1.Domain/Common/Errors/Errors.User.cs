using ErrorOr;

namespace Solution1.Domain.Common.Errors;

public partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "Email is already in use.");
    }
}
