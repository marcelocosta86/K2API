namespace K2.Desafio.Application.Configuration.DomainEvents
{
    public interface IDomainEventNotification<out TEventType>
    {
        TEventType DomainEvent { get; }
    }
}