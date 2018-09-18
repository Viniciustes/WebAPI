using System;

namespace WebAPI.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataCadastro { get; set; }

        public string Telefone { get; set; }

        public string CPF { get; set; }

        public void RegistrarCliente(ClienteModel cliente)
        {
            var context = new Context.Context();

            var sql = $"INSERT INTO Cliente(Nome, DataCadastro, CPF, Telefone) VALUES ( '{cliente.Nome}' , '{cliente.DataCadastro.ToString("yyyy/MM/dd")}', '{cliente.CPF}', '{cliente.Telefone}')";

            context.ExecutarComandoSql(sql);
        }

        internal void RegistrarCliente()
        {
            throw new NotImplementedException();
        }
    }
}
