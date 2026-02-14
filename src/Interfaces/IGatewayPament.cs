namespace AbstractFactory.Interfaces
{
    /// <summary>
    ///     Abstract Factoty
    /// </summary>
    public interface IGatewayPament
    {
        ILogger Log();
        IProcessTransaction ProcessTransaction();
        IValidateCard ValidateCard();
    }
}