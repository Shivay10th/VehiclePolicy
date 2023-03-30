using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VehicleInsurance_81380.Models
{
    public partial class VI_81380Context : DbContext
    {
        public VI_81380Context()
        {
        }

        public VI_81380Context(DbContextOptions<VI_81380Context> options)
            : base(options)
        {
        }

        public virtual DbSet<PolicyClaim> PolicyClaim { get; set; }
        public virtual DbSet<PolicyApprover> PolicyApprover { get; set; }
        public virtual DbSet<PolicyCompany> PolicyCompany { get; set; }
        public virtual DbSet<PolicyHolder> PolicyHolder { get; set; }
        public virtual DbSet<PolicyDetail> PolicyDetail { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<VehiclePolicy> VehiclePolicy { get; set; }

        // Unable to generate entity type for table 'dbo.vehicle_policy_holder'. Please see the warning messages.


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PolicyClaim>(entity =>
            {
                entity.ToTable("claim");

                entity.Property(e => e.PolicyClaimId).HasColumnName("claimId");

                entity.Property(e => e.ApprovedBy).HasColumnName("approvedBy");

                entity.Property(e => e.ApprovedDate)
                    .HasColumnName("approvedDate")
                    .HasColumnType("date");

                entity.Property(e => e.ClaimAmount)
                    .HasColumnName("claimAmount")
                    .HasColumnType("decimal(20, 2)");

                entity.Property(e => e.ClaimStatus)
                    .HasColumnName("claimStatus")
                    .HasMaxLength(20);

                entity.Property(e => e.DateOfLoss)
                    .HasColumnName("dateOfLoss")
                    .HasColumnType("date");

                entity.Property(e => e.PolicyHolderId).HasColumnName("policyHolderId");

                entity.Property(e => e.PolicyId).HasColumnName("policyId");

                entity.HasOne(d => d.ApprovedByNavigation)
                    .WithMany(p => p.PolicyClaim)
                    .HasForeignKey(d => d.ApprovedBy)
                    .HasConstraintName("FK__claim__approvedB__03F0984C");

                entity.HasOne(d => d.PolicyHolder)
                    .WithMany(p => p.PolicyClaim)
                    .HasForeignKey(d => d.PolicyHolderId)
                    .HasConstraintName("FK__claim__policyHol__70DDC3D8");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.PolicyClaim)
                    .HasForeignKey(d => d.PolicyId)
                    .HasConstraintName("FK__claim__policyId__71D1E811");
            });

            modelBuilder.Entity<PolicyApprover>(entity =>
            {
                entity.HasKey(e => e.AgentId);

                entity.ToTable("policy_approver");

                entity.Property(e => e.AgentId).HasColumnName("agentId");

                entity.Property(e => e.CompanyId).HasColumnName("companyId");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.PolicyApprover)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__policy_ap__compa__02FC7413");
            });

            modelBuilder.Entity<PolicyCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyId);

                entity.ToTable("policy_company");

                entity.Property(e => e.CompanyId).HasColumnName("companyId");

                entity.Property(e => e.CPassword)
                    .IsRequired()
                    .HasColumnName("cPassword")
                    .HasMaxLength(30);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("companyName")
                    .HasMaxLength(255);

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasColumnName("contact")
                    .HasMaxLength(14);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PolicyHolder>(entity =>
            {
                entity.HasKey(e => e.HolderId);

                entity.ToTable("policy_holder");

                entity.Property(e => e.HolderId).HasColumnName("holderId");

                entity.Property(e => e.AdharNo).HasColumnName("adhar_no");

                entity.Property(e => e.CurrentAddress)
                    .HasColumnName("current_address")
                    .HasMaxLength(100);

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("date_of_birth")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(25);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(10);

                entity.Property(e => e.HPassword)
                    .HasColumnName("hPassword")
                    .HasMaxLength(45);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(25);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasColumnName("mobile")
                    .HasMaxLength(15);

                entity.Property(e => e.PanNo)
                    .IsRequired()
                    .HasColumnName("pan_no")
                    .HasMaxLength(10);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("vehicle");

                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

                entity.Property(e => e.OwnerId).HasColumnName("ownerId");

                entity.Property(e => e.VehicleChassisNo)
                    .HasColumnName("vehicle_chassis_no")
                    .HasMaxLength(255);

                entity.Property(e => e.VehicleColor)
                    .HasColumnName("vehicle_color")
                    .HasMaxLength(20);

                entity.Property(e => e.VehicleModel)
                    .HasColumnName("vehicle_model")
                    .HasMaxLength(255);

                entity.Property(e => e.VehicleRegistraionDate)
                    .HasColumnName("vehicle_registraion_date")
                    .HasColumnType("date");

                entity.Property(e => e.VehicleRegistrationNo)
                    .HasColumnName("vehicle_registration_no")
                    .HasMaxLength(255);

                entity.Property(e => e.VehicleType)
                    .HasColumnName("vehicle_type")
                    .HasMaxLength(10);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK__vehicle__ownerId__619B8048");
            });

            modelBuilder.Entity<VehiclePolicy>(entity =>
            {
                entity.HasKey(e => e.PolicyId);

                entity.ToTable("vehicle_policy");

                entity.Property(e => e.PolicyId).HasColumnName("policy_id");

                entity.Property(e => e.CompanyId).HasColumnName("companyId");

                entity.Property(e => e.TotalPayableAmt)
                    .HasColumnName("total_payble_amt")
                    .HasColumnType("decimal(20, 4)");

                entity.Property(e => e.IDV)
                    .HasColumnName("idv")
                    .HasColumnType("decimal(20, 4)");

                entity.Property(e => e.PolicyEndDate)
                    .HasColumnName("policy_end_date")
                    .HasColumnType("date");

                entity.Property(e => e.PolicyName)
                    .IsRequired()
                    .HasColumnName("policy_name")
                    .HasMaxLength(30);

                entity.Property(e => e.PolicyRegistrationDate)
                    .HasColumnName("policy_registration_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.VehiclePolicy)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__vehicle_p__compa__656C112C");

            });
        }
    }
}
