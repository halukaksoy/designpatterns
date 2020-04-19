using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        { 
            var context = new PaymentContext(new CreditCardPayment(), new Receipt(9));
            Console.WriteLine("***");
            context = new PaymentContext(new CashPayment(), new Receipt(11));
            Console.ReadLine();
        }
    }
    //Abstract Product 
    abstract class PaymentMethod
    {
        public abstract void Checkout(decimal amount);
    }

    //Concerete Product
    class CreditCart : PaymentMethod
    {
        public override void Checkout(decimal amount)
        {
            Console.WriteLine($"CreditCard Checkout Completed: {amount}");
        }
    }
    //Concrete Product
    class Cash : PaymentMethod
    {
        public override void Checkout(decimal amount)
        {
            Console.WriteLine($"Cash Checkout Completed: {amount}");
        }
    }

    //AbstractProduct
    abstract class Invoice
    {
        public abstract void GetInvoice(decimal amount);
    }

    //Concrete Product
    class OnlineInvoice : Invoice
    {
        public override void GetInvoice(decimal amount)
        {
            Console.WriteLine($"EInvoice Ready: {amount}");
        }
    }
    //Concrete Product
    class PrintableInvoice : Invoice
    {
        public override void GetInvoice(decimal amount)
        {
            Console.WriteLine($"PrintableInvoice Ready: {amount}");
        }
    }

    //Abstract Factory
    abstract class PaymentFactory
    {
        public abstract PaymentMethod Payment();
        public abstract Invoice Invoice();
    }
    //Concrete Factory
    class CreditCardPayment : PaymentFactory
    {
        public override PaymentMethod Payment() => new CreditCart();
        public override Invoice Invoice() => new OnlineInvoice();
    }
    //Concrete Factory
    class CashPayment : PaymentFactory
    {
        public override PaymentMethod Payment() => new Cash();
        public override Invoice Invoice() => new PrintableInvoice();
    }
    class Receipt
    {
        decimal _amount;
        public Receipt(decimal amount)
        {
            _amount = amount;
        }
        public decimal GetAmount()
        {
            return _amount;
        }
    }
    //Context
    class PaymentContext
    {
        PaymentFactory _paymentFactory;
        PaymentMethod _paymentMethod;
        Invoice _invoice;
        public PaymentContext(PaymentFactory paymentFactory, Receipt receipt)
        {
            _paymentFactory = paymentFactory;
            _paymentMethod = paymentFactory.Payment();
            _invoice = paymentFactory.Invoice();

            ApplyPayment(receipt);
        }

        private void ApplyPayment(Receipt receipt)
        {
            _paymentMethod.Checkout(receipt.GetAmount());
            _invoice.GetInvoice(receipt.GetAmount());
        }
    }
}
