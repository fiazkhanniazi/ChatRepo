using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    internal sealed class AccountRepository : IAccountRepository
    {
        private readonly RepositoryDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountRepository(RepositoryDbContext dbContext, UserManager<IdentityUser> userManager,
                              SignInManager<IdentityUser> signInManager) {

            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;

        } 

    


        public async Task<string> ResgisterAsync(RegisterViewModel model, CancellationToken cancellationToken = default)
        {
           
            try
            {
                var user = new IdentityUser
                {
                    UserName = model.Name,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                   
                }

                return result.Succeeded ? result.ToString() : result.ToString();
            }
            catch(Exception ex)
            {
                throw ;
            }

            
        }
        //await _dbContext.Accounts.Where(x => x.OwnerId == ownerId).ToListAsync(cancellationToken);

        public async Task<bool> LoginAsync(LoginViewModel user, CancellationToken cancellationToken = default) {
           
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                return true;
                }

            return false;

           
        }

    }
}
