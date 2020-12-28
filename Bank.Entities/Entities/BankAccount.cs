using System;

namespace Bank.Entities.Entities
{
    public class BankAccount : IBankAccount
    {
        private string customerName;
        private double balance;
        public string CustomerName
        {
            get { return customerName; }
        }
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public void SetNameOfCustomer(string name)
        {
            this.customerName = name;
        }

        public double AddInterest(double interest)
        {
            return balance * interest;
        }

        public double Credit(double amount)
        {
            if (amount < 0)
            {
                Exception err = new Exception();
                throw err;
            }
            return balance + amount;
        }

        public double Debit(double amount)
        {
            if (amount > Balance || amount < 0)
            {
                Exception err = new Exception();
                throw err;
            }
            Balance -= amount * 1.025;
            return Balance;
        }
    }
}

