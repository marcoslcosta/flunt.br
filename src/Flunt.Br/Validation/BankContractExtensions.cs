using System;
using Flunt.Br.Document;
using Flunt.Validations;

namespace Flunt.Br.Validation
{
    public static partial class ContractExtensions
    {
         public static Contract IsCredCard(this Contract contract, string value, string property, string message)
        {
       
            if (!new CredCard().Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }
    }
}