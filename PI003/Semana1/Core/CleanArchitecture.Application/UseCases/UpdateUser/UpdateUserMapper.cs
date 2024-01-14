using AutoMapper;
using CleanArchitecture.Application.UseCases.CreateUser;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.UpdateUser;

public class UpdateUserMapper : Profile
{
    public UpdateUserMapper(){
        CreateMap<UpdateUserRequest, User>();
        CreateMap<User, UpdateUserResponse>();
    }

}
