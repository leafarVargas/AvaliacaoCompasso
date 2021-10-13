using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSprint5.Modelos
{
    public class Cidade
    {
        [Key]
        [Required(ErrorMessage = " A Cidade deve ter um ID")]
        public int id{ get; set; }

        [Required(ErrorMessage = " A Cidade deve ter um Nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "A Cidade deve ter um Estado")]
        public string estado { get; set; }
    }
}
