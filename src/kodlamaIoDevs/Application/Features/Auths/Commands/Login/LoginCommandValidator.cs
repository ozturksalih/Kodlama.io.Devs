using FluentValidation;

namespace Application.Features.Auths.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(u => u.UserForLoginDto.Email).NotEmpty();
            RuleFor(u => u.UserForLoginDto.Email).NotEqual("string");
            RuleFor(u => u.UserForLoginDto.Email).Matches("@").WithMessage("Entered email is not a email!");
        }
    }
}
