using MediatR;
using Newtonsoft.Json;

namespace K2.Desafio.Application.Configuration.DomainEvents
{
    public class DomainNotificationBase<T> : IDomainEventNotification<T>, INotification
    {
        [JsonIgnore]
        public T DomainEvent { get; }

        public DomainNotificationBase(T domainEvent)
        {
            this.DomainEvent = domainEvent;
        }
    }
}