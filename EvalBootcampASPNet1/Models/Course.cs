using System;
using System.ComponentModel.DataAnnotations;

namespace EvalBootcampASPNet1.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1500)]
        public string Descriprion { get; set; }

        public Author Author { get; set; }
    }
}
