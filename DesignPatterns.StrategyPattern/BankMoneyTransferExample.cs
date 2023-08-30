using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StrategyPattern
{
    // Transfer Money With Different Options

    public interface ITransferMoney
    {
        void TransferMoney(PaymentOptions options);
    }

    public class PaymentOptions
    {
        public string SourceAccount { get; set; }
        public string DestinationAccount { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransferDate { get; set; }
    }

    public class BankTransfer : ITransferMoney
    {
        public void TransferMoney(PaymentOptions options)
        {
            Console.WriteLine($"Transfering money with bank transfer " +
                $"{options.SourceAccount} " +
                $"To {options.DestinationAccount} " +
                $"At {options.TransferDate.ToShortDateString()} " +
                $"With Amount : {options.Amount}");
        }
    }

    public class PayPalTransfer : ITransferMoney
    {
        public void TransferMoney(PaymentOptions options)
        {
            Console.WriteLine($"Transfering money with PayPal " +
                $"{options.SourceAccount} " +
                $"To {options.DestinationAccount} " +
                $"At {options.TransferDate.ToShortDateString()} " +
                $"With Amount : {options.Amount}");
        }
    }

    public class FastTransfer : ITransferMoney
    {
        public void TransferMoney(PaymentOptions options)
        {
            Console.WriteLine($"Transfering money with Fast " +
                $"{options.SourceAccount} " +
                $"To {options.DestinationAccount} " +
                $"At {options.TransferDate.ToShortDateString()} " +
                $"With Amount : {options.Amount}");
        }
    }

    public class MoneyTransfer
    {
        private ITransferMoney _transferMoney;

        public MoneyTransfer(ITransferMoney transferMoney)
        {
            _transferMoney = transferMoney;
        }

        public MoneyTransfer() { }

        public void SetAttackStrategy(ITransferMoney transferMoney)
        {
            _transferMoney = transferMoney;
        }

        public void TransferMoney(PaymentOptions options)
        {
            _transferMoney.TransferMoney(options);
        }
    }

    public static class BankMoneyTransferExample
    {
        public static void RunSample()
        {
            do
            {

            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }
    }
}
