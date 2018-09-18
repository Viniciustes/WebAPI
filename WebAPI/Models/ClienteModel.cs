using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class ClienteModel
    {
        public ClienteModel()
        {
            DataCadastro = DateTime.Now;
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataCadastro { get; }

        public string Telefone { get; set; }

        public string CPF { get; set; }

        public ClienteModel BuscarPorId(int id)
        {
            var con = new Context.Context();

            var sql = $"Select * From Cliente Where Id ={id}";

            var retorno = con.RetornarDataTable(sql);

            var cliente = new ClienteModel()
            {
                Id = (int)retorno.Rows[0]["Id"],
                Nome = retorno.Rows[0]["Nome"].ToString()
            };

            return cliente;
        }

        public IList<ClienteModel> ListarTodos()
        {
            var lista = new List<ClienteModel>();
            ClienteModel cliente;

            var context = new Context.Context();

            string sql = "select * fom cliente order by name asc";

            var dados = context.RetornarDataTable(sql);

            for (int i = 0; i < dados.Rows.Count; i++)
            {
                cliente = new ClienteModel()
                {
                    Id = (int)dados.Rows[i]["Id"],
                    Nome = dados.Rows[i]["Nome"].ToString()
                };
                lista.Add(cliente);
            }

            return lista;
        }

        public void RegistrarCliente()
        {
            var context = new Context.Context();

            var sql = $"INSERT INTO Cliente(Nome, DataCadastro, CPF, Telefone) VALUES ( '{Nome}' , '{DataCadastro}', '{CPF}', '{Telefone}')";

            context.ExecutarComandoSql(sql);
        }

        public void AtualizarCliente(int id)
        {
            var context = new Context.Context();

            var sql = $"update cliente set" +
                $"Nome = '{Nome}'," +
                $"CPF = '{CPF}'," +
                $"Telefone = '{Telefone}'" +
                $"where Id = '{id}'";

            context.ExecutarComandoSql(sql);
        }

        public void ApagarCliente(int id)
        {
            var context = new Context.Context();

            var sql = $"delete from cliente where id = {id}";

            context.ExecutarComandoSql(sql);
        }
    }
}