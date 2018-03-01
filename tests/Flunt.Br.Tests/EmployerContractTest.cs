using Flunt.Br.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flunt.Validations;
using Flunt.Br.Document.Enum;

namespace Flunt.Br.Tests
{
    [TestClass]
    public class EmployerContractTest
    {

        [TestMethod]
        [DataRow("123456789101112")]
        [DataRow("655618111115522")]
        [DataRow("45.448.481/0501-18")]
        public void IsCnpj_InValid(string value)
        {
            var wrong = new Contract()
                .IsCnpj(value, "document", "Invalid document");
            Assert.IsFalse(wrong.Valid);
        }

        [TestMethod]
        [DataRow("16880249000179")]
        [DataRow("45.448.421/0001-18")]
        public void IsCnpj_Valid(string value)
        {
            var right = new Contract()
                .IsCnpj(value, "document", "Invalid document");
            Assert.IsTrue(right.Valid);
        }
        [TestMethod]
        [DataRow("01.992.811/585-39", StateEnum.Acre)]
        [DataRow("248980742", StateEnum.Alagoas)]
        [DataRow("033234019", StateEnum.Amapa)]
        [DataRow("51.967.453-7", StateEnum.Amazonas)]
        [DataRow("076530-09", StateEnum.Bahia)]
        [DataRow("59460925-9", StateEnum.Ceara)]
        [DataRow("07708536001-34", StateEnum.DistritoFederal)]
        [DataRow("65170833-8", StateEnum.EspiritoSanto)]
        [DataRow("15.343.393-0", StateEnum.Goias)]
        [DataRow("12905194-2", StateEnum.Maranhao)]
        [DataRow("7800789255-8", StateEnum.MatoGrosso)]
        [DataRow("28947009-9", StateEnum.MatoGrossoDoSul)]
        [DataRow("067.417.923/1173", StateEnum.MinasGerais)]
        [DataRow("15-920982-0", StateEnum.Para)]
        [DataRow("92979315-3", StateEnum.Paraiba)]
        [DataRow("721.58866-16", StateEnum.Parana)]
        [DataRow("8971413-00", StateEnum.Pernambuco)]
        [DataRow("28355893-8", StateEnum.Piaui)]
        [DataRow("33.378.75-0", StateEnum.RioDeJaneiro)]
        [DataRow("20.549.294-0", StateEnum.RioGrandeDoNorte)]
        [DataRow("219/4738732", StateEnum.RioGrandeDoSul)]
        [DataRow("1430392797740-1", StateEnum.Rondonia)]
        [DataRow("24189870-7", StateEnum.Roraima)]
        [DataRow("995.660.562.657", StateEnum.SaoPaulo)]
        [DataRow("929.509.560", StateEnum.SantaCatarina)]
        [DataRow("17179305-6", StateEnum.Sergipe)]
        [DataRow("2903785004-0", StateEnum.Tocantins)]

        public void IsStateRegistration_Valid(string value, StateEnum state)
        {
            var right = new Contract()
             .IsStateRegistration(value, state, "document", "Invalid document");
            Assert.IsTrue(right.Valid);

        }


    }
}