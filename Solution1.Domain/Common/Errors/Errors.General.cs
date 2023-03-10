using ErrorOr;

namespace Solution1.Domain.Common.Errors;

public partial class Errors
{
    public partial class General
    {
        public static Error SavingData = Error.Unexpected(
            code: "General",
            description: "Failing saving data");
    }
}
