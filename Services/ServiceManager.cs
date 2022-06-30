using System;
using Domain.Repositories;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using Services.Abstractions;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IChatService> _lazyChatService;
        private readonly Lazy<IAccountService> _lazyAccountService;
        private readonly IBus _bus;
        private IHubContext<ChatService> _context;
        public ServiceManager(IRepositoryManager repositoryManager,IBus bus)
        {
            _bus = bus;
            _lazyChatService = new Lazy<IChatService>(() => new ChatService(repositoryManager, _bus, _context));
            _lazyAccountService = new Lazy<IAccountService>(() => new AccountService(repositoryManager));
        }

        public IChatService ChatService => _lazyChatService.Value;

        public IAccountService AccountService => _lazyAccountService.Value;
    }
}
