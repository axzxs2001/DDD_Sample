using Infrastructure.Common.Event;
using Microsoft.Extensions.DependencyInjection;


namespace Domain
{
    public static class DomainServiceExtension
    {
        public static void AddDomainService(this IServiceCollection services)
        {            
            services.AddScoped<IEventPublisher, EventPublisher>();
        }
    }
}
