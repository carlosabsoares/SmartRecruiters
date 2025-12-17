using Microsoft.EntityFrameworkCore;
using SmartRecruiters.Api.Domain.Entities;
using SmartRecruiters.Api.Infra.Mapping;

namespace SmartRecruiters.Api.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<CreditoEntity> Credito { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.MapCredito(modelBuilder);
        }
    }
}