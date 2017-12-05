using System;
using System.Text.RegularExpressions;
using Flunt.Validations;

namespace Flunt.Br.Validation
{
    public static class ContractExtensions
    {
        private static bool ValidateCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
            return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for(int i=0; i<9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if ( resto < 2 )
                resto = 0;
            else
            resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for(int i=0; i<10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
            resto = 0;
            else
            resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static Contract IsCpf(this Contract contract, string value, string property, string message)
        {
            if(!ValidateCpf(value))
                contract.AddNotification(property, message);
            return contract;
        }

        public static bool ValidateCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] {5,4,3,2,9,8,7,6,5,4,3,2};
            int[] multiplicador2 = new int[13] {6,5,4,3,2,9,8,7,6,5,4,3,2};
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
            return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for(int i=0; i<12; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if ( resto < 2)
            resto = 0;
            else
            resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
            resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        public static Contract IsCnpj(this Contract contract, string value, string property, string message)
        {
            if(!ValidateCnpj(value))
                contract.AddNotification(property, message);
            return contract;
        }

        public static Contract IsCellPhone(this Contract contract, string value, string property, string message)
        {
            if(!new Regex(@"^\(\d{2}\)\d{4,5}-\d{4}$").Match(value).Success)
                contract.AddNotification(property, message);
            return contract;
        }

        public static Contract IsPhone(this Contract contract, string value, string property, string message)
        {
            return IsPhone(contract, "(99)9999-9999", value, property, message);
        }

        public static Contract IsPhone(this Contract contract, string format, string value, string property, string message)
        {
            if(!CreateRegularExpression(format).Match(value).Success)
                contract.AddNotification(property, message);
            return contract;
        }

        private static Regex CreateRegularExpression(string format)
        {
            var regex = new Regex(@"[0-9]+");
            var phonePattern = Regex.Replace(format, @"[0-9]+", m => $@"\d{{{m.Length}}}");
            phonePattern = Regex.Replace(phonePattern, @"(?:(?(1)(?!))(\+)|(?(2)(?!))(\()|(?(3)(?!))(\)))+", m => $@"\{m.Value}");
            return new Regex(phonePattern);
        }
    }
}