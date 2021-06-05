using System.ComponentModel.DataAnnotations;

namespace API_praticas.models
{
    public class regiao{
        [Key]
        public int idRegiao{get;set;}
        public string nomeRegiao{get;set;}
    }
}