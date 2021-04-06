using System;
using MercadoPago.Client.AdvancedPayment;
using MercadoPago.Client.CardToken;
using MercadoPago.Client.Customer;
using MercadoPago.Client.IdentificationType;
using MercadoPago.Client.MerchantOrder;
using MercadoPago.Client.OAuth;
using MercadoPago.Client.Payment;
using MercadoPago.Client.PaymentMethod;
using MercadoPago.Client.Preapproval;
using MercadoPago.Client.Preference;
using MercadoPago.Client.User;
using MercadoPago.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace MercadoPago.DependencyInjection.Tests
{
    [TestFixture]
    public class MercadoPagoDependencyInjectionTest
    {
        private ServiceProvider _serviceProvider;
        
        [SetUp]
        public void Setup()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            ServiceCollection services = new ServiceCollection();
            services.AddSingleton(configuration);
            services.AddMercadoPago(configuration);

            _serviceProvider = services.BuildServiceProvider();
        }

        [Test]
        public void CheckServiceProvider()
        {
            Assert.IsNotNull(_serviceProvider);
        }

        [Test]
        public void CheckMercadoPagoSettings()
        {
            var accessToken = MercadoPagoConfig.AccessToken;
            Assert.IsNotNull(accessToken);
            Assert.IsNotEmpty(accessToken);
            Assert.AreEqual("ACCESS_TOKEN", accessToken, "The access token was not loaded correctly");

            var corporationId = MercadoPagoConfig.CorporationId;
            Assert.IsNotNull(corporationId);
            Assert.IsNotEmpty(corporationId);
            Assert.AreEqual("CORPORATION_ID", corporationId, "The corporation id was not loaded correctly");

            var integratorId = MercadoPagoConfig.IntegratorId;
            Assert.IsNotNull(integratorId);
            Assert.IsNotEmpty(integratorId);
            Assert.AreEqual("INTEGRATOR_ID", integratorId, "The integrator id was not loaded correctly");

            var platformId = MercadoPagoConfig.PlatformId;
            Assert.IsNotNull(platformId);
            Assert.IsNotEmpty(platformId);
            Assert.AreEqual("PLATFORM_ID", platformId, "The integrator id was not loaded correctly");
        }

        [Test]
        [TestCase(typeof(AdvancedPaymentClient))]
        [TestCase(typeof(CardTokenClient))]
        [TestCase(typeof(CustomerCardClient))]
        [TestCase(typeof(CustomerClient))]
        [TestCase(typeof(IdentificationTypeClient))]
        [TestCase(typeof(MerchantOrderClient))]
        [TestCase(typeof(OAuthClient))]
        [TestCase(typeof(PaymentClient))]
        [TestCase(typeof(PaymentRefundClient))]
        [TestCase(typeof(PaymentMethodClient))]
        [TestCase(typeof(PreapprovalClient))]
        [TestCase(typeof(PreferenceClient))]
        [TestCase(typeof(UserClient))]
        public void CheckMercadoPagoClients(Type serviceType)
        {
            var mercadoPagoClient = _serviceProvider.GetService(serviceType);
            Assert.IsNotNull(mercadoPagoClient);
        }
    }
}