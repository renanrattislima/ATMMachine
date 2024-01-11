namespace Infrastructure
{
    using Domain.Models;
    using Domain.Models.Enums;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

    public class DbContextClass : DbContext
    {
        public DbContextClass()
        {
        }

        public DbContextClass(DbContextOptions<DbContextClass> contextOptions) : base(contextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da entidade Client
            modelBuilder.Entity<Client>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Client>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Client>()
                .Property(c => c.CPF)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(c => c.Name)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(c => c.UF)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(c => c.Cellphone)
                .IsRequired();

            // Configuração da entidade PaperMoney
            modelBuilder.Entity<PaperMoney>()
                .HasKey(p => p.PaperId);

            modelBuilder.Entity<PaperMoney>()
                .Property(p => p.PaperId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PaperMoney>()
                .Property(p => p.Value)
                .IsRequired();

            modelBuilder.Entity<PaperMoney>()
                .Property(p => p.SerialNumber)
                .IsRequired();

            modelBuilder.Entity<PaperMoney>()
                .Property(p => p.RegisterDate)
                .IsRequired();

            modelBuilder.Entity<PaperMoney>()
                .Property(p => p.isWithdrawn)
                .IsRequired();

            // Configuração da entidade Withdraw
            modelBuilder.Entity<Withdraw>()
                .HasKey(w => w.WithdrawId);

            modelBuilder.Entity<Withdraw>()
                .Property(w => w.WithdrawId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Withdraw>()
                .Property(w => w.WithdrawDate)
                .IsRequired();

            modelBuilder.Entity<Withdraw>()
                .Property(w => w.ClientId)
                .IsRequired();

            modelBuilder.Entity<Withdraw>()
                .Property(w => w.PaperId)
                .IsRequired();

            // Relacionamentos

            modelBuilder.Entity<Withdraw>()
                .HasOne(w => w.Client)
                .WithMany(c => c.Withdraws)
                .HasForeignKey(w => w.ClientId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Withdraw> Withdraws { get; set; }

        public DbSet<PaperMoney> PaperMoneys { get; set; }
    }
}
