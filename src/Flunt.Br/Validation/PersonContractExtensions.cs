using System;
using Flunt.Br.Document;
using Flunt.Validations;

namespace Flunt.Br.Validation
{
    public static partial class ContractExtensions
    {
        public static Contract IsCpf(this Contract contract, string value, string property, string message)
        {
            if (!new Cpf().Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }

       
        public static Contract IsVoterDocument(this Contract contract, string value, string property, string message)
        {
            if (!new VoterDocument().Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }
    }
}