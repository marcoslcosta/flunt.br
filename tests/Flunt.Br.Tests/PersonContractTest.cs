using Flunt.Br.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flunt.Validations;

namespace Flunt.Br.Tests
{
    [TestClass]
    public class PersonContractTest
    {
        [TestMethod]
        [DataRow("12345678910")]
        [DataRow("124.835.069-34")]
        public void IsCpf_Invalid(string value)
        {
            var wrong = new Contract()
                .IsCpf(value, "document", "Invalid document");
            Assert.AreEqual(false, wrong.Valid);
        }

        [TestMethod]
        [DataRow("08381614996")]
        [DataRow("489.062.735-92")]
        public void IsCpf_Valid(string value)
        {
            var right = new Contract()
                .IsCpf(value, "document", "Invalid document");
            Assert.AreEqual(true, right.Valid);
        }


         [TestMethod]
        [DataRow("668247690132")]
        [DataRow("333438450601")]
        [DataRow("6568351232550")]
        public void IsVoterDocument_InValid(string value)
        {
            var wrong = new Contract()
                .IsVoterDocument(value, "document", "Invalid document");
            Assert.IsFalse(wrong.Valid);
        }

        [TestMethod]
        [DataRow("668247670132")]
        [DataRow("333438450701")]
        [DataRow("656835882550")]
        public void IsVoterDocument_Valid(string value)
        {
            var right = new Contract()
                .IsVoterDocument(value, "document", "Invalid document");
            Assert.IsTrue(right.Valid);
        }
    }
}