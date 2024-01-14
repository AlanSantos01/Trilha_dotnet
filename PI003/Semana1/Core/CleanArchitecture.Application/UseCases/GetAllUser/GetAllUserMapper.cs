namespace CleanArchitecture.Application.UseCases.GetAllUser;
using AutoMapper;
using CleanArchitecture.Application.UseCases.CreateUser;
using CleanArchitecture.Domain.Entities;
public sealed class GetAllUserMapper : Profile
{
    public GetAllUserMapper(){
        CreateMap<User, GetAllUserResponse>();

    }
}
