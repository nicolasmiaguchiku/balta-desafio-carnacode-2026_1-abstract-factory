using AbstractFactory.Factories;
using AbstractFactory.Services;

namespace AbstractFactory
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Sistema de Pagamentos ===\n");

            var factoryStripe = GatewayPaymentFactory.Create("stripe");
            var stripeService = new PaymentService(factoryStripe);
            stripeService.ProcessPayment(150.00m, "1234567890123456");

            Console.WriteLine();

            var factorymercadoPago = GatewayPaymentFactory.Create("mercadopago");
            var mercadoPagoService = new PaymentService(factorymercadoPago);
            mercadoPagoService.ProcessPayment(200.00m, "5234567890123456");

            Console.WriteLine();
        }
    }
}
