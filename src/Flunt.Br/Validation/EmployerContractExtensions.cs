using System;
using Flunt.Br.Document;
using Flunt.Br.Document.Enum;
using Flunt.Validations;

namespace Flunt.Br.Validation
{

    public static partial class ContractExtensions
    {
        [Obsolete("Use IsCnpj(contract, value, property, message)")]
        public static bool ValidateCnpj(string cnpj) => new Cnpj().Validate(cnpj);

        public static Contract IsCnpj(this Contract contract, string value, string property, string message)
        {
            if (!new Cnpj().Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }

        public static Contract IsStateRegistration(this Contract contract, string value, StateEnum state, string property, string message)
        {
            if (!new StateRegistration(state).Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }



    }
}