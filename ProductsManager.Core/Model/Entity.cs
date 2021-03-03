using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductsManager.Core.Model
{
    public abstract class Entity
    {
        [NotMapped]
        public ValidationResult ValidationResult { get; protected set; }

        protected Entity() 
        {
            this.ValidationResult = new ValidationResult();
        }

        public void AddValidationErrors(string error, string description)
        {
            ValidationResult.Errors.Add(new ValidationFailure(error, description));
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
