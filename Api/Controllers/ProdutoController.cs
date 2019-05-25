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
    public class ProdutoController : ApiController
    {

        //GET api/produtos
        public IEnumerable<Produto> Get()
        {
            DaoProdutos dao = new DaoProdutos();
            var LstProdutos = dao.Listar();

            return LstProdutos;
        }
    }
}
