﻿using Infrastructure.Kernel.Result;
using FastEndpoints;
using Identity.Application.Services;
using MediatR;

namespace Identity.API.Endpoint
{

    public class GetUserEndPoint : Endpoint<GetUserRequest, IResult>
    {
        private readonly IMediator _mediator;
        public GetUserEndPoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override void Configure()
        {
            Get("identity/getuser");
			//Roles(Role.Admin.Name);
			AllowAnonymous();
		}

        public override async Task HandleAsync(GetUserRequest request, CancellationToken ct)
        {
			var result = await _mediator.Send(request, ct);
			await SendResultAsync(result.ToHttpResult());
        }
    }

    //[AllowAnonymous]
    //[HttpPost("get-user")]
    //public class GetUserEndPoint : BaseEndpoint.With<GetUserRequest, IResult>
    //{

    //    private readonly IMediator _mediator;
    //    public GetUserEndPoint(IMediator mediator)
    //    {
    //        _mediator = mediator;
    //    }

    //    public override async Task<IResult> HandleAsync(GetUserRequest request, CancellationToken ct = default)
    //    {
    //        var result = await _mediator.Send(request, ct);
    //        return result.ToHttpResult();
    //    }
    //}
}
