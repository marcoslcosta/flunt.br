using System;
using System.Text.RegularExpressions;
using Flunt.Br.Document;
using Flunt.Validations;

namespace Flunt.Br.Validation
{
    public static partial class ContractExtensions
    {
        public static Contract IsPis(this Contract contract, string value, string property, string message)
        {
            if (!new Pis().Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }
    }
}