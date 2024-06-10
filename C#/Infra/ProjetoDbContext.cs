using ApiPiex.Infra.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPiex.Infra
{
    public class ProjetoDbContext : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Doador> Doadores { get; set; }
        public DbSet<Donatario> Donatarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-215IJJK;Database=Piex;UID=DESKTOP-215IJJK\\galoc;PWD='';Integrated Security=true;trustServerCertificate=true");
        }
    }
}
