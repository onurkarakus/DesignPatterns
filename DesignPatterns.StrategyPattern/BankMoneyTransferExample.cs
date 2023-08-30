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
                Console.WriteLine("Please select transfer type:");
                Console.WriteLine("1. Bank Transfer");
                Console.WriteLine("2. PayPal Transfer");
                Console.WriteLine("3. Fast Transfer");

                ITransferMoney transferMoney = null;

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        transferMoney = new BankTransfer();
                        break;
                    case ConsoleKey.D2:
                        transferMoney = new PayPalTransfer();
                        break;
                    case ConsoleKey.D3:
                        transferMoney = new FastTransfer();
                        break;
                    default:
                        Console.WriteLine("Invalid Selection");
                        break;
                }

                Console.WriteLine();

                if (transferMoney != null)
                {
                    var moneyTransfer = new MoneyTransfer(transferMoney);

                    moneyTransfer.TransferMoney(new PaymentOptions
                    {
                        Amount = 100,
                        DestinationAccount = "123456789",
                        SourceAccount = "987654321",
                        TransferDate = DateTime.Now
                    });                    
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }
    }
}
