using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpPost]
        public async Task<ActionResult> post(denuncia model){
            try{
                _context.denuncia.Add(model);
                if (_context.denuncia.Find(model.idRegiao)==null)
                    
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