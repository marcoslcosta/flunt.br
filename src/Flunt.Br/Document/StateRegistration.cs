using System;
using Flunt.Br.Document.Enum;
using Flunt.Br.Document.interfaces;

namespace Flunt.Br.Document
{
    internal class StateRegistration : IValidate
    {

        internal StateRegistration(StateEnum state)
        {
            this.State = state;

        }
        private StateEnum State { get; set; }
        private string strBase;
        private string strBase2;
        private string strOrigem;
        private string strDigito1;
        private string strDigito2;
        private int intPos;
        private int intValor;
        private int intSoma = 0;
        private int intResto;
        private int intNumero;
        private int intPeso = 0;
        public bool Validate(string value)
        {
            bool retorno = false;
            this.startValidation();

            if ((value.Trim().ToUpper() == "ISENTO"))
                return true;

            for (intPos = 1; intPos <= value.Trim().Length; intPos++)
            {
                if ((("0123456789P".IndexOf(value.Substring((intPos - 1), 1), 0, System.StringComparison.OrdinalIgnoreCase) + 1) > 0))
                    strOrigem = (strOrigem + value.Substring((intPos - 1), 1));
            }

            switch (this.State)
            {
                case StateEnum.Acre:
                    return this.Acre(value, strOrigem);
                case StateEnum.Alagoas:
                    return this.Alagoas(value, strOrigem);
                case StateEnum.Amazonas:
                    return this.Amazonas(value, strOrigem);
                case StateEnum.Amapa:
                    return this.Amapa(value, strOrigem);
                case StateEnum.Bahia:
                    return this.Bahia(value, strOrigem);
                case StateEnum.Ceara:
                    return this.Ceara(value, strOrigem);
                case StateEnum.DistritoFederal:
                    return this.DistritoFederal(value, strOrigem);
                case StateEnum.EspiritoSanto:

                    #region

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                    intSoma = 0;

                    for (intPos = 1; (intPos <= 8); intPos++)
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                        intValor = (intValor * (10 - intPos));
                        intSoma = (intSoma + intValor);
                    }

                    intResto = (intSoma % 11);
                    strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                    strBase2 = (strBase.Substring(0, 8) + strDigito1);

                    if ((strBase2 == strOrigem))
                        retorno = true;

                    #endregion

                    break;

                case StateEnum.Goias:

                    #region

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                    if ((("10,11,15".IndexOf(strBase.Substring(0, 2), 0, System.StringComparison.OrdinalIgnoreCase) + 1) > 0))
                    {
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * (10 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);

                        if ((intResto == 0))
                            strDigito1 = "0";
                        else if ((intResto == 1))
                        {
                            intNumero = int.Parse(strBase.Substring(0, 8));
                            strDigito1 = (((intNumero >= 10103105) && (intNumero <= 10119997)) ? "1" : "0").Substring(((((intNumero >= 10103105) && (intNumero <= 10119997)) ? "1" : "0").Length - 1));
                        }
                        else
                            strDigito1 = Convert.ToString((11 - intResto)).Substring((Convert.ToString((11 - intResto)).Length - 1));

                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                    }

                    #endregion

                    break;

                case StateEnum.Maranhao:

                    #region

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                    if ((strBase.Substring(0, 2) == "12"))
                    {
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * (10 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);
                        strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                    }

                    #endregion

                    break;

                case StateEnum.MatoGrosso:
                    #region

                    strBase = (strOrigem.Trim() + "0000000000").Substring(0, 10);
                    intSoma = 0;
                    intPeso = 2;

                    for (intPos = 10; intPos >= 1; intPos = (intPos + -1))
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                        intValor = (intValor * intPeso);
                        intSoma = (intSoma + intValor);
                        intPeso = (intPeso + 1);

                        if ((intPeso > 9))
                            intPeso = 2;
                    }

                    intResto = (intSoma % 11);
                    strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                    strBase2 = (strBase.Substring(0, 10) + strDigito1);

