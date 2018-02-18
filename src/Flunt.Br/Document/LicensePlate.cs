using System.Text.RegularExpressions;
using Flunt.Br.Document.interfaces;
using System.Collections.Generic;

namespace Flunt.Br.Document
{
    internal class LicensePlate : IValidate
    {
        public bool Validate(string value)
        {
            Regex regex = new Regex(@"^[a-zA-Z]{3}\-\d{4}$");
            return regex.IsMatch(value);
        }
    }
}