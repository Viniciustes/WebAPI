using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WebMVC.Requests;

namespace WebMVC.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataCadastro { get; }

        public string Telefone { get; set; }

        public string CPF { get; set; }

        public IList<ClienteViewModel> ListarTodos()
        {
            var json = RequestWepApi.RequestGet("GET", "listartodos");

            return JsonConvert.DeserializeObject<List<ClienteViewModel>>(json);
        }

        public ClienteViewModel BuscarPorId(int id)
        {
            var json = RequestWepApi.RequestGet("GET", "buscarporid", id.ToString());

            return JsonConvert.DeserializeObject<ClienteViewModel>(json);
        }

        public void Cadastrar()
        {
            var json = JsonConvert.SerializeObject(this);

            RequestWepApi.Request("POST", "registarcliente", json);
        }

        public void Editar(int id)
        {
            RequestWepApi.Request("PUT", "atualizarcliente", id.ToString());
        }

        public void Apagar(int id)
        {
            RequestWepApi.Request("DELETE", "apagarcliente", id.ToString());
        }
    }
}