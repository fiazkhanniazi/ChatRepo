using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contracts;

namespace Services.Abstractions
{
    public interface IAccountService
    {
        

        Task<bool> LoginAsync(LoginViewModel model, CancellationToken cancellationToken);

        Task<string> RegisterAsync(RegisterViewModel model, CancellationToken cancellationToken = default);

      
    }
}