using AbstractFactory.Interfaces;

namespace AbstractFactory.Factories
{
    public class StripeFactory() : IGatewayPayment
    {
        public ILogger CreateLogService() => new StripeLogger();
        public IProcessTransaction CreateProcessTransactionService() => new StripeProcessTransaction();
        public IValidateCard CreateValidateCardService() => new StripeValidateCard();

        public sealed class StripeValidateCard() : IValidateCard
        {
            public bool ValidateCard(string cardNumber)
            {
                Console.WriteLine("Stripe: Validando cartão...");
                return cardNumber.Length == 16 && cardNumber.StartsWith("4");
            }
        }

        public sealed class StripeProcessTransaction() : IProcessTransaction
        {
            public string ProcessTransaction(decimal amount, string cardNumber)
            {
                Console.WriteLine($"Stripe: Processando ${amount}...");
                return $"STRIPE-{Guid.NewGuid().ToString().Substring(0, 8)}";
            }
        }

        public sealed class StripeLogger() : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine($"[Stripe Log] {DateTime.Now}: {message}");
            }
        }
    }
}