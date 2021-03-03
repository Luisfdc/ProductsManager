using ProductsManager.Core.Model;
using ProductsManager.Validations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsManager.Entities
{
    [Table("Product")]
    public class Product: Entity
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new ProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
