using AbstractFactory.ConcretesFactory;
using AbstractFactory.Interfaces;

namespace AbstractFactory.Factories
{
    public static class GatewayPaymentFactory
    {
        public static IGatewayPayment Create(string gateway)
        {
            return gateway.ToLower() switch
            {
                "stripe" => new StripeFactory(),
                "pagseguro" => new PagSeguroFactory(),
                "mercadopago" => new MercadoPagoFactory(),
                _ => throw new ArgumentException("Gateway não suportado")
            };
        }
    }
}
