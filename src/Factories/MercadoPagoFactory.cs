using AbstractFactory.Interfaces;

namespace AbstractFactory.Factories
{
    public class MercadoPagoFactory : IGatewayPayment
    {
        public ILogger CreateLogService() => new MercadoPagoLogger();
        public IProcessTransaction CreateProcessTransactionService() => new MercadoPagoProcessTransaction();
        public IValidateCard CreateValidateCardService() => new MercadoPagoValidateCard();

        public sealed class MercadoPagoValidateCard() : IValidateCard
        {
            public bool ValidateCard(string cardNumber)
            {
                Console.WriteLine("MercadoPago: Validando cartão...");
                return cardNumber.Length == 16 && cardNumber.StartsWith("5");
            }
        }

        public sealed class MercadoPagoProcessTransaction() : IProcessTransaction
        {
            public string ProcessTransaction(decimal amount, string cardNumber)
            {
                Console.WriteLine($"MercadoPago: Processando R$ {amount}...");
                return $"MP-{Guid.NewGuid().ToString().Substring(0, 8)}";
            }
        }

        public sealed class MercadoPagoLogger() : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine($"[MercadoPago Log] {DateTime.Now}: {message}");
            }
        }
    }
}