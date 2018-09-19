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
            var clientes = new List<ClienteViewModel>();

            var json = RequestWepApi.RequestGet("listartodos");

            clientes = JsonConvert.DeserializeObject<List<ClienteViewModel>>(json);

            return clientes;
        }
    }
}
