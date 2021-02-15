using BankAccount.Domain.Shared.Validations;

namespace BankAccount.Domain.Shared.ValueObjects
{
    public class Cpf : ValueObject
    {
        public Cpf(string document)
        {
            Document = document;

            AddNotifications(new Contract()
                            .Requires()
                            .ValidateIfEmpty(this.Document, "The Number field cannot be empty")
                            .ValidateIfNull(this.Document, "The Number field cannot be null"));
        }

        public string Document { get; private set; }

        public bool Validate()
        {
            return CpfValidation.Validar(this.Document);
        }
    }
}
