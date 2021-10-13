using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSprint5.Modelos
{
    public class Cliente
    {
        [Key]
        [Required(ErrorMessage =" O cliente deve ter um ID")]
        public int id { get; set; }

        [Required(ErrorMessage = " O cliente deve ter um Nome")]
        public string nome { get; set; }

        public string datanascimento { get; set; }
        public int cidadeID { get; set; }

        [Required(ErrorMessage = " O cliente deve ter um CEP")]
        public string cep { get; set; }

        public string logradouro { get; set; }
        public string bairro { get; set; }
    }
}
