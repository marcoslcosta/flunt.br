using Flunt.Br.Document.interfaces;
using System.Text.RegularExpressions;

namespace Flunt.Br.Document
{
    public class Pis : IValidate
    {
        public bool Validate(string value)
        {
            value = new Regex(@"\.|\-").Replace(value, "");
            int[] multiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            if (value.Trim().Length != 11)
                return false;
            value = value.Trim();
            value = value.Replace("-", "").Replace(".", "").PadLeft(11, '0');

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(value[i].ToString()) * multiplicador[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            return value.EndsWith(resto.ToString());
        }
    }
}
