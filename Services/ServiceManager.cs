using System;
using Domain.Repositories;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;
        public ServiceManager(IRepositoryManager repositoryManager,IBus bus, IHubContext<ChatService> context, HttpContextAccessor httpContex)
        {
            _bus = bus;
            _lazyChatService = new Lazy<IChatService>(() => new ChatService(repositoryManager, _bus, context, httpContex));
            _lazyAccountService = new Lazy<IAccountService>(() => new AccountService(repositoryManager));
        }

        public IChatService ChatService => _lazyChatService.Value;

        public IAccountService AccountService => _lazyAccountService.Value;
    }
}
