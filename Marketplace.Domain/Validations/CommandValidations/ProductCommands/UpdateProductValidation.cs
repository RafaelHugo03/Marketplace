using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marketplace.Domain.Commands.ProductCommands;

namespace Marketplace.Domain.Validations.CommandValidations.ProductCommands
{
    public class UpdateProductValidation : ProductCommandValidation<UpdateProductCommand>
    {
        public UpdateProductValidation()
        {
            ValidateId();
            ValidateName();
            ValidatePrice();
            ValidateQuantity();
        }
    }
}