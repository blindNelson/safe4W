using System.ComponentModel.DataAnnotations;

namespace API_praticas.models
{    public class usuario
    {
        [Key]
        public int idUsuario{get;set;}
        public string nome{get;set;}
        public string senha{get;set;}
    }
}