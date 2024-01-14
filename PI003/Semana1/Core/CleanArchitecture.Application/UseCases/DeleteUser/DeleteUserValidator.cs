using System.Security.Cryptography.X509Certificates;
using FluentValidation;

namespace CleanArchitecture.Application.UseCases.DeleteUser;

public class DeleteUserValidator : AbstractValidator<DeleteUserRequest>
{
    public DeleteUserValidator(){
    RuleFor(x=>x.Id).NotEmpty();
    }
}
