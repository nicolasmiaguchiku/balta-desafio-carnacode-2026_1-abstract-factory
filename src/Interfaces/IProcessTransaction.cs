namespace AbstractFactory.Interfaces
{
    /// <summary>
    ///     Abstract Product Process Transaction
    /// </summary>
    public interface IProcessTransaction
    {
        string ProcessTransaction(decimal amount, string cardNumber);
    }
}