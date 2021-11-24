﻿using NUnit.Framework;
using System;
using System.Activities;
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

        [
           Test,
           TestCase("irf@uni - corvinus.hu", "Abcd1234"),
           TestCase("irf@uni-corvinus.hu", "Abcd1234567")
        ]
        public void TestRegisterHappyPath(string email, string password)
        {
            var accountController = new AccountController();
            var actresult = accountController.Register(email, password);
            Assert.AreEqual(email, actresult.Email);
            Assert.AreEqual(password, actresult.Password);
            Assert.AreNotEqual(Guid.Empty, actresult.ID);
        }


        [
            Test,
            TestCase("irf@uni-corvinus", "Abcd1234"),
            TestCase("irf.uni-corvinus.hu", "Abcd1234"),
            TestCase("irf@uni-corvinus.hu", "abcd1234"),
            TestCase("irf@uni-corvinus.hu", "ABCD1234"),
            TestCase("irf@uni-corvinus.hu", "abcdABCD"),
            TestCase("irf@uni-corvinus.hu", "Ab1234"),
        ]

        public void TestRegisterValidateException(string email, string password)
        {
            var accountController = new AccountController();
            try
            {
                var actualResult = accountController.Register(email, password);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOf<ValidationException>(ex);
            }
        }
    }
}
