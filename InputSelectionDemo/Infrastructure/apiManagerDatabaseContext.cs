using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InputSelectionDemo.Infrastructure
{
    public partial class apiManagerDatabaseContext : DbContext
    {
        public apiManagerDatabaseContext()
        {
        }

        public apiManagerDatabaseContext(DbContextOptions<apiManagerDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FltSageLanding> FltSageLanding { get; set; }
        public virtual DbSet<TCustomFieldDefn> TCustomFieldDefn { get; set; }
        public virtual DbSet<TCustomFieldValues> TCustomFieldValues { get; set; }
        public virtual DbSet<TMerchant> TMerchant { get; set; }
        public virtual DbSet<TPatient> TPatient { get; set; }
        public virtual DbSet<TPatientFormChklist> TPatientFormChklist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=L-SAKOSILE;Database=apiManagerDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<FltSageLanding>(entity =>
            {
                entity.HasKey(e => e.SageId);

                entity.Property(e => e.SageId).HasColumnName("SageID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.FetchDate).HasColumnType("datetime");

                entity.Property(e => e.MembershipGrade)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.ProcessDate).HasColumnType("datetime");

                entity.Property(e => e.ProcessingCode)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransRef)
                    .HasMaxLength(350)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TCustomFieldDefn>(entity =>
            {
                entity.HasKey(e => e.CustomId);

                entity.ToTable("t_custom_field_defn");

                entity.Property(e => e.CustomId).HasColumnName("custom_id");

                entity.Property(e => e.Label)
                    .HasColumnName("label")
                    .HasMaxLength(50);

                entity.Property(e => e.MerchantId).HasColumnName("merchant_id");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.TCustomFieldDefn)
                    .HasForeignKey(d => d.MerchantId)
                    .HasConstraintName("fk1_custom_field");
            });

            modelBuilder.Entity<TCustomFieldValues>(entity =>
            {
                entity.HasKey(e => e.PatientId);

                entity.ToTable("t_custom_field_values");

                entity.Property(e => e.PatientId)
                    .HasColumnName("patient_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustomId).HasColumnName("custom_id");

                entity.Property(e => e.MerchantId).HasColumnName("merchant_id");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.TCustomFieldValues)
                    .HasForeignKey(d => d.MerchantId)
                    .HasConstraintName("FK_t_custom_field_values_t_merchant");
            });

            modelBuilder.Entity<TMerchant>(entity =>
            {
                entity.HasKey(e => e.MerchantId);

                entity.ToTable("t_merchant");

                entity.Property(e => e.MerchantId).HasColumnName("merchant_id");

                entity.Property(e => e.MerchantCode)
                    .HasColumnName("merchant_code")
                    .HasMaxLength(50);

                entity.Property(e => e.MerchantName)
                    .HasColumnName("merchant_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TPatient>(entity =>
            {
                entity.HasKey(e => e.PatientId);

                entity.ToTable("t_patient");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.PatientAddress)
                    .HasColumnName("patient_address")
                    .HasMaxLength(50);

                entity.Property(e => e.PatientEmail)
                    .HasColumnName("patient_email")
                    .HasMaxLength(50);

                entity.Property(e => e.PatientGender)
                    .HasColumnName("patient_gender")
                    .HasMaxLength(50);

                entity.Property(e => e.PatientName)
                    .HasColumnName("patient_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TPatientFormChklist>(entity =>
            {
                entity.HasKey(e => e.ChklistId);

                entity.ToTable("t_patient_form_chklist");

                entity.Property(e => e.ChklistId)
                    .HasColumnName("chklist_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IsPatientAddressChkd).HasColumnName("is_patient_address_chkd");

                entity.Property(e => e.IsPatientEmailChkd).HasColumnName("is_patient_email_chkd");

                entity.Property(e => e.IsPatientGenderChkd).HasColumnName("is_patient_gender_chkd");

                entity.Property(e => e.IsPatientNameChkd).HasColumnName("is_patient_name_chkd");

                entity.Property(e => e.MerchantId).HasColumnName("merchant_id");

                entity.Property(e => e.PatientNameLabel)
                    .HasColumnName("patient_name_label")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.TPatientFormChklist)
                    .HasForeignKey(d => d.MerchantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_patient_form_chklist_t_merchant");
            });
        }
    }
}
