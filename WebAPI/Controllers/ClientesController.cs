using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly Authentication _serviceAuthentication;
        private readonly ReturnServiceModel _returnServiceModel;

        public ClientesController(IHttpContextAccessor contextAccessor)
        {
            _returnServiceModel = new ReturnServiceModel();
            _serviceAuthentication = new Authentication(contextAccessor);
        }

        private ReturnServiceModel Authentication()
        {
            try
            {
                _serviceAuthentication.Authenticate();
            }
            catch (Exception ex)
            {
                _returnServiceModel.Result = false;
                _returnServiceModel.ErrorMessage = ex.Message;
                throw;
            }

            return _returnServiceModel;
        }

        [HttpGet]
        [Route("listartodos")]
        public IList<ClienteModel> ListarTodos()
        {
            Authentication();

            return new ClienteModel().ListarTodos();
        }

        [HttpGet]
        [Route("buscarporid/{id}")]
        public ClienteModel BuscarPorId(int id)
        {
            return new ClienteModel().BuscarPorId(id);
        }

        [HttpPost]
        [Route("registarcliente")]
        public ReturnServiceModel RegistrarCliente([FromBody] ClienteModel cliente)
        {
            Authentication();

            try
            {
                cliente.RegistrarCliente();
            }
            catch (Exception ex)
            {
                _returnServiceModel.Result = false;
                _returnServiceModel.ErrorMessage = "Erro ao cadastrar um cliente: " + ex.Message;
            }

            return _returnServiceModel;
        }

        [HttpPut]
        [Route("atualizarcliente/{id}")]
        public ReturnServiceModel AtualizarCliente(int id, [FromBody] ClienteModel cliente)
        {
            Authentication();

            try
            {
                cliente.AtualizarCliente(id);
            }
            catch (Exception ex)
            {
                _returnServiceModel.Result = false;
                _returnServiceModel.ErrorMessage = "Erro ao atualizar um cliente: " + ex.Message;
            }

            return _returnServiceModel;
        }

        [HttpDelete]
        [Route("apagarcliente/{id}")]
        public ReturnServiceModel ApagarCliente(int id)
        {
            Authentication();

            try
            {
                new ClienteModel().ApagarCliente(id);
            }
            catch (Exception ex)
            {
                _returnServiceModel.Result = false;
                _returnServiceModel.ErrorMessage = "Erro ao apagar um cliente: " + ex.Message;
            }

            return _returnServiceModel;
        }
    }
}