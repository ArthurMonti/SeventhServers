﻿using MediatR;

namespace SeventhServers.Domain.UseCases.Servers.Get;

public class GetServerRequestModel : IRequest<Result<GetServerResponseModel>>
{
    public Guid serverId { get; init; }
}
