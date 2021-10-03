using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExercicioPokemon.Dados.Dtos
{
    public class ListaPokemonDto
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required(ErrorMessage = "O Pokemon deve ter um Nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O Pokemon deve ter um tipo / uma classe")]
        public string tipo { get; set; }
    }
}
