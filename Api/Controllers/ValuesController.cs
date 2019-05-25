using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Classes.Entidades;
using Classes.Dados;

namespace Api.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Produto> GetProdutos()
        {
            DaoProdutos dao = new DaoProdutos();
            var LstProdutos = dao.Listar();

            return LstProdutos;
        }

        // GET api/values/5
        public string GetProduto(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
