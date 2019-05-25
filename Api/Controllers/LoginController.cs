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
    public class LoginController : ApiController
    {
        //GET api/login
        public IHttpActionResult GetLogin(string login, string senha)
        {
            try
            {
                DaoUsuarios dao = new DaoUsuarios();
                var Usuario = dao.Login(login, senha);

                if (Usuario.Id > 0)
                    return Ok(Usuario);
                else
                    return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
