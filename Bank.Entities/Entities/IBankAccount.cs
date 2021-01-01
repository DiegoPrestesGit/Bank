using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Entities.Entities
{
    public interface IBankAccount
    {
        double AddInterest(double interest);
        double Credit(double amount);
        double Debit(double amount);
    }
}
