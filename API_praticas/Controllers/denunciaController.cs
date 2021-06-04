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



        //devolve o numero de denuncias feitas numa região
        [HttpGet("regiao:{idRegiao}")]
        [AllowAnonymous]
        public ActionResult<int> GetQtdRegiao(int idRegiao){
            try{
                var result = _context.denuncia.Find(idRegiao);
                if(idRegiao==null)
                    return NotFound();
                return Ok(_context.denuncia.Count(rr => rr.idRegiao==idRegiao));
            }
            catch{
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }


/*
        [HttpGet]
        [Route("user")]
        [Authorize()]
        public ActionResult<List<denuncia>> getDenuncia([FromBody] int idUsuario){
            try{
                var result = _context.denuncia.Where(se => se.idUsuario==idUsuario);
                if(result==null)
                    return NotFound();
                return Ok(result);
            }
            catch{
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }*/



        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> denunciaAnonima([FromBody]denuncia model){
            try{
                _context.denuncia.Add(model);
                if (_context.denuncia.Find(model.idRegiao)==null)
                    return NotFound();                    
                if (await _context.SaveChangesAsync()==1)
                    return Ok();
            }
            catch{
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            return BadRequest();
        }


    }
}