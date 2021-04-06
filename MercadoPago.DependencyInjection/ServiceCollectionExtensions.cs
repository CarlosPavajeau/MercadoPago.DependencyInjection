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

namespace MercadoPago.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMercadoPago(this IServiceCollection services, IConfiguration configuration)
        {
            LoadMercadoPagoConfiguration(configuration);
            ScopeClients(services);

            return services;
        }

        private static void LoadMercadoPagoConfiguration(IConfiguration configuration)
        {
            string accessToken = configuration["MercadoPago:AccessToken"];
            if (!string.IsNullOrEmpty(accessToken))
            {
                MercadoPagoConfig.AccessToken = accessToken;
            }

            string corporationId = configuration["MercadoPago:CorporationId"];
            if (!string.IsNullOrEmpty(corporationId))
            {
                MercadoPagoConfig.CorporationId = corporationId;
            }

            string integratorId = configuration["MercadoPago:IntegratorId"];
            if (!string.IsNullOrEmpty(integratorId))
            {
                MercadoPagoConfig.IntegratorId = integratorId;
            }

            string platformId = configuration["MercadoPago:PlatformId"];
            if (!string.IsNullOrEmpty(platformId))
            {
                MercadoPagoConfig.PlatformId = platformId;
            }
        }

        private static void ScopeClients(IServiceCollection services)
        {
            services.AddScoped(typeof(AdvancedPaymentClient));
            services.AddScoped(typeof(CardTokenClient));
            services.AddScoped(typeof(CustomerCardClient));
            services.AddScoped(typeof(CustomerClient));
            services.AddScoped(typeof(IdentificationTypeClient));
            services.AddScoped(typeof(MerchantOrderClient));
            services.AddScoped(typeof(OAuthClient));
            services.AddScoped(typeof(PaymentClient));
            services.AddScoped(typeof(PaymentRefundClient));
            services.AddScoped(typeof(PaymentMethodClient));
            services.AddScoped(typeof(PreapprovalClient));
            services.AddScoped(typeof(PreferenceClient));
            services.AddScoped(typeof(UserClient));
        }
    }
}