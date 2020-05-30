using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp2v2.Models;

namespace WebApp2v2.ModelValidators
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.Text).MinimumLength(2).MaximumLength(50);
        }
    }
}
