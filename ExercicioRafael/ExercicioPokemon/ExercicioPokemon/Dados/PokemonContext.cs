using ExercicioPokemon.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExercicioPokemon.Dados
{
    public class PokemonContext : DbContext 
    {
        public PokemonContext(DbContextOptions<PokemonContext> opt) : base (opt)
        {

        }

        public DbSet<Pokemon> Pokemons { get; set; }
    }
}
