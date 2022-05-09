using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace IsYonetimPro.Entities.Concrete
{
    public partial class IsYonetimSistemiDBContext : DbContext
    {
        public IsYonetimSistemiDBContext()
        {
        }

        public IsYonetimSistemiDBContext(DbContextOptions<IsYonetimSistemiDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskImportance> TaskImportances { get; set; }
        public virtual DbSet<TaskMessage> TaskMessages { get; set; }
        public virtual DbSet<TaskStatus> TaskStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
             //   optionsBuilder.UseSqlServer("Server=.;Database=IsYonetimSistemiDB;uid=sa;pwd=1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeEmail)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeePassword)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.EmployeePhone).HasColumnType("decimal(11, 0)");

                entity.Property(e => e.EmployeeSurname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.EmployeeDepartment)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeDepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Department");

                entity.HasOne(d => d.EmployeeMessage)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeMessageId)
                    .HasConstraintName("FK_Employee_TaskMessage");

                entity.HasOne(d => d.EmployeeRole)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Role");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TaskDescription).IsRequired();

                entity.Property(e => e.TaskEndDate).HasColumnType("datetime");

                entity.Property(e => e.TaskStartDate).HasColumnType("datetime");

                entity.Property(e => e.TaskTitle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TaskCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_Employee1");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TaskEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_Employee");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_Project");

                entity.HasOne(d => d.TaskDepartment)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TaskDepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_Department");

                entity.HasOne(d => d.TaskImportance)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TaskImportanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_TaskImportance");

                entity.HasOne(d => d.TaskMessage)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TaskMessageId)
                    .HasConstraintName("FK_Task_TaskMessage");

                entity.HasOne(d => d.TaskStatus)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TaskStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_TaskStatus");
            });

            modelBuilder.Entity<TaskImportance>(entity =>
            {
                entity.HasKey(e => e.ImportanceId);

                entity.ToTable("TaskImportance");

                entity.Property(e => e.ImportanceStatus)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TaskMessage>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.ToTable("TaskMessage");

                entity.Property(e => e.MessageDescription).HasMaxLength(1000);

                entity.Property(e => e.MessgeDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TaskStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("TaskStatus");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
