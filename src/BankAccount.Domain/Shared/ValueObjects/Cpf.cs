using BankAccount.Domain.Shared.Validations;

namespace BankAccount.Domain.Shared.ValueObjects
{
    public class Cpf : ValueObject
    {
        public Cpf(string number)
        {
            Number = number;

            AddNotifications(new Contract()
                            .Requires()
                            .ValidateIfEmpty(this.Number, "The Number field cannot be empty")
                            .ValidateIfNull(this.Number, "The Number field cannot be null"));
        }

        public string Number { get; private set; }

        public bool Validate()
        {
            return CpfValidation.Validar(this.Number);
        }
    }
}
