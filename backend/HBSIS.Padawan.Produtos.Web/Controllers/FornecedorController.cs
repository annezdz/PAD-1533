using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HBSIS.Padawan.Produtos.Domain.Entities;
using HBSIS.Padawan.Produtos.Infra.Context;
using HBSIS.Padawan.Produtos.Application.Services.Fornecedor;
using HBSIS.Padawan.Produtos.Application.Models;
using AutoMapper;

namespace HBSIS.Padawan.Produtos.Web.Controllers
{
    [ApiController]
    [Route("Fornecedor")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        // GET: api/Fornecedor
        [HttpGet]
        [Route("{id}")]
        public async Task<FornecedorResponseModel> GetById([FromRoute] int id)
        {
            return await _fornecedorService.GetById(id);
        }
       
        [HttpPost]
        [Route("Create/{id}")]
        public async Task<CreatedAtRouteResult> Create([FromBody] FornecedorRequestModel fornecedorRequestModel)
        {
            var configuration = new MapperConfiguration(cfg => { cfg.CreateMap<FornecedorRequestModel, FornecedorEntity>(); });
            IMapper mapper = configuration.CreateMapper();
            FornecedorEntity fornecedor = mapper.Map<FornecedorEntity>(fornecedorRequestModel);

            try
            {
                await _fornecedorService.Create(fornecedorRequestModel);
                return CreatedAtRoute(routeName: "{Create}", routeValues: fornecedor.ID, value: fornecedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<CreatedAtRouteResult> Put([FromRoute] int id, FornecedorRequestModel fornecedorRequestModel)
        {
            try
            {
                var fornecedor = await _fornecedorService.Update(id, fornecedorRequestModel);
                return CreatedAtRoute(routeName: "", routeValues: fornecedor.ID, fornecedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _fornecedorService.Delete(id);
                return Ok("Fornecedor deletado com sucesso.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}