using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Mapster;
using Services.Abstractions;

namespace Services
{
    internal sealed class AccountService : IAccountService
    {
        private readonly IRepositoryManager _repositoryManager;

        public AccountService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<bool> LoginAsync(LoginViewModel model, CancellationToken cancellationToken = default)
        {
            return await _repositoryManager.AccountRepository.LoginAsync(model, cancellationToken);


        }



        public async Task<string> RegisterAsync(RegisterViewModel model, CancellationToken cancellationToken = default)
        {
            try
            {
                var owner = await _repositoryManager.AccountRepository.ResgisterAsync(model, cancellationToken);


                await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                return owner;
            }catch(Exception ex)
            {
                throw ;
            }
        }

    }
}
