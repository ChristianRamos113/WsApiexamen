using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos
{
    public class BDDirectaContext : DbContext
    {
        public BDDirectaContext(DbContextOptions<BDDirectaContext> options)
            : base(options)
        {
        }
        public DbSet<DatosBD> Examenes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatosBD>(entity =>
            {
                entity.ToTable("tblExamen");
                entity.HasKey(e => e.IdExamen);
                entity.Property(e => e.IdExamen).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ResponseSPE>(entity =>
            {
                entity.HasNoKey();
            });
        }
    }
}
