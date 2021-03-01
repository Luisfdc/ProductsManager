using ProductsManager.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsManager.Validations
{
    public static class ProductsValidations
    {
        public static bool ProductDescriptionValidation(this Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Description))
                return false;
            else
            {
                return true;
            }
        }
    }
}
