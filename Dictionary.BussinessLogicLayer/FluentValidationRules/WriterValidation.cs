using Dictionary.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.BussinessLogicLayer.FluentValidationRules
{
    public class WriterValidation : AbstractValidator<Writer>
    {
        public WriterValidation()
        {
            RuleFor(w => w.FirstName).NotEmpty().WithMessage("Can not be empty!");
            RuleFor(w => w.LastName).NotEmpty().WithMessage("Can not be empty!");
            RuleFor(w => w.About).NotEmpty().WithMessage("Can not be empty!");
            RuleFor(w => w.Title).NotEmpty().WithMessage("Can not be empty!");
            RuleFor(w => w.Email).NotEmpty().WithMessage("Can not be empty!");
            RuleFor(w => w.Password).NotEmpty().WithMessage("Can not be empty!");
            RuleFor(w => w.Image).NotEmpty().WithMessage("Can not be empty!");
        }
    }
}
