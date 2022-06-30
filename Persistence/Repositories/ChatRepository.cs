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
            //try
            //{
            //    if (input != null)
            //    {
            //        input.DateTime = DateTime.Now;
            //        Uri uri = new Uri("rabbitmq://localhost/ticketQueue");
            //        var endPoint = await _bus.GetSendEndpoint(uri);
            //        await endPoint.Send(input);

            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}

            return "Sent to queue";

        }


        //public async Task Consume(ConsumeContext<SendRecieveMessageDTO> context)
        //{
        //    var data = context.Message;
        //    //Validate the Ticket Data
        //    //Store to Database
        //    //Notify the user via Email / SMS
        //  await  RecieveMessage(data);
        //}

        public async Task<SendRecieveMessageViewModel> RecieveMessage(SendRecieveMessageViewModel context)
        {
            return context;
        }
    }
}
