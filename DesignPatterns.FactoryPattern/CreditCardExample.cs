namespace DesignPatterns.FactoryPattern;

public static class CreditCardExample
{
    public interface ICreditCard
    {
        string GetCardType();
        int GetCreditLimit();
        int GetAnnualCharge();
    }

    public abstract class CreditCardFactory
    {
        protected abstract ICreditCard MakeProduct();

        public string CreateProduct()
        {
            var creditCard = this.MakeProduct();

            var result = $"Card Type : {creditCard.GetCardType()} / Card Limit : {creditCard.GetCreditLimit()} / Annual Charge: {creditCard.GetAnnualCharge()}";

            return result;
        }
    }

    public class MoneyBackFactory : CreditCardFactory
    {
        protected override ICreditCard MakeProduct()
        {
            return new MoneyBack();
        }
    }

    public class TitaniumFactory : CreditCardFactory
    {
        protected override ICreditCard MakeProduct()
        {
            return new Titanium();
        }
    }

    public class PlatinumFactory : CreditCardFactory
    {
        protected override ICreditCard MakeProduct()
        {
            return new Platinum();
        }
    }

    public class MoneyBack : ICreditCard
    {
        public int GetAnnualCharge()
        {
            return 500;
        }

        public string GetCardType()
        {
            return "MoneyBack";
        }

        public int GetCreditLimit()
        {
            return 15000;
        }
    }

    public class Titanium : ICreditCard
    {
        public int GetAnnualCharge()
        {
            return 1500;
        }

        public string GetCardType()
        {
            return "Titanium Edge";
        }

        public int GetCreditLimit()
        {
            return 25000;
        }
    }

    public class Platinum : ICreditCard
    {
        public int GetAnnualCharge()
        {
            return 2000;
        }

        public string GetCardType()
        {
            return "Platinum Plus";
        }

        public int GetCreditLimit()
        {
            return 35000;
        }
    }

    public static void RunSample()
    {
        var moneyBackFactory = new MoneyBackFactory();
        var titaniumFactory = new TitaniumFactory();
        var platinumFactory = new PlatinumFactory();

        Console.WriteLine(moneyBackFactory.CreateProduct());
        Console.WriteLine(titaniumFactory.CreateProduct());
        Console.WriteLine(platinumFactory.CreateProduct());
    }



}
