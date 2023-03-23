using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{

    public interface IAsyncCommandHandler<in TCommand> 
    {
        Task HandleAsync(TCommand command);
    }
}

