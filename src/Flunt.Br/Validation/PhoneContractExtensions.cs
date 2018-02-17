using System;
using Flunt.Br.Document;
using Flunt.Validations;

namespace Flunt.Br.Validation
{
    public static partial class ContractExtensions
    {
        public static Contract IsPhone(this Contract contract, string value, string property, string message)
        {
            if (!new Phone().Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }

        public static Contract IsPhone(this Contract contract, string value, string numberFormat, string property, string message)
        {
            if (!new Phone(numberFormat).Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }


        [Obsolete("Use IsPhone(contract, value, property, message) or IsPhone(contract, value, numberFormat, property, message)")]
        public static Contract IsCellPhone(this Contract contract, string value, string property, string message)
        {
            if (!new Cellphone().Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }

    }
}