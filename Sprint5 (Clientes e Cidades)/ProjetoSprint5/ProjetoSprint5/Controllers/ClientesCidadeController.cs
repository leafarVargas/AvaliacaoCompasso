using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoSprint5.Dados;
using ProjetoSprint5.DTOs;
using ProjetoSprint5.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProjetoSprint5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesCidadeController : ControllerBase 
    {
        static HttpClient client = new HttpClient();
        public class Localizacao
        {
            public string cep { get; set; }
            public string logradouro { get; set; }
            public string complemento { get; set; }
            public string bairro { get; set; }
            public string localidade { get; set; }
            public string uf { get; set; }
        }

        static async Task<Localizacao> GetLocalizacaoAsync(string path)
        {
            Localizacao localizacao = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                localizacao = await response.Content.ReadAsAsync<Localizacao>();
            }
            return localizacao;
        }

        private MeuContexto __contextoGeral;
        private IMapper _mapper;

        public ClientesCidadeController(MeuContexto cidadecontext, IMapper mapper)
        {
            __contextoGeral = cidadecontext;
            _mapper = mapper;
        }

        [HttpPost("AdicionarCidade")]
        public IActionResult AdicionaCidade([FromBody] CreateCidadeDTO cidadeDTO)
        {

            Cidade cidade = _mapper.Map<Cidade>(cidadeDTO);

            __contextoGeral.Cidades.Add(cidade);
            __contextoGeral.SaveChanges();
            return CreatedAtAction(nameof(BuscarCidade), new { id = cidade.id }, cidade);
        }

        [HttpPost("AdicionarCliente")]
        public async Task<IActionResult> AdicionaCliente([FromBody] CreateClienteDTO clienteDTO)
        {
            string url = "https://viacep.com.br/ws/";

            Cliente cliente = _mapper.Map<Cliente>(clienteDTO);
            
            Cidade cidade = new Cidade();
            
            client.BaseAddress = new Uri("https://viacep.com.br/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var localizacao = await GetLocalizacaoAsync(url + cliente.cep + "/json/");

            cliente.logradouro = localizacao.logradouro;
            cliente.bairro = localizacao.bairro;
            cliente.cep = localizacao.cep;
            cliente.localidade = localizacao.localidade;

            cliente.cidadeID++;
            cidade.id = cliente.cidadeID;
            cidade.nome = localizacao.localidade;
            cidade.estado = localizacao.uf;

            __contextoGeral.Clientes.Add(cliente);
            __contextoGeral.Cidades.Add(cidade);
            __contextoGeral.SaveChanges();

            return CreatedAtAction(nameof(BuscarCliente), new { id = cliente.id }, cliente);
        }

        [HttpGet("Cidades")]
        public IEnumerable<Cidade> ListarCidades()
        {
            return __contextoGeral.Cidades;
        }

        [HttpGet("Clientes")]
        public IEnumerable<Cliente> ListarClientes()
        {
            return __contextoGeral.Clientes;
        }

        [HttpGet("BuscarCidade/{id}")]
        public IActionResult BuscarCidade(int id)
        {
            Cidade cidade = __contextoGeral.Cidades.FirstOrDefault(cidade => cidade.id == id);
            if (cidade != null)
            {
                return Ok(cidade);
            }
            return NotFound();
        }

        [HttpGet("BuscarCliente/{id}")]
        public IActionResult BuscarCliente(int id)
        {
            Cliente cliente = __contextoGeral.Clientes.FirstOrDefault(cliente => cliente.id == id);
            if (cliente != null)
            {
                return Ok(cliente);
            }
            return NotFound();
        }

        [HttpGet("AtualizaCliente/{id}")]
        public IActionResult AtualizarCliente(int id, [FromBody] UpdateClienteDTO clienteDTO)
        {
            Cliente cliente = __contextoGeral.Clientes.FirstOrDefault(cliente => cliente.id == id);
          
            if(cliente == null)
            {
                return NotFound();
            }
            _mapper.Map(clienteDTO, cliente);

            __contextoGeral.SaveChanges();
            
            return NoContent();
        }

        [HttpGet("AtualizarCidade/{id}")]
        public IActionResult AtualizarCidade(int id, [FromBody] UpdateCidadeDTO cidadeDTO)
        {

            Cidade cidade = __contextoGeral.Cidades.FirstOrDefault(cidade => cidade.id == id);

            if (cidade == null)
            {
                return NotFound();
            }

            _mapper.Map(cidadeDTO, cidade);

            __contextoGeral.SaveChanges();

            return NoContent();
        }

        [HttpDelete("DeletarCidade/{id}")]
        public IActionResult DeletarCidade (int id)
        {
            Cidade cidade = __contextoGeral.Cidades.FirstOrDefault(cidade => cidade.id == id);
            if(cidade == null)
            {
                return NotFound();
            }
            __contextoGeral.Remove(cidade);
            __contextoGeral.SaveChanges();
            return NoContent();
        }
         
        [HttpDelete("DeletarCliente/{id}")]
        public IActionResult DeletarCliente(int id)
        {
            Cliente cliente = __contextoGeral.Clientes.FirstOrDefault(cliente => cliente.id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            __contextoGeral.Remove(cliente);
            __contextoGeral.SaveChanges();
            return NoContent();
        }
    }
}