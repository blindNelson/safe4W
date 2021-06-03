using Microsoft.EntityFrameworkCore;
using API_praticas.models;

namespace API_praticas.data
{
    public class denunciaContext : DbContext{
        public denunciaContext(DbContextOptions<denunciaContext> options): base (options){ }

        public DbSet<denuncia> denuncia{get;set;}
        public DbSet<usuario> usuario{get;set;}    
    }
}