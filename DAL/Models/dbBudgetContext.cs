using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

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
        public virtual DbSet<Expense> Expense { get; set; }
        public virtual DbSet<Income> Income { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<MessagesForUser> MessagesForUser { get; set; }
        public virtual DbSet<NumberPayments> NumberPayments { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PermissionLevel> PermissionLevels { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= (LocalDB)\\MSSQLLocalDB;Database= dbBudget;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.ToTable("bank");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("link");

                entity.Property(e => e.NameBank)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name_bank");
            });

            modelBuilder.Entity<BankOfBudget>(entity =>
            {
                entity.HasKey(e => e.IdBank)
                    .HasName("PK__Bank_of___DCE603C04DA31C6C");

                entity.ToTable("Bank_of_budget");

                entity.Property(e => e.IdBank)
                    .ValueGeneratedNever()
                    .HasColumnName("idBank");

                entity.Property(e => e.IdBudget).HasColumnName("idBudget");

                entity.HasOne(d => d.IdBankNavigation)
                    .WithOne(p => p.BankOfBudget)
                    .HasForeignKey<BankOfBudget>(d => d.IdBank)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bank_of_b__idBan__30F848ED");

                entity.HasOne(d => d.IdBudgetNavigation)
                    .WithMany(p => p.BankOfBudgets)
                    .HasForeignKey(d => d.IdBudget)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bank_of_b__idBud__31EC6D26");
            });

            modelBuilder.Entity<Budget>(entity =>
            {
                entity.ToTable("Budget");

                entity.Property(e => e.Manager)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("manager")
                    .IsFixedLength(true);

                entity.Property(e => e.NameBudget)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name_budget");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("type")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("category");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Detail)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("detail");

                entity.Property(e => e.Document)
                    .IsRequired()
                    .HasColumnType("image")
                    .HasColumnName("document");

                entity.Property(e => e.Frequency).HasColumnName("frequency");

                entity.Property(e => e.IdBudget).HasColumnName("idBudget");

                entity.Property(e => e.NumberOfPayments).HasColumnName("number_of_payments");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("payment_method");

                entity.Property(e => e.Statusstatus)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("statusstatus");

                entity.Property(e => e.Subcategory)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("subcategory");

                entity.Property(e => e.Sum).HasColumnName("sum");

                entity.HasOne(d => d.IdBudgetNavigation)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.IdBudget)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Expenses__idBudg__3A81B327");
            });

            modelBuilder.Entity<Income>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("category");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Detail)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("detail");

                entity.Property(e => e.Document)
                    .IsRequired()
                    .HasColumnType("image")
                    .HasColumnName("document");

                entity.Property(e => e.IdBudget).HasColumnName("idBudget");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Payment method");

                entity.Property(e => e.SourceOfIncome)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("source_of_income");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Sum).HasColumnName("sum");

                entity.HasOne(d => d.IdBudgetNavigation)
                    .WithMany(p => p.Incomes)
                    .HasForeignKey(d => d.IdBudget)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Incomes__idBudge__37A5467C");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("category");

                entity.Property(e => e.Details)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("details");

                entity.Property(e => e.EligibilityAge)
                    .HasColumnType("date")
                    .HasColumnName("eligibility_age");

                entity.Property(e => e.IdBank).HasColumnName("idBank");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("subject");

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
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("idUser");

                entity.Property(e => e.IdMessages).HasColumnName("idMessages");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdMessagesNavigation)
                    .WithMany(p => p.MessagesForUsers)
                    .HasForeignKey(d => d.IdMessages)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Messages___idMes__4F7CD00D");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.MessagesForUsers)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Messages___idUse__4E88ABD4");
            });

            modelBuilder.Entity<NumberPayment>(entity =>
            {
                entity.ToTable("Number_payments");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Detail)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("detail");

                entity.Property(e => e.IdExpenses).HasColumnName("idExpenses");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status");

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

                entity.ToTable("Permission");

                entity.Property(e => e.IdUser)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("idUser");

                entity.Property(e => e.IdBudget).HasColumnName("idBudget");

                entity.Property(e => e.PermissionLevel).HasColumnName("permission_level");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.Permission)
                    .HasForeignKey<Permission>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Permissio__idUse__300424B4");

                entity.HasOne(d => d.PermissionLevelNavigation)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.PermissionLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permission_PermissionLevel");
            });

            modelBuilder.Entity<PermissionLevel>(entity =>
            {
                entity.ToTable("PermissionLevel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.DateBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_birth");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("first name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("last name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
