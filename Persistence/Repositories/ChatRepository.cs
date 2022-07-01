using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using Domain.Entities;
using Domain.Repositories;


namespace Persistence.Repositories
{
    internal sealed class ChatRepository : IChatRepository
    {
        private readonly RepositoryDbContext _dbContext;
        //private readonly IBus _bus;
        public ChatRepository(RepositoryDbContext dbContext)
        {
            _dbContext = dbContext;
           // _bus = bus;
        }

        public async Task<string> SendMessageAsync(SendRecieveMessageViewModel input)
        {
           

            return "Sent to queue";

        }


        

        public async Task<SendRecieveMessageViewModel> RecieveMessage(SendRecieveMessageViewModel context)
        {
            return context;
        }
    }
}
