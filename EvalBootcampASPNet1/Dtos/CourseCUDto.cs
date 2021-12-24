using System;
using System.ComponentModel.DataAnnotations;

namespace EvalBootcampASPNet1.Dtos
{
    
    public class CourseCUDto
    {
        [Required]
        public int AuthorId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Descriprion { get; set; }
    }
}
