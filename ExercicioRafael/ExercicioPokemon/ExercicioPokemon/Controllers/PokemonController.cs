using ExercicioPokemon.Dados;
using ExercicioPokemon.Dados.Dtos;
using ExercicioPokemon.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExercicioPokemon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private PokemonContext _context;

        public PokemonController(PokemonContext context)
        {
            _context = context;

        }

        [HttpPost]
        public IActionResult AddPokemon([FromBody] CreatePokemonDto pokemonDto)
        {
            Pokemon pokemon = new Pokemon
            {
                nome = pokemonDto.nome,
                tipo = pokemonDto.tipo
            };

            _context.Pokemons.Add(pokemon);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ListaPokemonsID), new { id = pokemon.id }, pokemon);
        }

        [HttpGet]
        public IActionResult ListaPokemons()
        {
            return Ok(_context.Pokemons);
        }

        [HttpGet("{id}")]
        public IActionResult ListaPokemonsID(int id)
        {
            Pokemon pokemon =  _context.Pokemons.FirstOrDefault(pokemon => pokemon.id == id);
            if(pokemon != null)
            {
                ListaPokemonDto pokemonDto = new ListaPokemonDto
                {
                    id = pokemon.id,
                    nome = pokemon.nome,
                    tipo = pokemon.tipo
                };

                return Ok(pokemonDto);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaPokemon(int id)
        {
            Pokemon pokemon = _context.Pokemons.FirstOrDefault(pokemon => pokemon.id == id);
            if(pokemon == null)
            {
                return NotFound();
            }

            _context.Remove(pokemon);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
