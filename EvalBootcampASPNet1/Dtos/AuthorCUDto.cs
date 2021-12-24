using System;
using System.ComponentModel.DataAnnotations;
using EvalBootcampASPNet1.ValidationAttributes;

namespace EvalBootcampASPNet1.Dtos
{
    [AuthorFirstLastMustBeDifferent]
    public class AuthorCUDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(50)]
        public string MainCategory { get; set; }
    }
}
