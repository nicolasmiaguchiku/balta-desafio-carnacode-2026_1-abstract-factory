namespace AbstractFactory.Interfaces
{
    /// <summary>
    ///     Abstract Factory
    /// </summary>
    public interface IGatewayPayment
    {
        ILogger CreateLogService();
        IProcessTransaction CreateProcessTransactionService();
        IValidateCard CreateValidateCardService();
    }
}