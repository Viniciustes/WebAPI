using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/Clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            return new[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            //var con = new Context.Context();

            //var sql = $"Select * From Cliente Where Id ={id}";

            //var retorno = con.RetornarDataTable(sql);

            //return retorno.Rows[0]["Nome"].ToString();
            return null;
        }

        // POST api/values
        [HttpPost]
        [Route("registarcliente")]
        public void RegistrarCliente([FromBody] ClienteModel cliente)
        {
            cliente.RegistrarCliente();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
