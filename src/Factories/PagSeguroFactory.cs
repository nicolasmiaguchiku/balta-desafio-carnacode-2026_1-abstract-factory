using AbstractFactory.Interfaces;

namespace AbstractFactory.Factories
{
    public class PagSeguroFactory : IGatewayPayment
    {
        public ILogger CreateLogService() => new PagSeguroLogger();
        public IProcessTransaction CreateProcessTransactionService() => new PagSeguroProcessTransaction();
        public IValidateCard CreateValidateCardService() => new PagSeguroValidateCard();

        public sealed class PagSeguroValidateCard() : IValidateCard
        {
            public bool ValidateCard(string cardNumber)
            {
                Console.WriteLine("PagSeguro: Validando cartão...");
                return cardNumber.Length == 16;
            }
        }

        public sealed class PagSeguroProcessTransaction() : IProcessTransaction
        {
            public string ProcessTransaction(decimal amount, string cardNumber)
            {
                Console.WriteLine($"PagSeguro: Processando R$ {amount}...");
                return $"PAGSEG-{Guid.NewGuid().ToString().Substring(0, 8)}";
            }
        }

        public sealed class PagSeguroLogger() : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine($"[PagSeguro Log] {DateTime.Now}: {message}");
            }
        }
    }
}