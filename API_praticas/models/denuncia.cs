using System.ComponentModel.DataAnnotations;

namespace API_praticas.models{
    
    public class denuncia{
        [Key]
        public int idDenuncia{get;set;}
        public int? idUsuario{get;set;}
        public int idRegiao{get;set;}
        public string nomeVitima{get;set;}
        public string nomeAgressor{get;set;}
        public string descricaoDenuncia{get;set;}
        public string relacao{get;set;}
    } 
}