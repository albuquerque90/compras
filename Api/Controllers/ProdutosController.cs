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
    public class ProdutosController : ApiController
    {

        //GET api/produtos
        public IHttpActionResult GetProdutos()
        {
            try
            {
                DaoProdutos dao = new DaoProdutos();
                var LstProdutos = dao.Listar();

                return Ok(LstProdutos);
            }
            catch
            {
                return BadRequest();
            }
        }

        //GET api/produtos/1
        public IHttpActionResult GetProduto(int id)
        {
            try
            {
                DaoProdutos dao = new DaoProdutos();
                var Produto = dao.Buscar(id);

                return Ok(Produto);
            }
            catch 
            {
                return BadRequest();
            }
        }
    }
}