                    if ((strBase2 == strOrigem))
                        retorno = true;

                    #endregion

                    break;
                case StateEnum.MatoGrossoDoSul:
                    #region

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                    if ((strBase.Substring(0, 2) == "28"))
                    {
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * (10 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);
                        strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                    }

                    #endregion

                    break;

                case StateEnum.MinasGerais:

                    #region

                    strBase = (strOrigem.Trim() + "0000000000000").Substring(0, 13);
                    strBase2 = (strBase.Substring(0, 3) + ("0" + strBase.Substring(3, 8)));
                    intNumero = 2;

                    string strSoma = "";

                    for (intPos = 1; (intPos <= 12); intPos++)
                    {
                        intValor = int.Parse(strBase2.Substring((intPos - 1), 1));
                        intNumero = ((intNumero == 2) ? 1 : 2);
                        intValor = (intValor * intNumero);

                        intSoma = (intSoma + intValor);
                        strSoma += intValor.ToString();
                    }

                    intSoma = 0;

                    //Soma -se os algarismos, não o produto
                    for (int i = 0; i < strSoma.Length; i++)
                    {
                        intSoma += int.Parse(strSoma.Substring(i, 1));
                    }

                    intValor = int.Parse(strBase.Substring(8, 2));
                    strDigito1 = (intValor - intSoma).ToString();

                    strBase2 = (strBase.Substring(0, 11) + strDigito1);

                    if ((strBase2 == strOrigem.Substring(0, 12)))
                        retorno = true;

                    if (retorno)
                    {
                        intSoma = 0;
                        intPeso = 3;

                        for (intPos = 1; (intPos <= 12); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                            if (intPeso < 2)
                                intPeso = 11;

                            intSoma += (intValor * intPeso);
                            intPeso--;
                        }

                        intResto = (intSoma % 11);
                        intValor = 11 - intResto;
                        strDigito2 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                        strBase2 = (strBase.Substring(0, 12) + strDigito2);

                        if (strBase2 == strOrigem)
                            retorno = true;
                    }

                    #endregion

                    break;

                case StateEnum.Para:

                    #region

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                    if ((strBase.Substring(0, 2) == "15"))
                    {
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * (10 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);
                        strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                    }

                    #endregion

                    break;

                case StateEnum.Paraiba:

                    #region

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                    intSoma = 0;

                    for (intPos = 1; (intPos <= 8); intPos++)
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                        intValor = (intValor * (10 - intPos));
                        intSoma = (intSoma + intValor);
                    }

                    intResto = (intSoma % 11);
                    intValor = (11 - intResto);

                    if ((intValor > 9))
                        intValor = 0;

