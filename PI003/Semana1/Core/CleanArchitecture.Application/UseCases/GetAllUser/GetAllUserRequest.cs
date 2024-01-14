namespace CleanArchitecture.Application.UseCases.GetAllUser;
using MediatR;
public sealed record GetAllUserRequest : IRequest<List<GetAllUserResponse>>;

