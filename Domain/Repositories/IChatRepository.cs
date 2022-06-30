using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IChatRepository 
    {
        Task<string> SendMessageAsync(SendRecieveMessageViewModel input);
        Task<SendRecieveMessageViewModel> RecieveMessage(SendRecieveMessageViewModel context);

    }
}
