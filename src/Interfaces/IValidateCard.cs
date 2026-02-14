namespace AbstractFactory.Interfaces
{
    /// <summary>
    ///     Abstract Product Validate Card
    /// </summary>
    public interface IValidateCard
    {
        bool ValidateCard(string cardNumber);
    }
}