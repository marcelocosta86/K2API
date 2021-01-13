using MediatR;

namespace K2.Desafio.Application
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}