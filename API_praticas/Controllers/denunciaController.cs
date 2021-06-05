using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using API_praticas.data;
using API_praticas.models;

namespace API_praticas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class denunciaController : Controller
    {
        public readonly denunciaContext _context;
        public denunciaController(denunciaContext context){ _context = context; }
        
        [HttpGet]
        public ActionResult<List<denuncia>> GetAll(){
            return _context.denuncia.ToList();
        }





        [HttpGet("regiao:{idRegiao}")]
        [AllowAnonymous]
        public ActionResult<int> GetQtdRegiao(int idRegiao){
            try{
                if(_context.regiao.Find(idRegiao)==null)
                    return NotFound();
                return Ok(_context.denuncia.Count(rr => rr.idRegiao==idRegiao));
            }
            catch{
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }




        [HttpGet]
        [Route("user")]
        [Authorize]
        public ActionResult<List<denuncia>> getDenuncia(){
            try{
                var result = _context.denuncia.Where(se => se.idUsuario==int.Parse(User.Identity.Name)).ToList();
                if(result==null)
                    return NotFound();
                return Ok(result);
            }
            catch{
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }









        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> denunciaAnonima([FromBody]denuncia model){
            try{
                _context.denuncia.Add(model);
                if (_context.regiao.Find(model.idRegiao)==null)
                    return NotFound();                    
                if (await _context.SaveChangesAsync()==1)
                    return Ok();
            }
            catch{
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            return BadRequest();
        }


        [HttpPost]
        [Route("user")]
        [Authorize]
        public async Task<ActionResult<string>> denunciaUsuario([FromBody]denuncia model){
            try{
                if(model==null)
                    return BadRequest("modelo inexistente");
                if(_context.regiao.Find(model.idRegiao) == null)
                    return BadRequest($"região inexistente: {model.idRegiao.ToString()}");         
                model.idUsuario=int.Parse(User.Identity.Name);
                _context.denuncia.Add(model);        
                if (await _context.SaveChangesAsync()==1)
                    return Ok();
            }
            catch{
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            return BadRequest();
        }


        [HttpPut]
        [Route("user/{idDenuncia}")]
        [Authorize]
        public async Task<ActionResult> put(int idDenuncia, denuncia newDadosDenuncias){
            try{
                int idUsuario = int.Parse(User.Identity.Name);
                var result = await _context.denuncia.FindAsync(idDenuncia);
                if(idUsuario != result.idUsuario)
                    return BadRequest();
                result.idUsuario = result.idUsuario;
                result.idDenuncia = result.idDenuncia;
                result.idRegiao = newDadosDenuncias.idRegiao;
                result.nomeVitima = newDadosDenuncias.nomeVitima;
                result.nomeAgressor = newDadosDenuncias.nomeAgressor;
                result.descricaoDenuncia = newDadosDenuncias.descricaoDenuncia;
                result.relacao = newDadosDenuncias.relacao;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch{
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }
    }
}