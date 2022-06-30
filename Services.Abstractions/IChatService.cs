using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using MassTransit;

namespace Services.Abstractions
{
    public interface IChatService : IConsumer<SendRecieveMessageViewModel>
    {

        
        Task<string> SendMessageAsync(SendRecieveMessageViewModel input);
        Task<SendRecieveMessageViewModel> RecieveMessageAsync(SendRecieveMessageViewModel input);

    }
}