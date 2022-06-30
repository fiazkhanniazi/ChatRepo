using System;
using Domain.Repositories;

using Microsoft.AspNetCore.Identity;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IChatRepository> _lazyChatRepository;
        private readonly Lazy<IAccountRepository> _lazyAccountRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(RepositoryDbContext dbContext, UserManager<IdentityUser> userManager,
                              SignInManager<IdentityUser> signInManager)
        {
            _lazyChatRepository = new Lazy<IChatRepository>(() => new ChatRepository(dbContext));
            _lazyAccountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(dbContext,userManager,signInManager));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        }

        public IChatRepository ChatRepository => _lazyChatRepository.Value;

        public IAccountRepository AccountRepository => _lazyAccountRepository.Value;

        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }
}
