using System;
using ChargeBee.Api;
using ChargeBee.Models;

namespace chargebee
{
    internal class Program
    {
        private static void Main()
        {
            //Create an unique Id
            Console.WriteLine("Hello ChargeBee!");
            var id = DateTime.Now.ToFileTimeUtc();
            
            //Configure the api key
            ApiConfig.Configure("vy-nguyen-synova-solutions-test", "test_dklkLk8x56L5HWvr6KXYs8Nhx8ABadJv");

            //Create a plan
            Console.WriteLine("Creating a plan...");
            var result = Plan.Create()
                .Id("plan" + id)
                .Name("Plan" + id)
                .InvoiceName("sample plan")
                .Price(5000).Request();
            var plan = result.Plan;

            //Create a customer
            Console.WriteLine("Creating a customer...");
            var result2 = Customer.Create()
                .Id("customer" + id)
                .FirstName("Customer")
                .LastName("Doe")
                .Email("john@user.com")
                .Locale("fr-CA")
                .BillingAddressFirstName("John")
                .BillingAddressLastName("Doe")
                .BillingAddressLine1("PO Box 9999")
                .BillingAddressCity("Walnut")
                .BillingAddressState("California")
                .BillingAddressZip("91789")
                .BillingAddressCountry("US").Request();
            var customer = result2.Customer;
            var card = result2.Card;

            //Create a subscription
            Console.WriteLine("Creating a subscription...");
            var result3 = Subscription.Create()
                .PlanId("plan" + id)
                .Id("subscription" + id)
                .CustomerEmail("john@user.com")
                .CustomerFirstName("John")
                .CustomerLastName("Doe")
                .CustomerLocale("fr-CA")
                .CustomerPhone("+1-949-999-9999")
                .BillingAddressFirstName("John")
                .BillingAddressLastName("Doe")
                .BillingAddressLine1("PO Box 9999")
                .BillingAddressCity("Walnut")
                .BillingAddressState("California")
                .BillingAddressZip("91789")
                .BillingAddressCountry("US")
                .AddonId(1, "cbdemo_conciergesupport").Request();
            var subscription = result3.Subscription;
            var customer2 = result3.Customer;
            var card2 = result3.Card;
            var invoice = result3.Invoice;
            var unbilledCharge = result3.UnbilledCharge;

            Console.ReadLine();
        }
    }
}
