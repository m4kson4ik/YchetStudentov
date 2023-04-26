using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace YchetStudentov.Models;

public partial class YcotStudentContext : DbContext
{
    public YcotStudentContext()
    {
    }

    public YcotStudentContext(DbContextOptions<YcotStudentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<All> Alls { get; set; }

    public virtual DbSet<DataGridUcheb> DataGridUchebs { get; set; }

    public virtual DbSet<DataGridUchebPlan> DataGridUchebPlans { get; set; }

    public virtual DbSet<Distceplini> Distceplinis { get; set; }
    public virtual DbSet<FinalGrades> FinalGrades { get; set; }

    public virtual DbSet<GetKolvoStudent> GetKolvoStudents { get; set; }

    public virtual DbSet<GetPredmet> GetPredmets { get; set; }

    public virtual DbSet<GridReplayUchebPlan> GridReplayUchebPlans { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<OzenkiSelectStudent> OzenkiSelectStudents { get; set; }

    public virtual DbSet<Poseshaemost> Poseshaemosts { get; set; }

    public virtual DbSet<Prepodovateli> Prepodovatelis { get; set; }

    public virtual DbSet<SelectPredmetAndGroup> SelectPredmetAndGroups { get; set; }
    public virtual DbSet<GradesGetInfo> GradesGetInfo { get; set; }

    public virtual DbSet<Specialnosti> Specialnostis { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentOzenki> StudentOzenkis { get; set; }

    public virtual DbSet<StudentsView> StudentsViews { get; set; }

    public virtual DbSet<UchebPlan> UchebPlans { get; set; }

    public virtual DbSet<Zanyatie> Zanyaties { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("server=.\\STP;Trusted_Connection=Yes;TrustServerCertificate=True;DataBase=ycot_student;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<All>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("All");

            entity.Property(e => e.Expr1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Family)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Family");
            entity.Property(e => e.KolvoHourse).HasColumnName("kolvo_hourse");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name");
            entity.Property(e => e.Ocenka)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ocenka");
            entity.Property(e => e.Otchestvo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Otchestvo");
        });

        modelBuilder.Entity<DataGridUcheb>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("DataGridUcheb");
         
            entity.Property(e => e.Family)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Family");
            entity.Property(e => e.FormaAttest)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("forma_attest");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name");
            entity.Property(e => e.NameDisceplini)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name_disceplini");
            entity.Property(e => e.NumberGroup)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("number_group");
            entity.Property(e => e.Otchestvo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Otchestvo");
            entity.Property(e => e.NumberUchebplan)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("number_ucheb_plan");
            entity.Property(e => e.NumberDisceplinis)
               .HasMaxLength(100)
               .IsUnicode(false)
               .HasColumnName("number_disceplini");
        });

        modelBuilder.Entity<GradesGetInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GradesGetInfo");

            entity.Property(e => e.date)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("date");
            entity.Property(e => e.semestr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("semestr");
            entity.Property(e => e.name_disceplini)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name_disceplini");
            entity.Property(e => e.grades)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("grades");
            entity.Property(e => e.name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name");
            entity.Property(e => e.family)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Family");
            entity.Property(e => e.number_zac_knig)
               .HasMaxLength(100)
               .IsUnicode(false)
               .HasColumnName("number_zac_knig");
            entity.Property(e => e.number_grades)
               .HasMaxLength(100)
               .IsUnicode(false)
               .HasColumnName("number_grades");
            entity.Property(e => e.number_disceplini)
               .HasMaxLength(100)
               .IsUnicode(false)
               .HasColumnName("number_disceplini");
        });

        modelBuilder.Entity<DataGridUchebPlan>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("DataGridUchebPlan");

            entity.Property(e => e.NameDisceplini)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name_disceplini");
        });

        modelBuilder.Entity<Distceplini>(entity =>
        {
            entity.HasKey(e => e.NumberDisceplini);

            entity.ToTable("Distceplini");

            entity.Property(e => e.NumberDisceplini)
                .ValueGeneratedNever()
                .HasColumnName("number_disceplini");
            entity.Property(e => e.FormaAttest)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("forma_attest");
            entity.Property(e => e.LoginPrepodovatela).HasColumnName("login_prepodovatela");
            entity.Property(e => e.NameDisceplini)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name_disceplini");

            entity.HasOne(d => d.LoginPrepodovatelaNavigation).WithMany(p => p.Distceplinis)
                .HasForeignKey(d => d.LoginPrepodovatela)
                .HasConstraintName("FK_Distceplini_Prepodovateli1");
        });
        modelBuilder.Entity<FinalGrades>(entity =>
        {
            entity.HasKey(e => e.NumberGrades);

            entity.ToTable("FinalGrades");

            entity.Property(e => e.NumberGrades) //////////////////////////////////////////////////////////////////
                .HasColumnName("number_grades");
            entity.Property(e => e.semestr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("semestr");
            entity.Property(e => e.grades)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("grades");
            entity.Property(e => e.date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.NumberDisceplini).HasColumnName("number_disceplini");
            entity.Property(e => e.NumberZacKnig)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("number_zac_knig");
        });

        modelBuilder.Entity<GetKolvoStudent>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetKolvoStudent");

            entity.Property(e => e.Kolvo).HasColumnName("kolvo");
            entity.Property(e => e.NumberGroup)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("number_group");
        });

