using ErrorOr;

namespace Solution1.Domain.Common.Errors;

public partial class Errors
{
    public static class Customer
    {
        public static Error DuplicateSsn => Error.Conflict(
            code: "Ssn",
            description: "Ssn is already in use.");

        public static Error NotFound => Error.NotFound(
            code: "NotFound",
            description: "Customer not found");

        public static class Contact
        {
            public static Error DuplicatePhone => Error.Conflict(
                code: "Phone",
                description: "Phone is already in use.");

            public static Error NotFound => Error.NotFound(
            code: "NotFound",
            description: "Contact not found");
        }
    }
}
