using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Mapster;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using Services.Abstractions;

namespace Services
{
    public sealed class ChatService : Hub, IChatService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IBus _bus;
        private IHubContext<ChatService> _context;

        private readonly HttpClient _client;
        public ChatService(IRepositoryManager repositoryManager, IBus bus, IHubContext<ChatService> context)
        {
            _repositoryManager = repositoryManager;
            _bus = bus;
            _context = context;
            _client =new HttpClient();
        }


        public async Task<string> SendMessageAsync(SendRecieveMessageViewModel input)
        {
            try
            {
                if (input.Message.StartsWith("/stock="))
                {
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(input);
                    var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                    var url = "https://localhost:44366/Bot";
                    var response = await _client.PostAsync(url, data);
                    var result = response.Content.ReadAsStringAsync().Result;
                    input.Message = result;
                    input.DateTime = DateTime.Now;
                    Uri uri = new Uri("rabbitmq://localhost/chatQueue");
                    var endPoint = await _bus.GetSendEndpoint(uri);
                    await endPoint.Send(input);

                    return await _repositoryManager.ChatRepository.SendMessageAsync(input);
                    

                }
                else
                {
                    await _context.Clients.All.SendAsync("ReceiveMessage", input.TargetUserName, input.Message);
                }

                
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

            return "sent to queue";
        }
        public async Task Consume(ConsumeContext<SendRecieveMessageViewModel> context)
        {
            var data = context.Message;
         
            await RecieveMessageAsync(data);
            await _context.Clients.All.SendAsync("ReceiveMessage", data.TargetUserName, data.Message);

         
        }
        
        public async Task<SendRecieveMessageViewModel> RecieveMessageAsync(SendRecieveMessageViewModel input)
        {
            return await _repositoryManager.ChatRepository.RecieveMessage(input);
        }


    }
}