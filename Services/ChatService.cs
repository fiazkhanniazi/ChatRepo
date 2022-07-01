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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Services.Abstractions;
using Microsoft.AspNetCore.Identity;


namespace Services
{
    public sealed class ChatService : Hub, IChatService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IBus _bus;
        private IHubContext<ChatService> _context;
      
        private readonly IHttpContextAccessor _httpContex;
        private readonly HttpClient _client;
        public ChatService(IRepositoryManager repositoryManager, IBus bus, IHubContext<ChatService> context, IHttpContextAccessor httpContex)
        {
            _repositoryManager = repositoryManager;
            _bus = bus;
            _context = context;
            _client = new HttpClient();
            _httpContex = httpContex;
           
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
                    

                    return await _repositoryManager.ChatRepository.SendMessageAsync(input);
                    

                }
                else
                {
                    await _context.Clients.All.SendAsync("ReceiveMessage", input);
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
            await _context.Clients.All.SendAsync("ReceiveMessage", data);

         
        }
        
        public async Task<SendRecieveMessageViewModel> RecieveMessageAsync(SendRecieveMessageViewModel input)
        {
            return await _repositoryManager.ChatRepository.RecieveMessage(input);
        }


    }
}