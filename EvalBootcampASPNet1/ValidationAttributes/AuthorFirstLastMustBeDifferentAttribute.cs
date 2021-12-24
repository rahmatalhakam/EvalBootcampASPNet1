using System;
using System.ComponentModel.DataAnnotations;
using EvalBootcampASPNet1.Dtos;

namespace EvalBootcampASPNet1.ValidationAttributes
{
    public class AuthorFirstLastMustBeDifferentAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var author = (AuthorCUDto)validationContext.ObjectInstance;
            if (author.FirstName == author.LastName)
                return new ValidationResult("Firstname dan lastname tidak boleh sama",
                    new[] { nameof(AuthorCUDto) });
            return ValidationResult.Success;
        }
    }
}
