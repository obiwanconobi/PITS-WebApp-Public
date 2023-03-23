using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IAsyncRequestHandler<in TRequest, TResponse> //where TRequest : IRequest
    {
        Task<TResponse> HandleAsync(TRequest request);
    }
}
