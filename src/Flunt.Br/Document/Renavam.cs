using Flunt.Br.Document.interfaces;
using System;
using System.Text.RegularExpressions;

namespace Flunt.Br.Document
{
    public class Renavam : IValidate
    {
        public bool Validate(string value)
        {
        if (string.IsNullOrEmpty(value.Trim())) return false;
 
        int[] d = new int[11];
        string sequencia = "3298765432";
        string SoNumero = Regex.Replace(value, "[^0-9]", string.Empty);
 
        if (string.IsNullOrEmpty(SoNumero)) return false;
 
        //verificando se todos os numeros são iguais **************************
        if (new string(SoNumero[0], SoNumero.Length) == SoNumero) return false;
        SoNumero = Convert.ToInt64(SoNumero).ToString("00000000000");
 
        int v = 0;
 
        for (int i = 0; i < 11; i++)
            d[i] = Convert.ToInt32(SoNumero.Substring(i, 1));
 
        for (int i = 0; i < 10; i++)
            v += d[i] * Convert.ToInt32(sequencia.Substring(i, 1));
 
        v = (v * 10) % 11; v = (v != 10) ? v : 0;
        return (v == d[10]);
        }
    }
}