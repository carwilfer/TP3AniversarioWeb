using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP03AniversarioWeb.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Nome")]
        public String Nome { get; set; }

        [Required]
        [Display(Name = "Email")]
        public String Email { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Nascimento")]
        public DateTime DateNascimento { get; set; }
    }
}
