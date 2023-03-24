using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Office.DataLayer.Data
{
    public partial class db_a9696f_officeContext : DbContext
    {
        public db_a9696f_officeContext()
        {
        }

        public db_a9696f_officeContext(DbContextOptions<db_a9696f_officeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Absent> Absents { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<EarlyLeft> EarlyLefts { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeType> EmployeeTypes { get; set; } = null!;
        public virtual DbSet<Leave> Leaves { get; set; } = null!;
        public virtual DbSet<MissingPunch> MissingPunches { get; set; } = null!;
        public virtual DbSet<Present> Presents { get; set; } = null!;
        public virtual DbSet<Punch> Punches { get; set; } = null!;
        public virtual DbSet<PunchType> PunchTypes { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("Server=mysql8003.site4now.net;Port=3306;User=a9696f_office;Password=zubair@123;Database=db_a9696f_office");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Absent>(entity =>
            {
                entity.HasKey(e => e.AbId)
                    .HasName("PRIMARY");

                entity.ToTable("absents");

                entity.HasIndex(e => e.AbEmpId, "fk_absents_employees1_idx");

                entity.Property(e => e.AbId).HasColumnName("ab_id");

                entity.Property(e => e.AbDate)
                    .HasColumnType("date")
                    .HasColumnName("ab_date");

                entity.Property(e => e.AbEmpId).HasColumnName("ab_emp_id");

                entity.HasOne(d => d.AbEmp)
                    .WithMany(p => p.Absents)
                    .HasForeignKey(d => d.AbEmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_absents_employees1");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepId)
                    .HasName("PRIMARY");

                entity.ToTable("department");

                entity.HasComment("	");

                entity.Property(e => e.DepId).HasColumnName("dep_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(45)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<EarlyLeft>(entity =>
            {
                entity.HasKey(e => e.ElId)
                    .HasName("PRIMARY");

                entity.ToTable("early_left");

                entity.HasIndex(e => e.ElEmpId, "fk_early_left_employees1_idx");

                entity.Property(e => e.ElId).HasColumnName("el_id");

                entity.Property(e => e.ElDate)
                    .HasColumnType("date")
                    .HasColumnName("el_date");

                entity.Property(e => e.ElEmpId).HasColumnName("el_emp_id");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PRIMARY");

                entity.ToTable("employees");

                entity.HasIndex(e => e.EmpDepId, "fk_employees_department1_idx");

                entity.HasIndex(e => e.EmpTypeId, "fk_employees_employee_type1_idx");

                entity.Property(e => e.EmpId).HasColumnName("emp_id");

                entity.Property(e => e.EmpDepId).HasColumnName("emp_dep_id");

                entity.Property(e => e.EmpEmail)
                    .HasMaxLength(45)
                    .HasColumnName("emp_email");

                entity.Property(e => e.EmpFirstName)
                    .HasMaxLength(45)
                    .HasColumnName("emp_first_name");

                entity.Property(e => e.EmpLastName)
                    .HasMaxLength(45)
                    .HasColumnName("emp_last_name");

                entity.Property(e => e.EmpPassword)
                    .HasMaxLength(45)
                    .HasColumnName("emp_password");

                entity.Property(e => e.EmpPhoneNo)
                    .HasMaxLength(45)
                    .HasColumnName("emp_phone_no");

                entity.Property(e => e.EmpTypeId).HasColumnName("emp_type_id");

                entity.Property(e => e.HireDate)
                    .HasColumnType("date")
                    .HasColumnName("hire_date");

                entity.Property(e => e.ManagerId)
                    .HasMaxLength(45)
                    .HasColumnName("manager_id");

                entity.HasOne(d => d.EmpDep)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmpDepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employees_department1");

                entity.HasOne(d => d.EmpType)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmpTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employees_employee_type1");
            });

            modelBuilder.Entity<EmployeeType>(entity =>
            {
                entity.HasKey(e => e.EmpTypeId)
                    .HasName("PRIMARY");

                entity.ToTable("employee_type");

                entity.Property(e => e.EmpTypeId).HasColumnName("emp_type_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Title)
                    .HasMaxLength(45)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Leave>(entity =>
            {
                entity.HasKey(e => e.LeId)
                    .HasName("PRIMARY");

                entity.ToTable("leave");

                entity.HasComment("		");

                entity.HasIndex(e => e.LeEmpId, "fk_leave_employees1_idx");

                entity.Property(e => e.LeId).HasColumnName("le_id");

                entity.Property(e => e.LeApplyForDate1)
                    .HasColumnType("date")
                    .HasColumnName("le_apply_for_date1");

                entity.Property(e => e.LeApplyForDate2)
                    .HasColumnType("date")
                    .HasColumnName("le_apply_for_date2");

                entity.Property(e => e.LeApplyToEmpId).HasColumnName("le_apply_to_emp_id");

                entity.Property(e => e.LeApplyingDate)
                    .HasColumnType("date")
                    .HasColumnName("le_applying_date");

                entity.Property(e => e.LeApprove)
                    .HasColumnType("bit(1)")
                    .HasColumnName("le_approve");

                entity.Property(e => e.LeEmpId).HasColumnName("le_emp_id");

                entity.HasOne(d => d.LeEmp)
                    .WithMany(p => p.Leaves)
                    .HasForeignKey(d => d.LeEmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_leave_employees1");
            });

            modelBuilder.Entity<MissingPunch>(entity =>
            {
                entity.HasKey(e => e.MpId)
                    .HasName("PRIMARY");

                entity.ToTable("missing_punches");

                entity.HasIndex(e => e.EmployeesEmpId, "fk_missing_punches_employees1_idx");

                entity.Property(e => e.MpId).HasColumnName("mp_id");

                entity.Property(e => e.EmployeesEmpId).HasColumnName("employees_emp_id");

                entity.Property(e => e.MpDate)
                    .HasColumnType("date")
                    .HasColumnName("mp_date");

                entity.Property(e => e.MpEmpId)
                    .HasMaxLength(45)
                    .HasColumnName("mp_emp_id");

                entity.Property(e => e.MpExpectedTime)
                    .HasColumnType("timestamp")
                    .HasColumnName("mp_expected_time");

                entity.Property(e => e.MpType)
                    .HasMaxLength(45)
                    .HasColumnName("mp_type");

                entity.HasOne(d => d.EmployeesEmp)
                    .WithMany(p => p.MissingPunches)
                    .HasForeignKey(d => d.EmployeesEmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_missing_punches_employees1");
            });

            modelBuilder.Entity<Present>(entity =>
            {
                entity.HasKey(e => e.PrId)
                    .HasName("PRIMARY");

                entity.ToTable("presents");

                entity.HasIndex(e => e.PrEmpId, "fk_presents_employees1_idx");

                entity.Property(e => e.PrId).HasColumnName("pr_id");

                entity.Property(e => e.PrDate)
                    .HasColumnType("date")
                    .HasColumnName("pr_date");

                entity.Property(e => e.PrEmpId).HasColumnName("pr_emp_id");

                entity.Property(e => e.PrWorkedHours)
                    .HasPrecision(10)
                    .HasColumnName("pr_worked_hours");

                entity.HasOne(d => d.PrEmp)
                    .WithMany(p => p.Presents)
                    .HasForeignKey(d => d.PrEmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_presents_employees1");
            });

            modelBuilder.Entity<Punch>(entity =>
            {
                entity.HasKey(e => e.PuId)
                    .HasName("PRIMARY");

                entity.ToTable("punches");

                entity.HasIndex(e => e.EmployeesEmpId, "fk_punches_employees1_idx");

                entity.HasIndex(e => e.PuTypeId, "fk_punches_punch_type1_idx");

                entity.Property(e => e.PuId).HasColumnName("pu_id");

                entity.Property(e => e.EmployeesEmpId).HasColumnName("employees_emp_id");

                entity.Property(e => e.PuTime)
                    .HasColumnType("timestamp")
                    .HasColumnName("pu_time");

                entity.Property(e => e.PuType)
                    .HasMaxLength(45)
                    .HasColumnName("pu_type");

                entity.Property(e => e.PuTypeId).HasColumnName("pu_type_id");

                entity.HasOne(d => d.EmployeesEmp)
                    .WithMany(p => p.Punches)
                    .HasForeignKey(d => d.EmployeesEmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_punches_employees1");

                entity.HasOne(d => d.PuTypeNavigation)
                    .WithMany(p => p.Punches)
                    .HasForeignKey(d => d.PuTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_punches_punch_type1");
            });

            modelBuilder.Entity<PunchType>(entity =>
            {
                entity.ToTable("punch_type");

                entity.Property(e => e.PunchTypeId).HasColumnName("punch_type_id");

                entity.Property(e => e.Title)
                    .HasMaxLength(45)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasKey(e => e.TaId)
                    .HasName("PRIMARY");

                entity.ToTable("tasks");

                entity.Property(e => e.TaId).HasColumnName("ta_id");

                entity.Property(e => e.Ta)
                    .HasMaxLength(45)
                    .HasColumnName("ta");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
