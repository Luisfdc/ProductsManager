using FluentValidation;
using ProductsManager.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsManager.Validations
{
    public class ProductValidation: AbstractValidator<Product>
    {
        public ProductValidation()
        {
            ValidatorOptions.LanguageManager.Culture = new System.Globalization.CultureInfo("pt-BR");

            RuleFor(e => e.Description)
                .NotEmpty();

            RuleFor(e => e.Image)
                .NotEmpty();

            RuleFor(e => e.Price)
                .GreaterThan(0);
        }

    }
}
