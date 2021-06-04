using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Microsoft.AspNetCore.Http;

using API_praticas.data;
using API_praticas.models;
using API_praticas.services;

namespace API_praticas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController: Controller{
        public readonly denunciaContext _context;
        public HomeController(denunciaContext context){ _context = context; }

        [HttpGet]
        public ActionResult<List<usuario>> getAll(){
            return _context.usuario.ToList();
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] usuario usuario){
            try{
                var user = _context.usuario.Where(u => u.nome==usuario.nome && u.senha==usuario.senha).FirstOrDefault();

                if(user==null)
                    return NotFound(new {message = "Usuário ou senha inválidos"});

                var token = TokenService.GenerateToken(user);
                user.senha = "";
            return Ok(new
            {
                user = user,
                token = token
            });
            }
            catch{
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }

        [HttpPost]
        [Route("sigin")]
        [AllowAnonymous]
        public async Task<ActionResult> Cadastro([FromBody]usuario model){
            try{
                _context.usuario.Add(model);                 
                if (await _context.SaveChangesAsync()==1)
                    return Ok();
            }
            catch{
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("Authenticated")]
        [Authorize]
        public string Authenticated() => User.Identity.Name;
    }
}