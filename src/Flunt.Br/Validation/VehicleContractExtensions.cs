using System;
using Flunt.Br.Document;
using Flunt.Validations;

namespace Flunt.Br.Validation
{
    public static partial class ContractExtensions
    {
         public static Contract IsRenavam(this Contract contract, string value, string property, string message)
        {
            if (!new Renavam().Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }

        public static Contract IsLicensePlate(this Contract contract, string value, string property, string message)
        {
            if (!new LicensePlate().Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }
        
    }
}