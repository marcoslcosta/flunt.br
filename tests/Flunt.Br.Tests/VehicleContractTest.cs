using Flunt.Br.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flunt.Validations;

namespace Flunt.Br.Tests.obj
{
    [TestClass]
    public class VehicleContractTest
    {

        [TestMethod]
        [DataRow("92631760174")]
        [DataRow("78604421814")]
        [DataRow("59505749467")]
        public void IsRenavam_Valid(string value)
        {
            var wrong = new Contract()
                .IsRenavam(value, "document", "Invalid document");
            Assert.IsTrue(wrong.Valid);
        }
        
        [TestMethod]
        [DataRow("92631761174")]
        [DataRow("78604421714")]
        [DataRow("59505749667")]
        public void IsRenavam_Invalid(string value)
        {
            var wrong = new Contract()
                .IsRenavam(value, "document", "Invalid document");
            Assert.IsFalse(wrong.Valid);
        }
        
    }
}