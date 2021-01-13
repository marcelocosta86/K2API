using System.Threading.Tasks;
using MediatR;

namespace K2.Desafio.Application.Configuration.Processing
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync(IRequest command);
    }
}