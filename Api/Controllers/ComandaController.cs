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
    public class ComandaController : ApiController
    {
        //GET api/comanda
        public IHttpActionResult GetProdutosComanda()
        {
            try
            {
                DaoComandas dao = new DaoComandas();
                var LstProdutosComanda = dao.Listar();

                return Ok(LstProdutosComanda);
            }
            catch
            {
                return BadRequest();
            }
        }


        //POST api/
        [HttpPost]
        public IHttpActionResult CreateProdutoComanda(int idUsuario, int idProduto, int Quantidade)
        {
            try
            {
                Comanda comanda = new Comanda()
                {
                    Usuario = new Usuario() { Id = idUsuario },
                    Produto = new Produto() { Id = idProduto },
                    Quantidade = Quantidade
                };

                DaoComandas dao = new DaoComandas();
                dao.Incluir(comanda);
                return Created(new Uri(Request.RequestUri + "/" + comanda.Id), comanda);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
