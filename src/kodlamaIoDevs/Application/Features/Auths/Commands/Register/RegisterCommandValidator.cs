using Application.Features.Auths.Commands.RegisterMember;
using FluentValidation;

namespace Application.Features.Auths.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {

            RuleFor(u => u.UserForRegisterDto.Email).NotEmpty();
            RuleFor(u => u.UserForRegisterDto.Email).NotEqual("string");
            RuleFor(u => u.UserForRegisterDto.Email).Matches("@").WithMessage("Entered email is not a email!");
            RuleFor(u => u.UserForRegisterDto.Password)
                .NotEmpty().WithMessage("Entered Password is empty!")
                .MinimumLength(8).WithMessage("Entered password doesn't meet required minimum length!")
                .Matches("[A-Z]").WithMessage("Password must have at least one Uppercase Letter")
                .Matches("[a-z]").WithMessage("Password must have at least one Lowercase Letter")
                .Matches("[0-9]").WithMessage("Password must have at least one number")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must have at least one special character");
            RuleFor(u => u.UserForRegisterDto.FirstName).NotEmpty();
            RuleFor(u => u.UserForRegisterDto.LastName).NotEmpty();
        }
    }
}
