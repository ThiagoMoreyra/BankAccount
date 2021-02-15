using BankAccount.Domain.Shared.Notify;
using System.Text.RegularExpressions;

namespace BankAccount.Domain.Shared.Validations
{
    public class Contract : Notifiable
    {
        public Contract Requires()
        {
            return this;
        }

        public Contract ValidateSame(object object1, object object2, string message)
        {
            if (object1.Equals(object2))
            {
                AddNotification(message);
            }

            return this;
        }

        public Contract ValidateIfDifferent(object object1, object object2, string message)
        {
            if (!object1.Equals(object2))
            {
                AddNotification(message);
            }

            return this;
        }

        public Contract ValidateIfDifferent(string pattern, string valor, string message)
        {
            var regex = new Regex(pattern);

            if (!regex.IsMatch(valor))
            {
                AddNotification(message);
            }

            return this;
        }

        public Contract ValidateSize(string valor, int maximo, string message)
        {
            var length = valor.Trim().Length;
            if (length > maximo)
            {
                AddNotification(message);
            }

            return this;
        }

        public Contract ValidateSize(string valor, int minimo, int maximo, string message)
        {
            var length = valor.Trim().Length;
            if (length < minimo || length > maximo)
            {
                AddNotification(message);
            }

            return this;
        }

        public Contract ValidateIfEmpty(string valor, string message)
        {
            if (valor == null || valor.Trim().Length == 0)
            {
                AddNotification(message);
            }

            return this;
        }

        public Contract ValidateIfNull(object object1, string message)
        {
            if (object1 == null)
            {
                AddNotification(message);
            }

            return this;
        }

        public Contract ValidateMinMax(double valor, double minimo, double maximo, string message)
        {
            if (valor < minimo || valor > maximo)
            {
                AddNotification(message);
            }
            return this;
        }

        public Contract ValidateMinMax(float valor, float minimo, float maximo, string message)
        {
            if (valor < minimo || valor > maximo)
            {
                AddNotification(message);
            }

            return this;
        }

        public Contract ValidateMinMax(int valor, int minimo, int maximo, string message)
        {
            if (valor < minimo || valor > maximo)
            {
                AddNotification(message);
            }

            return this;
        }

        public Contract ValidateMinMax(long valor, long minimo, long maximo, string message)
        {
            if (valor < minimo || valor > maximo)
            {
                AddNotification(message);
            }

            return this;
        }

        public Contract ValidateMinMax(decimal valor, decimal minimo, decimal maximo, string message)
        {
            if (valor < minimo || valor > maximo)
            {
                AddNotification(message);
            }

            return this;
        }

        public Contract ValidateIfLessThan(long valor, long minimo, string message)
        {
            if (valor < minimo)
            {
                AddNotification(message);
            }

            return this;
        }

        public Contract ValidateIfLessThan(double valor, double minimo, string message)
        {
            if (valor < minimo)
            {
                AddNotification(message);
            }

            return this;
        }

        public Contract ValidateIfLessThan(decimal valor, decimal minimo, string message)
        {
            if (valor < minimo)
            {
                AddNotification(message);
            }

            return this;
        }

        public Contract ValidateIfLessThan(int valor, int minimo, string message)
        {
            if (valor < minimo)
            {
                AddNotification(message);
            }

            return this;
        }

        public Contract ValidateIfFalse(bool boolvalor, string message)
        {
            if (!boolvalor)
            {
                AddNotification(message);
            }

            return this;
        }

        public Contract ValidateIfTrue(bool boolvalor, string message)
        {
            if (boolvalor)
            {
                AddNotification(message);
            }

            return this;
        }
    }
}
