using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.Models
{
    public partial class dbBudgetContext : DbContext
    {
        public dbBudgetContext()
        {
        }

        public dbBudgetContext(DbContextOptions<dbBudgetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bank> Bank { get; set; }
        public virtual DbSet<BankOfBudget> BankOfBudget { get; set; }
        public virtual DbSet<Budget> Budget { get; set; }
        public virtual DbSet<Expenses> Expenses { get; set; }
        public virtual DbSet<Incomes> Incomes { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<MessagesForUser> MessagesForUser { get; set; }
        public virtual DbSet<NumberPayments> NumberPayments { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<PermissionLevel> PermissionLevel { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server= (LocalDB)\\MSSQLLocalDB;Database= dbBudget;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>(entity =>
            {
                entity.ToTable("bank");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasColumnName("link")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameBank)
                    .IsRequired()
                    .HasColumnName("name_bank")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BankOfBudget>(entity =>
            {
                entity.HasKey(e => e.IdBank)
                    .HasName("PK__Bank_of___DCE603C04DA31C6C");

                entity.ToTable("Bank_of_budget");

                entity.Property(e => e.IdBank)
                    .HasColumnName("idBank")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdBudget).HasColumnName("idBudget");

                entity.HasOne(d => d.IdBankNavigation)
                    .WithOne(p => p.BankOfBudget)
                    .HasForeignKey<BankOfBudget>(d => d.IdBank)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bank_of_b__idBan__30F848ED");

                entity.HasOne(d => d.IdBudgetNavigation)
                    .WithMany(p => p.BankOfBudget)
                    .HasForeignKey(d => d.IdBudget)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bank_of_b__idBud__31EC6D26");
            });

            modelBuilder.Entity<Budget>(entity =>
            {
                entity.Property(e => e.Manager)
                    .IsRequired()
                    .HasColumnName("manager")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.NameBudget)
                    .IsRequired()
                    .HasColumnName("name_budget")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Permissions)
                    .IsRequired()
                    .HasColumnName("permissions")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(4)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Expenses>(entity =>
            {
                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("category")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Detail)
                    .IsRequired()
                    .HasColumnName("detail")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Document)
                    .IsRequired()
                    .HasColumnName("document")
                    .HasColumnType("image");

                entity.Property(e => e.Frequency).HasColumnName("frequency");

                entity.Property(e => e.IdBudget).HasColumnName("idBudget");

                entity.Property(e => e.NumberOfPayments).HasColumnName("number_of_payments");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasColumnName("payment_method")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Statusstatus)
                    .IsRequired()
                    .HasColumnName("statusstatus")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Subcategory)
                    .IsRequired()
                    .HasColumnName("subcategory")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Sum).HasColumnName("sum");

                entity.HasOne(d => d.IdBudgetNavigation)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.IdBudget)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Expenses__idBudg__3A81B327");
            });

            modelBuilder.Entity<Incomes>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("category")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Detail)
                    .IsRequired()
                    .HasColumnName("detail")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Document)
                    .IsRequired()
                    .HasColumnName("document")
                    .HasColumnType("image");

                entity.Property(e => e.IdBudget).HasColumnName("idBudget");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasColumnName("Payment method")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SourceOfIncome)
                    .IsRequired()
                    .HasColumnName("source_of_income")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sum).HasColumnName("sum");

                entity.HasOne(d => d.IdBudgetNavigation)
                    .WithMany(p => p.Incomes)
                    .HasForeignKey(d => d.IdBudget)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Incomes__idBudge__37A5467C");
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("category")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Details)
                    .IsRequired()
                    .HasColumnName("details")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EligibilityAge)
                    .HasColumnName("eligibility_age")
                    .HasColumnType("date");

                entity.Property(e => e.IdBank).HasColumnName("idBank");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnName("subject")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBankNavigation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.IdBank)
                    .HasConstraintName("FK__Messages__idBank__4AB81AF0");
            });

            modelBuilder.Entity<MessagesForUser>(entity =>
            {
                entity.HasKey(e => new { e.IdUser, e.IdMessages })
                    .HasName("PK__Messages__5C5ECA108E66270A");

                entity.ToTable("Messages_for_user");

                entity.Property(e => e.IdUser)
                    .HasColumnName("idUser")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.IdMessages).HasColumnName("idMessages");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdMessagesNavigation)
                    .WithMany(p => p.MessagesForUser)
                    .HasForeignKey(d => d.IdMessages)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Messages___idMes__4F7CD00D");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.MessagesForUser)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Messages___idUse__4E88ABD4");
            });

            modelBuilder.Entity<NumberPayments>(entity =>
            {
                entity.ToTable("Number_payments");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Detail)
                    .IsRequired()
                    .HasColumnName("detail")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.IdExpenses).HasColumnName("idExpenses");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sum).HasColumnName("sum");

                entity.HasOne(d => d.IdExpensesNavigation)
                    .WithMany(p => p.NumberPayments)
                    .HasForeignKey(d => d.IdExpenses)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Number_pa__idExp__3E52440B");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Permissi__3717C9822BFBB658");

                entity.Property(e => e.IdUser)
                    .HasColumnName("idUser")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.IdBudget).HasColumnName("idBudget");

                entity.Property(e => e.PermissionLevel).HasColumnName("permission_level");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.Permission)
                    .HasForeignKey<Permission>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Permissio__idUse__300424B4");

                entity.HasOne(d => d.PermissionLevelNavigation)
                    .WithMany(p => p.Permission)
                    .HasForeignKey(d => d.PermissionLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permission_PermissionLevel");
            });

            modelBuilder.Entity<PermissionLevel>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.DateBirth)
                    .HasColumnName("date_birth")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
