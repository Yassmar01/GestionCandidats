using System;
using System.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace CandidaturesEnligne.Models
{
    public partial class CandidateuresEnligneContext : DbContext
    {
        public CandidateuresEnligneContext()
        {
        }

        public CandidateuresEnligneContext(DbContextOptions<CandidateuresEnligneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Candidat> Condidats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-V21QB25; Database =CanditeuresEnligne ;Trusted_Connection = true ;");
            }
        }
       
    }
}
