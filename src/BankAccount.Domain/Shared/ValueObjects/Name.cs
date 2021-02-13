using BankAccount.Domain.Shared.Validations;

namespace BankAccount.Domain.Shared.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                            .Requires()
                            .ValidateIfEmpty(this.FirstName, "The FirstName field cannot be empty")
                            .ValidateIfEmpty(this.LastName, "The LastName field cannot be empty")
                            .ValidateIfNull(this.LastName, "The FirstName field cannot be null")
                            .ValidateIfNull(this.LastName, "The LastName field cannot be null"));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
