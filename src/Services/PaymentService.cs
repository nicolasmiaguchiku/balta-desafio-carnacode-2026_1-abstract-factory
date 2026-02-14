using AbstractFactory.Interfaces;

namespace AbstractFactory.Services
{
    public class PaymentService(IGatewayPayment factory)
    {
        private readonly ILogger _logger = factory.CreateLogService();
        private readonly IProcessTransaction _processTransaction = factory.CreateProcessTransactionService();
        private readonly IValidateCard _ValidCard = factory.CreateValidateCardService();

        public void ProcessPayment(decimal amount, string cardNumber)
        {
            if (!_ValidCard.ValidateCard(cardNumber))
            {
                _logger.Log($"Cartão inválido: {cardNumber}");
                return;
            }

            var processTransactionResult = _processTransaction.ProcessTransaction(amount, cardNumber);
            _logger.Log($"Transação processada: {processTransactionResult}");

            return;
        }
    }
}