using Flunt.Br.Document.interfaces;
using System.Linq;

namespace Flunt.Br.Document
{
    internal class CredCard : IValidate
    {
        public bool Validate(string value)
        {
        
            if (value.All(char.IsDigit) == false)
            {
                return false;
            }
            if (12 > value.Length || value.Length > 19)
            {
                return false;
            }
          
            return IsValidLuhnn(value);
        }

        private bool IsValidLuhnn(string val)
        {
            int currentDigit;
            int valSum = 0;
            int currentProcNum = 0;

            for (int i = val.Length - 1; i >= 0; i--)
            {
                if (!int.TryParse(val.Substring(i, 1), out currentDigit))
                    return false;

                currentProcNum = currentDigit << (1 + i & 1);
                valSum += (currentProcNum > 9 ? currentProcNum - 9 : currentProcNum);

            }

            return (valSum > 0 && valSum % 10 == 0);
        }
    }
}