                    strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));
                    strBase2 = (strBase.Substring(0, 8) + strDigito1);

                    if ((strBase2 == strOrigem))
                        retorno = true;

                    #endregion

                    break;

                case StateEnum.Pernambuco:
                    #region

                    strBase = (strOrigem.Trim() + "00000000000000").Substring(0, 14);
                    intSoma = 0;
                    intPeso = 2;

                    for (intPos = 7; (intPos >= 1); intPos = (intPos + -1))
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                        intValor = (intValor * intPeso);
                        intSoma = (intSoma + intValor);
                        intPeso = (intPeso + 1);

                        if ((intPeso > 9))
                            intPeso = 2;
                    }

                    intResto = (intSoma % 11);
                    intValor = (11 - intResto);

                    if ((intValor > 9))
                        intValor = (intValor - 10);

                    strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));
                    strBase2 = (strBase.Substring(0, 7) + strDigito1);

                    if ((strBase2 == strOrigem.Substring(0, 8)))
                        retorno = true;

                    if (retorno)
                    {
                        intSoma = 0;
                        intPeso = 2;

                        for (intPos = 8; (intPos >= 1); intPos = (intPos + -1))
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * intPeso);
                            intSoma = (intSoma + intValor);
                            intPeso = (intPeso + 1);

                            if ((intPeso > 9))
                                intPeso = 2;
                        }

                        intResto = (intSoma % 11);
                        intValor = (11 - intResto);

                        if ((intValor > 9))
                            intValor = (intValor - 10);

                        strDigito2 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));
                        strBase2 = (strBase.Substring(0, 8) + strDigito2);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                    }

                    #endregion

                    break;

                case StateEnum.Piaui:
                    #region

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                    intSoma = 0;

                    for (intPos = 1; (intPos <= 8); intPos++)
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                        intValor = (intValor * (10 - intPos));
                        intSoma = (intSoma + intValor);
                    }

                    intResto = (intSoma % 11);
                    strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                    strBase2 = (strBase.Substring(0, 8) + strDigito1);

                    if ((strBase2 == strOrigem))
                        retorno = true;

                    #endregion

                    break;

                case StateEnum.Parana:
                    #region

                    strBase = (strOrigem.Trim() + "0000000000").Substring(0, 10);
                    intSoma = 0;
                    intPeso = 2;

                    for (intPos = 8; (intPos >= 1); intPos = (intPos + -1))
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                        intValor = (intValor * intPeso);
                        intSoma = (intSoma + intValor);
                        intPeso = (intPeso + 1);

                        if ((intPeso > 7))
                            intPeso = 2;
                    }

                    intResto = (intSoma % 11);
                    strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                    strBase2 = (strBase.Substring(0, 8) + strDigito1);
                    intSoma = 0;
                    intPeso = 2;

                    for (intPos = 9; (intPos >= 1); intPos = (intPos + -1))
                    {
                        intValor = int.Parse(strBase2.Substring((intPos - 1), 1));
                        intValor = (intValor * intPeso);
                        intSoma = (intSoma + intValor);
                        intPeso = (intPeso + 1);

                        if ((intPeso > 7))
                            intPeso = 2;
                    }

                    intResto = (intSoma % 11);
                    strDigito2 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                    strBase2 = (strBase2 + strDigito2);

                    if ((strBase2 == strOrigem))
                        retorno = true;

                    #endregion

                    break;

                case StateEnum.RioDeJaneiro:
                    #region

                    strBase = (strOrigem.Trim() + "00000000").Substring(0, 8);
                    intSoma = 0;
                    intPeso = 2;

                    for (intPos = 7; (intPos >= 1); intPos = (intPos + -1))
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                        intValor = (intValor * intPeso);
                        intSoma = (intSoma + intValor);
                        intPeso = (intPeso + 1);

                        if ((intPeso > 7))
                            intPeso = 2;
                    }

                    intResto = (intSoma % 11);
                    strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                    strBase2 = (strBase.Substring(0, 7) + strDigito1);

                    if ((strBase2 == strOrigem))
                        retorno = true;

                    #endregion

                    break;

                case StateEnum.RioGrandeDoNorte: //Verficar com 10 digitos
                    #region

                    if (strOrigem.Length == 9)
                        strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                    else if (strOrigem.Length == 10)
                        strBase = (strOrigem.Trim() + "000000000").Substring(0, 10);

                    if ((strBase.Substring(0, 2) == "20") && strBase.Length == 9)
                    {
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * (10 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intSoma = (intSoma * 10);
                        intResto = (intSoma % 11);
                        strDigito1 = ((intResto > 9) ? "0" : Convert.ToString(intResto)).Substring((((intResto > 9) ? "0" : Convert.ToString(intResto)).Length - 1));
                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                    }
                    else if (strBase.Length == 10)
                    {
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 9); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * (11 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intSoma = (intSoma * 10);
                        intResto = (intSoma % 11);
                        strDigito1 = ((intResto > 10) ? "0" : Convert.ToString(intResto)).Substring((((intResto > 10) ? "0" : Convert.ToString(intResto)).Length - 1));
                        strBase2 = (strBase.Substring(0, 9) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                    }

                    #endregion

                    break;

                case StateEnum.Rondonia:

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                    strBase2 = strBase.Substring(3, 5);
                    intSoma = 0;

                    for (intPos = 1; (intPos <= 5); intPos++)
                    {
                        intValor = int.Parse(strBase2.Substring((intPos - 1), 1));
                        intValor = (intValor * (7 - intPos));
                        intSoma = (intSoma + intValor);
                    }

                    intResto = (intSoma % 11);
                    intValor = (11 - intResto);

                    if ((intValor > 9))
                        intValor = (intValor - 10);

                    strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));
                    strBase2 = (strBase.Substring(0, 8) + strDigito1);

                    if ((strBase2 == strOrigem))
                        retorno = true;

                    break;

                case StateEnum.Roraima:
                    #region

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                    if ((strBase.Substring(0, 2) == "24"))
                    {
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = intValor * intPos;
                            intSoma += intValor;
                        }

                        intResto = (intSoma % 9);
                        strDigito1 = Convert.ToString(intResto).Substring((Convert.ToString(intResto).Length - 1));
                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                    }

                    #endregion

                    break;

                case StateEnum.RioGrandeDoSul:
                    #region

                    strBase = (strOrigem.Trim() + "0000000000").Substring(0, 10);
                    intNumero = int.Parse(strBase.Substring(0, 3));

                    if (((intNumero > 0) && (intNumero < 468)))
                    {
                        intSoma = 0;
                        intPeso = 2;

                        for (intPos = 9; (intPos >= 1); intPos = (intPos + -1))
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * intPeso);
                            intSoma = (intSoma + intValor);
                            intPeso = (intPeso + 1);

                            if ((intPeso > 9))
                                intPeso = 2;
                        }

                        intResto = (intSoma % 11);
                        intValor = (11 - intResto);

                        if ((intValor > 9))
                            intValor = 0;

                        strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));
                        strBase2 = (strBase.Substring(0, 9) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                    }

                    #endregion

                    break;

                case StateEnum.SantaCatarina:
                    #region

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                    intSoma = 0;

                    for (intPos = 1; (intPos <= 8); intPos++)
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                        intValor = (intValor * (10 - intPos));
                        intSoma = (intSoma + intValor);
                    }

                    intResto = (intSoma % 11);
                    strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                    strBase2 = (strBase.Substring(0, 8) + strDigito1);

                    if ((strBase2 == strOrigem))
                        retorno = true;
                    #endregion

                    break;

                case StateEnum.Sergipe:
                    #region

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                    intSoma = 0;

                    for (intPos = 1; (intPos <= 8); intPos++)
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                        intValor = (intValor * (10 - intPos));
                        intSoma = (intSoma + intValor);
                    }

                    intResto = (intSoma % 11);
                    intValor = (11 - intResto);

                    if ((intValor > 9))
                        intValor = 0;

                    strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));
                    strBase2 = (strBase.Substring(0, 8) + strDigito1);

                    if ((strBase2 == strOrigem))
                        retorno = true;

                    #endregion

                    break;

                case StateEnum.SaoPaulo:
                    #region

                    if ((strOrigem.Substring(0, 1) == "P"))
                    {
                        strBase = (strOrigem.Trim() + "0000000000000").Substring(0, 13);
                        strBase2 = strBase.Substring(1, 8);
                        intSoma = 0;
                        intPeso = 1;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos), 1));
                            intValor = (intValor * intPeso);
                            intSoma = (intSoma + intValor);
                            intPeso = (intPeso + 1);

                            if ((intPeso == 2))
                                intPeso = 3;

                            if ((intPeso == 9))
                                intPeso = 10;
                        }

                        intResto = (intSoma % 11);
                        strDigito1 = Convert.ToString(intResto).Substring((Convert.ToString(intResto).Length - 1));
                        strBase2 = (strBase.Substring(0, 9) + (strDigito1 + strBase.Substring(10, 3)));
                    }
                    else
                    {
                        strBase = (strOrigem.Trim() + "000000000000").Substring(0, 12);
                        intSoma = 0;
                        intPeso = 1;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * intPeso);
                            intSoma = (intSoma + intValor);
                            intPeso = (intPeso + 1);

                            if ((intPeso == 2))
                                intPeso = 3;

                            if ((intPeso == 9))
                                intPeso = 10;
                        }

                        intResto = (intSoma % 11);
                        strDigito1 = Convert.ToString(intResto).Substring((Convert.ToString(intResto).Length - 1));
                        strBase2 = (strBase.Substring(0, 8) + (strDigito1 + strBase.Substring(9, 2)));
                        intSoma = 0;
                        intPeso = 2;

                        for (intPos = 11; (intPos >= 1); intPos = (intPos + -1))
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * intPeso);
                            intSoma = (intSoma + intValor);
                            intPeso = (intPeso + 1);

                            if ((intPeso > 10))
                                intPeso = 2;
                        }

                        intResto = (intSoma % 11);
                        strDigito2 = Convert.ToString(intResto).Substring((Convert.ToString(intResto).Length - 1));
                        strBase2 = (strBase2 + strDigito2);
                    }

                    if ((strBase2 == strOrigem))
                        retorno = true;

                    #endregion

                    break;

                case StateEnum.Tocantins:
                    #region

                    strBase = (strOrigem.Trim() + "00000000000").Substring(0, 11);

                    if ((("01,02,03,99".IndexOf(strBase.Substring(2, 2), 0, System.StringComparison.OrdinalIgnoreCase) + 1) > 0))
                    {
                        strBase2 = (strBase.Substring(0, 2) + strBase.Substring(4, 6));
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase2.Substring((intPos - 1), 1));
                            intValor = (intValor * (10 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);
                        strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                        strBase2 = (strBase.Substring(0, 10) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                    }

                    #endregion

                    break;

            }

            return retorno;
        }

        private void startValidation()
        {
            this.strBase = "";
            this.strBase2 = "";
            this.strOrigem = "";
            this.strDigito1 = "";
            this.strDigito2 = "";
            this.intPos = 0;
            this.intValor = 0;
            this.intSoma = 0;
            this.intResto = 0;
            this.intNumero = 0;
            this.intPeso = 0;
        }

        private bool Acre(string value, string strOrigem)
        {
            strBase = (strOrigem.Trim() + "00000000000").Substring(0, 11);

            if (strBase.Substring(0, 2) == "01")
            {
                intSoma = 0;
                intPeso = 4;

                for (intPos = 1; (intPos <= 11); intPos++)
                {
                    intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                    if (intPeso == 1) intPeso = 9;

                    intSoma += intValor * intPeso;

                    intPeso--;
                }

                intResto = (intSoma % 11);
                strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                intSoma = 0;
                strBase = (strOrigem.Trim() + "000000000000").Substring(0, 12);
                intPeso = 5;

                for (intPos = 1; (intPos <= 12); intPos++)
                {
                    intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                    if (intPeso == 1) intPeso = 9;

                    intSoma += intValor * intPeso;
                    intPeso--;
                }

                intResto = (intSoma % 11);
                strDigito2 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                strBase2 = (strBase.Substring(0, 12) + strDigito2);

                return (strBase2 == strOrigem);
            }
            return false;
        }
        private bool Alagoas(string value, string strOrigem)
        {

            strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

            if ((strBase.Substring(0, 2) == "24"))
            {
                //24000004-8
                //98765432
                intSoma = 0;
                intPeso = 9;

                for (intPos = 1; (intPos <= 8); intPos++)
                {
                    intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                    intSoma += intValor * intPeso;
                    intPeso--;
                }

                intSoma = (intSoma * 10);
                intResto = (intSoma % 11);

                strDigito1 = ((intResto == 10) ? "0" : Convert.ToString(intResto)).Substring((((intResto == 10) ? "0" : Convert.ToString(intResto)).Length - 1));

                strBase2 = (strBase.Substring(0, 8) + strDigito1);

                return (strBase2 == strOrigem);

            }
            return false;
        }
        private bool Amazonas(string value, string strOrigem)
        {
            strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
            intSoma = 0;
            intPeso = 9;

            for (intPos = 1; (intPos <= 8); intPos++)
            {
                intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                intSoma += intValor * intPeso;
                intPeso--;
            }

            intResto = (intSoma % 11);

            if (intSoma < 11)
                strDigito1 = (11 - intSoma).ToString();
            else
                strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

            strBase2 = (strBase.Substring(0, 8) + strDigito1);

            return (strBase2 == strOrigem);

        }
        private bool Amapa(string value, string strOrigem)
        {
            strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
            intPeso = 9;

            if ((strBase.Substring(0, 2) == "03"))
            {
                strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                intSoma = 0;

                for (intPos = 1; (intPos <= 8); intPos++)
                {
                    intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                    intSoma += intValor * intPeso;
                    intPeso--;
                }

                intResto = (intSoma % 11);
                intValor = (11 - intResto);

                strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));

                strBase2 = (strBase.Substring(0, 8) + strDigito1);

                return (strBase2 == strOrigem);
            }
            return false;
        }
        private bool Bahia(string value, string strOrigem)
        {
            bool retorno = false;
            if (strOrigem.Length == 8)
                strBase = (strOrigem.Trim() + "00000000").Substring(0, 8);
            else if (strOrigem.Length == 9)
                strBase = (strOrigem.Trim() + "00000000").Substring(0, 9);

            if ((("0123458".IndexOf(strBase.Substring(0, 1), 0, System.StringComparison.OrdinalIgnoreCase) + 1) > 0) && strBase.Length == 8)
            {


                intSoma = 0;

                for (intPos = 1; (intPos <= 6); intPos++)
                {
                    intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                    if (intPos == 1) intPeso = 7;

                    intSoma += intValor * intPeso;
                    intPeso--;
                }


                intResto = (intSoma % 10);
                strDigito2 = ((intResto == 0) ? "0" : Convert.ToString((10 - intResto))).Substring((((intResto == 0) ? "0" : Convert.ToString((10 - intResto))).Length - 1));


                strBase2 = strBase.Substring(0, 7) + strDigito2;

                if (strBase2 == strOrigem)
                    retorno = true;

                if (retorno)
                {
                    intSoma = 0;
                    intPeso = 0;

                    for (intPos = 1; (intPos <= 7); intPos++)
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                        if (intPos == 7)
                            intValor = int.Parse(strBase.Substring((intPos), 1));

                        if (intPos == 1) intPeso = 8;

                        intSoma += intValor * intPeso;
                        intPeso--;
                    }


                    intResto = (intSoma % 10);
                    strDigito1 = ((intResto == 0) ? "0" : Convert.ToString((10 - intResto))).Substring((((intResto == 0) ? "0" : Convert.ToString((10 - intResto))).Length - 1));

                    strBase2 = (strBase.Substring(0, 6) + strDigito1 + strDigito2);

                    if ((strBase2 == strOrigem))
                        retorno = true;
                }

            }
            else if ((("679".IndexOf(strBase.Substring(0, 1), 0, System.StringComparison.OrdinalIgnoreCase) + 1) > 0) && strBase.Length == 8)
            {


                intSoma = 0;

                for (intPos = 1; (intPos <= 6); intPos++)
                {
                    intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                    if (intPos == 1) intPeso = 7;

                    intSoma += intValor * intPeso;
                    intPeso--;
                }


                intResto = (intSoma % 11);
                strDigito2 = ((intResto == 0) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto == 0) ? "0" : Convert.ToString((11 - intResto))).Length - 1));


                strBase2 = strBase.Substring(0, 7) + strDigito2;

                if (strBase2 == strOrigem)
                    retorno = true;

                if (retorno)
                {
                    intSoma = 0;
                    intPeso = 0;

                    for (intPos = 1; (intPos <= 7); intPos++)
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                        if (intPos == 7)
                            intValor = int.Parse(strBase.Substring((intPos), 1));

                        if (intPos == 1) intPeso = 8;

                        intSoma += intValor * intPeso;
                        intPeso--;
                    }


                    intResto = (intSoma % 11);
                    strDigito1 = ((intResto == 0) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto == 0) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                    strBase2 = (strBase.Substring(0, 6) + strDigito1 + strDigito2);

                    if ((strBase2 == strOrigem))
                        retorno = true;
                }

            }
            else if ((("0123458".IndexOf(strBase.Substring(1, 1), 0, System.StringComparison.OrdinalIgnoreCase) + 1) > 0) && strBase.Length == 9)
            {
                /* Segundo digito */
                //1000003
                //8765432
                intSoma = 0;


                for (intPos = 1; (intPos <= 7); intPos++)
                {
                    intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                    if (intPos == 1) intPeso = 8;

                    intSoma += intValor * intPeso;
                    intPeso--;
                }

                intResto = (intSoma % 10);
                strDigito2 = ((intResto == 0) ? "0" : Convert.ToString((10 - intResto))).Substring((((intResto == 0) ? "0" : Convert.ToString((10 - intResto))).Length - 1));

                strBase2 = strBase.Substring(0, 8) + strDigito2;

                if (strBase2 == strOrigem)
                    retorno = true;

                if (retorno)
                {
                    //1000003 6
                    //9876543 2
                    intSoma = 0;
                    intPeso = 0;

                    for (intPos = 1; (intPos <= 8); intPos++)
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                        if (intPos == 8)
                            intValor = int.Parse(strBase.Substring((intPos), 1));

                        if (intPos == 1) intPeso = 9;

                        intSoma += intValor * intPeso;
                        intPeso--;
                    }


                    intResto = (intSoma % 10);
                    strDigito1 = ((intResto == 0) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto == 0) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                    strBase2 = (strBase.Substring(0, 7) + strDigito1 + strDigito2);

                    return (strBase2 == strOrigem);
                    retorno = true;
                }
            }
            return retorno;
        }
        private bool Ceara(string value, string strOrigem)
        {
            var retorno = false;
            strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
            intSoma = 0;

            for (intPos = 1; (intPos <= 8); intPos++)
            {
                intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                intValor = (intValor * (10 - intPos));
                intSoma = (intSoma + intValor);
            }

            intResto = (intSoma % 11);
            intValor = (11 - intResto);

            if ((intValor > 9))
                intValor = 0;

            strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));

            strBase2 = (strBase.Substring(0, 8) + strDigito1);

            if ((strBase2 == strOrigem))
                retorno = true;

            return retorno;


        }

        private bool DistritoFederal(string value, string strOrigem)
        {
            var retorno = false;

            strBase = (strOrigem.Trim() + "0000000000000").Substring(0, 13);

            if ((strBase.Substring(0, 3) == "073"))
            {
                intSoma = 0;
                intPeso = 2;

                for (intPos = 11; (intPos >= 1); intPos = (intPos + -1))
                {
                    intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                    intValor = (intValor * intPeso);
                    intSoma = (intSoma + intValor);
                    intPeso = (intPeso + 1);

                    if ((intPeso > 9))
                        intPeso = 2;
                }

                intResto = (intSoma % 11);
                strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                strBase2 = (strBase.Substring(0, 11) + strDigito1);
                intSoma = 0;
                intPeso = 2;

                for (intPos = 12; (intPos >= 1); intPos = (intPos + -1))
                {
                    intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                    intValor = (intValor * intPeso);
                    intSoma = (intSoma + intValor);
                    intPeso = (intPeso + 1);

                    if ((intPeso > 9))
                        intPeso = 2;
                }

                intResto = (intSoma % 11);
                strDigito2 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                strBase2 = (strBase.Substring(0, 12) + strDigito2);

                if ((strBase2 == strOrigem))
                    retorno = true;


            }

            return retorno;
        }


    }
}