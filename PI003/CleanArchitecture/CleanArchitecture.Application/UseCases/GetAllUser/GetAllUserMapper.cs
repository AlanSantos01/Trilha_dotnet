using AutoMapper;
using CleanArchitecture.Application.UseCases.GetAllUser;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application;

public class GetAllUserMapper : Profile
{
    public GetAllUserMapper()
    {
        CreateMap<User, GetAllUserResponse>();
    }

}