        modelBuilder.Entity<GetPredmet>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetPredmet");

            entity.Property(e => e.LoginPrepodovatela).HasColumnName("login_prepodovatela");
            entity.Property(e => e.NameDisceplini)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name_disceplini");
            entity.Property(e => e.NumberGroup)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("number_group");
        });

        modelBuilder.Entity<GridReplayUchebPlan>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GridReplayUchebPlan");

            entity.Property(e => e.NameDisceplini)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name_disceplini");
            entity.Property(e => e.NumberGroup)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("number_group");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.NumberGroup);

            entity.Property(e => e.NumberGroup)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("number_group");
            entity.Property(e => e.Kurator)
                .HasMaxLength(130)
                .IsUnicode(false)
                .HasColumnName("kurator");
            entity.Property(e => e.NumberSpecialnosti)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("number_specialnosti");
            entity.Property(e => e.PolnNameSpec)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("poln_name_spec");

            entity.HasOne(d => d.NumberSpecialnostiNavigation).WithMany(p => p.Groups)
                .HasForeignKey(d => d.NumberSpecialnosti)
                .HasConstraintName("FK_Groups_Specialnosti1");
        });

        modelBuilder.Entity<OzenkiSelectStudent>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OzenkiSelectStudent");

            entity.Property(e => e.LoginPrepodovatela).HasColumnName("login_prepodovatela");
            entity.Property(e => e.NameDisceplini)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name_disceplini");
            entity.Property(e => e.NumberGroup)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("number_group");
        });

        modelBuilder.Entity<Poseshaemost>(entity =>
        {
            entity.HasKey(e => e.NumberUspevaemosti).HasName("PK_Poseshaemost_1");

            entity.ToTable("Poseshaemost");

            entity.Property(e => e.NumberUspevaemosti).HasColumnName("number_uspevaemosti");
            entity.Property(e => e.DataZanyatie)
                .HasColumnType("date")
                .HasColumnName("data_zanyatie");
            entity.Property(e => e.NumberDistceplini).HasColumnName("number_distceplini");
            entity.Property(e => e.NumberZacKnig).HasColumnName("number_zac_knig");
            entity.Property(e => e.Ocenka)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ocenka");

            entity.HasOne(d => d.NumberZacKnigNavigation).WithMany(p => p.Poseshaemosts)
                .HasForeignKey(d => d.NumberZacKnig)
                .HasConstraintName("FK_Poseshaemost_Student1");
        });


        modelBuilder.Entity<Prepodovateli>(entity =>
        {
            entity.HasKey(e => e.LoginPrepodovatela);

            entity.ToTable("Prepodovateli");

            entity.Property(e => e.LoginPrepodovatela)
                .ValueGeneratedNever()
                .HasColumnName("login_prepodovatela");
            entity.Property(e => e.Family)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Family");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name");
            entity.Property(e => e.Otchestvo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Otchestvo");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<SelectPredmetAndGroup>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SelectPredmetAndGroup");

            entity.Property(e => e.NumberGroup)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("number_group");
        });

        modelBuilder.Entity<Specialnosti>(entity =>
        {
            entity.HasKey(e => e.NumberSpecialnosti);

            entity.ToTable("Specialnosti");

            entity.Property(e => e.NumberSpecialnosti)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("number_specialnosti");
            entity.Property(e => e.NameSpecialnosti)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name_specialnosti");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.NumberZacKnig);

            entity.ToTable("Student");

            entity.Property(e => e.NumberZacKnig)
                .ValueGeneratedNever()
                .HasColumnName("number_zac_knig");
            entity.Property(e => e.AdressProj)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("adress_proj");
            entity.Property(e => e.Budget)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("budget");
            entity.Property(e => e.DataRoj)
                .HasColumnType("date")
                .HasColumnName("data_roj");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Family)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Family");
            entity.Property(e => e.GodPostuplenya).HasColumnName("god_postuplenya");
            entity.Property(e => e.Gragdanstvo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gragdanstvo");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name");
            entity.Property(e => e.NumberGroup)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("number_group");
            entity.Property(e => e.Otchesto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("otchesto");

            entity.HasOne(d => d.NumberGroupNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.NumberGroup)
                .HasConstraintName("FK_Student_Groups1");
        });

        modelBuilder.Entity<StudentOzenki>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("StudentOzenki");

            entity.Property(e => e.DataZanyatie)
                .HasColumnType("date")
                .HasColumnName("data_zanyatie");
            entity.Property(e => e.Family)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Family");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name");
            entity.Property(e => e.NameDisceplini)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name_disceplini");
            entity.Property(e => e.NumberGroup)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("number_group");
            entity.Property(e => e.NumberZacKnig).HasColumnName("number_zac_knig");
            entity.Property(e => e.Ocenka)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ocenka");
            entity.Property(e => e.NumberUspevaemosti)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("number_uspevaemosti");
        });

        modelBuilder.Entity<StudentsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("StudentsView");

            entity.Property(e => e.Family)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Family");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name");
            entity.Property(e => e.NumberGroup)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("number_group");
            entity.Property(e => e.NumberZacKnig).HasColumnName("number_zac_knig");
        });

        modelBuilder.Entity<UchebPlan>(entity =>
        {
            entity.HasKey(e => e.NumberUchebPlan);

            entity.ToTable("UchebPlan");

            entity.Property(e => e.NumberUchebPlan).HasColumnName("number_ucheb_plan");
            entity.Property(e => e.NumberDisceplini).HasColumnName("number_disceplini");
            entity.Property(e => e.NumberGroup)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("number_group");

            entity.HasOne(d => d.NumberDiscepliniNavigation).WithMany(p => p.UchebPlans)
                .HasForeignKey(d => d.NumberDisceplini)
                .HasConstraintName("FK_UchebPlan_Distceplini1");

            entity.HasOne(d => d.NumberGroupNavigation).WithMany(p => p.UchebPlans)
                .HasForeignKey(d => d.NumberGroup)
                .HasConstraintName("FK_UchebPlan_Groups1");
        });

        modelBuilder.Entity<Zanyatie>(entity =>
        {
            entity.HasKey(e => e.NumberZanyatia).HasName("PK_Poseshaemost");

            entity.ToTable("Zanyatie");

            entity.Property(e => e.NumberZanyatia)
                .ValueGeneratedNever()
                .HasColumnName("number_zanyatia");
            entity.Property(e => e.DataProvedenie)
                .HasColumnType("date")
                .HasColumnName("data_provedenie");
            entity.Property(e => e.NameDisceplini)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name_disceplini");
            entity.Property(e => e.TypeZanyatia)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("type_zanyatia");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
