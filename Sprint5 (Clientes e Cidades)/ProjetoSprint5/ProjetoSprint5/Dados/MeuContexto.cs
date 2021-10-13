using Microsoft.EntityFrameworkCore;
using ProjetoSprint5.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSprint5.Dados
{
    public class MeuContexto : DbContext 
    {
        public MeuContexto(DbContextOptions<MeuContexto> opt) : base (opt)
        {

        }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
