using AuthApp.Application.Abstraction;
using AuthApp.Application.DTOs;
using AuthApp.Application.Exceptions;
using AuthApp.Domain.Entitites.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Application.Features.Commands.User.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;

        public LoginUserCommandHandler(
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
            ITokenHandler tokenHandler)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.FindByNameAsync(request.EmailorUserName); // username kısmını kontrol ediyor
            if(user == null)
            {
               user = await _userManager.FindByEmailAsync(request.EmailorUserName); // username kısmı null ise email kısmını kontrol edecek.
            }
            if (user == null) // demek ki username ve mailin ikisi de yanlıs ki null
            {
                throw new InvalidPasswordOrEmailException("Invalid password or email");
            }
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false); // identity mekanızmasından gelen bir method kullanıcı adını ve şifreyi karşıalştırıp doğru mu kontrol ediyor false kısmı ise 3 kere denemeden sonra kitlensin mi gib sorgulamaları yapıyor şimdilik false

            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken(5);
                return new LoginUserSuccessCommandResponse()
                {
                    Token = token,
                    Id = user.Id
                };
            }
            else
            {
                throw new AuthenticationErrorException("Failed Authentication");
            }
            
        }
    }
}
