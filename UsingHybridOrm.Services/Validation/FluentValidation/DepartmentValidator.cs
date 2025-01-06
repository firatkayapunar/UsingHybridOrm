using FluentValidation;
using UsingHybridOrm.Entities.Concrete;

// Validation  => Doğrulama
// Validator   => Doğrulayıcı
// Validate    => Doğrula

namespace UsingHybridOrm.Services.Validation.FluentValidation
{
    internal class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(r => r.Name).NotEmpty().WithMessage("Bölüm Adı Boş Geçilemez.");
            RuleFor(r => r.Name).MinimumLength(3).WithMessage("Bölüm Adı En Az 3 Karakter Olmalıdır.");
            RuleFor(r => r.Name).MaximumLength(25).WithMessage("Bölüm Adı En Fazla 25 Karakter Olmalıdır.");
        }
    }
}
