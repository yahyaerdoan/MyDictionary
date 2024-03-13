using Dictionary.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.BussinessLogicLayer.FluentValidationRules
{
    public class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Can not be empty!");
            RuleFor(c => c.Name).NotEmpty().MinimumLength(3).MaximumLength(20).WithMessage("Min 3 max 20 character!");
            RuleFor(c => c.Status).NotEmpty().WithMessage("Can not be empty!");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Can not be empty!");
           
        }
    }
}
