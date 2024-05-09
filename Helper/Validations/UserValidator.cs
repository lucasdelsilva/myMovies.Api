using FluentValidation;
using MyMovies.Api.DTOs;
using System.Text.RegularExpressions;

namespace MyMovies.Api.Helper.Validations
{
    public class UserValidator : AbstractValidator<UserAddDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome é obrigatório.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Sobrenome é obrigatório.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Login de acesso é obrigatório.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email é obrigatório.");
            RuleFor(x => x.Birthday).Must(VrBirth).WithMessage("Data de nascimento não atende a condição definida.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Senha é obrigatório.");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("A confirmação de senha não confere.");
        }

        private bool VrBirth(string arg)
        {
            bool vr = false;
            if (DateTime.TryParse(arg, out DateTime dt))
            {
                if (dt.Year >= 1900 && dt.Year <= 2099)
                    vr = true;
                else
                    vr = false;
            }
            return vr;
        }
    }
}