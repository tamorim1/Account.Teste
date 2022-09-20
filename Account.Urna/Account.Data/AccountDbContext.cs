using Account.Models.Entities.Candidato;
using Account.Models.Entities.Voto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Data
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions options) : base(options)
        {

        }

        protected AccountDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidatoEntity>().ToTable("candidato");
            modelBuilder.Entity<CandidatoEntity>().HasKey(e => e.Id).HasName("PK_candidato_id");
            modelBuilder.Entity<CandidatoEntity>().Property(e => e.Id).HasColumnName("id").HasColumnType("INTEGER").IsRequired(true);
            modelBuilder.Entity<CandidatoEntity>().Property(e => e.NomeCompleto).HasColumnName("nome_completo").HasColumnType("TEXT").IsRequired(true).HasMaxLength(100);
            modelBuilder.Entity<CandidatoEntity>().Property(e => e.NomeVice).HasColumnName("nome_vice").HasColumnType("TEXT").IsRequired(true).HasMaxLength(100);
            modelBuilder.Entity<CandidatoEntity>().Property(e => e.Legenda).HasColumnName("legenda").HasColumnType("INTEGER").IsRequired(true);
            modelBuilder.Entity<CandidatoEntity>().Property(e => e.DataRegistro).HasColumnName("data_registro").HasColumnType("TEXT").IsRequired(true);

            modelBuilder.Entity<VotoEntity>().ToTable("voto");
            modelBuilder.Entity<VotoEntity>().HasKey(e => e.Id).HasName("PK_voto_id");
            modelBuilder.Entity<VotoEntity>().Property(e => e.Id).HasColumnName("id").HasColumnType("INTEGER").IsRequired(true);
            modelBuilder.Entity<VotoEntity>().Property(e => e.IdCandidato).HasColumnName("id_candidato").HasColumnType("INTEGER").IsRequired(false);
            modelBuilder.Entity<VotoEntity>().Property(e => e.DataVoto).HasColumnName("data_voto").HasColumnType("TEXT").IsRequired(true);
            modelBuilder.Entity<VotoEntity>().HasOne(e => e.Candidato).WithMany(e => e.Votos).HasForeignKey(e => e.IdCandidato);


        }
    }
}
