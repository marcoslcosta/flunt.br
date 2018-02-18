using Flunt.Br.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flunt.Validations;

namespace Flunt.Br.Tests
{
    [TestClass]
    public class WorkerContractTest
    {
        [TestMethod]
        [DataRow("07423404749")]
        [DataRow("49427183343")]
        [DataRow("100.47065.34-3")]
        public void IsPis_Valid(string value)
        {
            var wrong = new Contract()
                .IsPis(value, "document", "Invalid document");
            Assert.IsTrue(wrong.Valid);
        }
        
        [TestMethod]
        [DataRow("07423504749")]
        [DataRow("49427183843")]
        [DataRow("100.49065.44-3")]
        public void IsPis_Invalid(string value)
        {
            var wrong = new Contract()
                .IsPis(value, "document", "Invalid document");
            Assert.IsFalse(wrong.Valid);
        }
    }
}