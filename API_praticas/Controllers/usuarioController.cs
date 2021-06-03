using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using API_praticas.data;
using API_praticas.models;

namespace API_praticas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuarioController: Controller{
        public readonly denunciaContext _context;
        public usuarioController(denunciaContext context){ _context = context; }

        [HttpGet]
        public ActionResult<List<usuario>> getAll(){
            return _context.usuario.ToList();
        }
    }
}