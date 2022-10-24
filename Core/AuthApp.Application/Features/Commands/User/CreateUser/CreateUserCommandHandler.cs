using AuthApp.Application.Exceptions;
using AuthApp.Domain.Entitites.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult result = await _userManager.CreateAsync(new() { 
                Id = Guid.NewGuid().ToString(),
                NameSurname = request.NameSurname,
                Email = request.Email,
                UserName = request.UserName,
            }, request.Password) ; 

            CreateUserCommandResponse response = new() { Succeeded = result.Succeeded };
            if (result.Succeeded)
            {
                response.Message = "Successfully Created User";
            }
            else
            {
                foreach(var error in result.Errors)
                {
                    response.Message += $"{error.Code} - {error.Description}\n\n";
                }
            }
            return response;
            //throw new CreateUserFailedException();
        } 
    }
}
