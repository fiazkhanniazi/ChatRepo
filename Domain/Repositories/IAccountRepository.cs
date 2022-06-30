using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IAccountRepository
    {
         Task<string> ResgisterAsync(RegisterViewModel model, CancellationToken cancellationToken = default);
         Task<bool> LoginAsync(LoginViewModel user, CancellationToken cancellationToken = default);
        
     }
}
