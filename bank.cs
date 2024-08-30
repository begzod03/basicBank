using System;
using System.Collections.Generic;

namespace BankAccountManagementSystem
{
    public class BankAccount
    {
        public string AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public decimal Balance { get; set; }

        public BankAccount(string accountNumber, string accountHolder, decimal balance)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds.");
            }
            else
            {
                Balance -= amount;
            }
        }

        public void DisplayAccountInfo()
        {
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Account Holder: {AccountHolder}");
            Console.WriteLine($"Balance: {Balance}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<BankAccount> accounts = new List<BankAccount>();

            while (true)
            {
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Check Balance");
                Console.WriteLine("5. Exit");

                Console.WriteLine("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice) {
                    case 1:
                        CreateAccount(accounts);
                        break;
                    case 2:
                        Deposit(accounts);
                        break;
                    case 3:
                        Withdraw(accounts);
                        break;
                    case 4:
                        CheckBalance(accounts);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choise. Please try again!");
                        break;
                }
            }
        }

        static void CreateAccount(List<BankAccount> accounts) 
        {
                Console.Write("Enter Account Number: ");
                string accountNumber = Console.ReadLine();

                Console.Write("Enter Account Holder: ");
                string accountHolder = Console.ReadLine();

                Console.Write("Enter initial balance");                
                decimal balance = Convert.ToDecimal(Console.ReadLine());

                BankAccount account = new BankAccount(accountNumber, accountHolder, balance);
                accounts.Add(account);

                Console.WriteLine("Account created successfully.");
        }

            static void Deposit(List<BankAccount> accounts)
            {
                Console.Write("Enter account number: ");
                string accountNumber = Console.ReadLine();

                BankAccount account = accounts.Find(a => a.AccountNumber == accountNumber);

                if (account != null)
                {
                    Console.Write("What's the amount you would like to deposit?");
                    decimal amount = Convert.ToDecimal(Console.ReadLine());

                    account.Deposit(amount);                    
                }
                else{
                    Console.WriteLine("Account not found, try again");
                }
            }

            static void Withdraw(List<BankAccount> accounts)
            {
                Console.Write("Enter Account number: ");
                string accountNumber = Console.ReadLine();

                BankAccount account = accounts.Find(a => a.AccountNumber == accountNumber);

                if (account != null)
                {
                    Console.Write("What's the amount you would like to withdraw? ");
                    decimal amount = Convert.ToDecimal(Console.ReadLine());

                    account.Withdraw(amount);

                    Console.WriteLine($"Successfully withdrew ${amount} from your account");
                    Console.WriteLine($"Your updated balance is not: {account.Balance}");
                }
                else
                {
                    Console.WriteLine("Invalid account number, try again.");
                }
            }

            static void CheckBalance(List<BankAccount> accounts)
                {
                    Console.Write("What's you account number? ");
                    string accountNumber = Console.ReadLine();

                    BankAccount account = accounts.Find(a => a.AccountNumber == accountNumber);

                    if (account != null)
                    {
                        account.DisplayAccountInfo();
                    }
                    else
                    {
                        Console.WriteLine("account not found.");
                    }
        }
    }
}
