﻿using System.ComponentModel.DataAnnotations;

namespace HugoApp.Application.Models.Person
{
    public class UpdatePerson
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [MinLength(2), MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Surname { get; set; }
    }
}
