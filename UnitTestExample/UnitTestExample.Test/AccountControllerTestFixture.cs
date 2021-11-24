using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
    public class AccountControllerTestFixture
    {
        [
            Test,
            TestCase("abcd1234", false),
            TestCase("irf@uni-corvinus", false),
            TestCase("irf.uni-corvinus.hu", false),
            TestCase("irf@uni-corvinus.hu", true)
        ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            var accountController = new AccountController();
            var actresult = accountController.ValidateEmail(email);
            Assert.AreEqual(expectedResult, actresult);
        }

        [
           Test,
           TestCase("ABCdefgh", false),
           TestCase("NAGYBETUK2", false),
           TestCase("nagybetuk02", false),
           TestCase("ABCd2", false),
           TestCase("ABCdefg12", true)
       ]
        public void TestValidatePassword(string password, bool expectedResult)
        {
            var accountController = new AccountController();
            var actresult = accountController.ValidatePassword(password);
            Assert.AreEqual(expectedResult, actresult);
        }
    }


}
