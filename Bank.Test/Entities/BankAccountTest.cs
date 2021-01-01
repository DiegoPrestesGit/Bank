using Bank.Entities.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Bank.Test.Entities
{
    [TestClass]
    public class BankAccountTest
    {
        private Mock<IBankAccount> _mock;
        private BankAccount accountMock;

        [TestInitialize]
        public void Inicilizer()
        {
            accountMock = new BankAccount();
            _mock = new Mock<IBankAccount>();
        }

        [TestMethod]
        public void BankAccount_AddInterest_BalancePlusInterest()
        {
            accountMock.Balance = 1000;
            double interest = 1.10;

            _mock.Setup(x => x.AddInterest(It.IsAny<double>())).Returns(accountMock.AddInterest(interest));
            double balanceRes = accountMock.Balance;
            double balanceUpdated = accountMock.AddInterest(interest);
            Assert.AreEqual(balanceRes, balanceUpdated);
        }

        [TestMethod]
        public void BankAccount_AddCredit_BalancePlusCredit_Success()
        {
            accountMock.Balance = 1000;
            double amount = 200;

            _mock.Setup(x => x.Credit(It.IsAny<double>()));
            double expected = 1200;
            double reality = accountMock.Credit(amount);
            Assert.AreEqual(expected, reality);
        }

        [TestMethod]
        public void BankAccount_Credit_BalancePlusCredit_Fail()
        {
            accountMock.Balance = 1000;
            double amount = -200;
            _mock.Setup(x => x.Credit(It.IsAny<double>()));
            Assert.ThrowsException<Exception>(() => accountMock.Credit(amount));
        }

        [TestMethod]
        public void BankAccount_Debit_BalanceLessCredit_Success()
        {
            accountMock.Balance = 1000;
            double amount = 200;
            _mock.Setup(x => x.Debit(It.IsAny<double>()));
            double expected = 795;
            double reality = accountMock.Debit(amount);
            Assert.AreEqual(expected, reality);
        }

        [TestMethod]
        public void BankAccount_Debit_BalanceLessCredit_FailMinorZero()
        {
            double amount = -200;
            _mock.Setup(x => x.Debit(It.IsAny<double>()));
            Assert.ThrowsException<Exception>(() => accountMock.Debit(amount));
        }

        [TestMethod]
        public void BankAccount_Debit_BalanceLessCredit_FailDebitMoreThanHave()
        {
            double amount = 1000;
            accountMock.Balance = 500;
            _mock.Setup(x => x.Debit(It.IsAny<double>()));
            Assert.ThrowsException<Exception>(() => accountMock.Debit(amount));
        }
    }
}
