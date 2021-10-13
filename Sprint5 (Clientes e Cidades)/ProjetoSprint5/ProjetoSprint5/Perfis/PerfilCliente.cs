using AutoMapper;
using ProjetoSprint5.DTOs;
using ProjetoSprint5.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSprint5.Perfis
{
    public class PerfilCliente : Profile 
    {
        public PerfilCliente()
        {
            CreateMap<CreateClienteDTO, Cliente>();
            CreateMap<UpdateClienteDTO, Cliente>();
        }

    }
}
