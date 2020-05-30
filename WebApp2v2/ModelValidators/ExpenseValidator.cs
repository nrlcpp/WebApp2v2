using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp2v2.Models;

namespace WebApp2v2.ModelValidators
{
    public class ExpenseValidator : AbstractValidator<Expense>
    {
        public ExpenseValidator()
        {
            RuleFor(x => x.Description)
                .MinimumLength(2)
                .MaximumLength(50);
            RuleFor(x => x.Date)
                .LessThan(DateTime.Now)
                .WithMessage("we are in " + DateTime.Now + " you can't spend in the future");
            RuleFor(x => x.Location)
                .MinimumLength(2)
                .MaximumLength(30);
            RuleFor(x => x.Sum)
                .InclusiveBetween(0, 10000)
                .WithMessage("it's too expensive");

        }
    }
}
