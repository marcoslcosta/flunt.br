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
            var right = new Contract()
                .IsRenavam(value, "document", "Invalid document");
            Assert.IsTrue(right.Valid);
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


        [TestMethod]
        [DataRow("HVN-9707")]
        [DataRow("JZE-5143")]
        [DataRow("MSV-9616")]
        public void IsLicensePlate_Valid(string value)
        {
            var right = new Contract()
                .IsRenavam(value, "document", "Invalid document");
            Assert.IsFalse(right.Valid);
        }

        [TestMethod]
        [DataRow("HVN-97074")]
        [DataRow("JeZE-5143")]
        [DataRow("MSjV-9616")]
        public void IsLicensePlate_Invlid(string value)
        {
            var wrong = new Contract()
                .IsRenavam(value, "document", "Invalid document");
            Assert.IsFalse(wrong.Valid);
        }
        

    }
}