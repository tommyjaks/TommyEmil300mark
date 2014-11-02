using System;
using System.Windows.Forms;
using Logic.Exceptions;
using Logic.Service.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UrlValidatorTests
    {
        [TestMethod]
        public void Expect_valid_url_to_be_ok()
        {
            var validator = new UrlValidator();
            var expected = validator.Validate("http://tyngreradio.libsyn.com/rss");
            
            Assert.AreEqual(true, expected);

        }

    }
}
