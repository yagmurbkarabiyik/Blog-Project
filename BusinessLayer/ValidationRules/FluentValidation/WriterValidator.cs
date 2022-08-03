using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı soyadı Kısmı Boş Geçilemez.");
            RuleFor(x=> x.WriterMail).NotEmpty().WithMessage("Mail adresi Boş Geçilemez.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girişi Yapın.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Veri Girişi Yapın.");
            RuleFor(x => x.WriterPassword).Equal(x => x.WriterPasswordRepeat).WithMessage("Girdiğiniz şifreler aynı olmalıdır.");
            RuleFor(x => x.WriterPassword).Matches("[^a-zA-Z0-9]").WithMessage("Şifreniz en az bir büyük harf, küçük harf ve rakam içermelidir.");
            //RuleFor(x => x.WriterPassword).Matches("[a-z]").WithMessage("Şifreniz en az bir tane küçük harf içermelidir.");
            //RuleFor(x => x.WriterPassword).Matches("[0-9]").WithMessage("Şifreniz en az bir tane rakam içermelidir.");
        }
    }
}
