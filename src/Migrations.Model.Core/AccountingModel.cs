using System;
using System.Collections.Generic;

namespace Migrations.Model
{

    public class Customer
    {
        public Customer()
        {
            Accounts = new List<Account>();
            Created = Updated = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        private IList<Account> Accounts { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

    }

    public class Account
    {
        public Account()
        {
            Transactions = new List<Transaction>();
            Created = Updated = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public IList<Transaction> Transactions { get; set; }

        public AccountType Type { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
        
    }

    public enum AccountType
    {
        Checking,
        Savings,
        Retirement
    }

    public class Transaction
    {
        public Transaction()
        {
            Created = Updated = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public decimal Amount { get; set; }

        public TransactionType Type { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }

    public enum TransactionType
    {
        Deposit,
        Credit,
        Debit
    }
}
