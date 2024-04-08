﻿using Core.Autofac;
using Core.Contract;
using Core.Infrastructure;
using Core.Result;
using Identity.Application.Abstractions;
using Identity.Application.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Services
{
    public class Login : IRequestHandler<LoginRequest, AppResult<string>>, ITransient
    {
        private readonly IAppDbContext _context;
        private readonly IJwtProvider _jwtProvider;
        private readonly IExternalProducer _producer;
        public Login(IAppDbContext context, IJwtProvider jwtProvider, IExternalProducer producer)
        {
            _context = context;
            _jwtProvider = jwtProvider;
            _producer = producer;
        }
        public async Task<AppResult<string>> Handle(
            LoginRequest request, 
            CancellationToken ct)
        {
            var user = await _context.Users
                .Where(x => x.UserName == request.UserName)
                .SingleOrDefaultAsync();

            if (user == null)
                return AppResult.NotFound("User name or password not match!");

            var hashPassword = PasswordExtension.GeneratePassword(request.Password, user.SecurityStamp);
            if (!user.PasswordHash.Equals(hashPassword.Password))
                return AppResult.Forbidden();

            var token = _jwtProvider.Genereate(user!);
            await _producer.PublishAsync(new HelloEvent("Hello employee, i'm identity"));

            return AppResult.Success(token);
        }
    }
}