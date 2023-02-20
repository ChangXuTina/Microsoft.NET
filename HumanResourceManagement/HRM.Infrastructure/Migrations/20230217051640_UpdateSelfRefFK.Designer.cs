﻿// <auto-generated />
using System;
using HRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HRM.Infrastructure.Migrations
{
    [DbContext(typeof(HRMDbContext))]
    [Migration("20230217051640_UpdateSelfRefFK")]
    partial class UpdateSelfRefFK
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HRM.ApllicationCore.Entity.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("ResumeUrl")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Candidate");
                });

            modelBuilder.Entity("HRM.ApllicationCore.Entity.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CurrentAddress")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.Property<int>("EmployeeRoleId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeStatusId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeRoleId");

                    b.HasIndex("EmployeeStatusId");

                    b.HasIndex("EmployeeTypeId");

                    b.HasIndex("ManagerId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("HRM.ApllicationCore.Entity.EmployeeRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("EmployeeRole");
                });

            modelBuilder.Entity("HRM.ApllicationCore.Entity.EmployeeStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("EmployeeStatus");
                });

            modelBuilder.Entity("HRM.ApllicationCore.Entity.EmployeeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("EmployeeType");
                });

            modelBuilder.Entity("HRM.ApllicationCore.Entity.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ABBR")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("InterviewId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InterviewId");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("HRM.ApllicationCore.Entity.Interview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("InterviewDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InterviewRound")
                        .HasColumnType("int");

                    b.Property<int>("InterviewStatusId")
                        .HasColumnType("int");

                    b.Property<int>("InterviewTypeId")
                        .HasColumnType("int");

                    b.Property<int>("InterviewerId")
                        .HasColumnType("int");

                    b.Property<int>("SubmissionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InterviewStatusId");

                    b.HasIndex("InterviewTypeId");

                    b.HasIndex("InterviewerId");

                    b.HasIndex("SubmissionId");

                    b.ToTable("Interview");
                });

            modelBuilder.Entity("HRM.ApllicationCore.Entity.InterviewStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("InterviewStatus");
                });

            modelBuilder.Entity("HRM.ApllicationCore.Entity.InterviewType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("InterviewType");
                });

            modelBuilder.Entity("HRM.ApllicationCore.Entity.JobCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("JobCategory");
                });

            modelBuilder.Entity("HRM.ApllicationCore.Entity.JobRequirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ClosingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("JobCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("JobLocation")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("PostingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TotalPositions")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobCategoryId");

                    b.ToTable("JobRequirement");
                });

            modelBuilder.Entity("HRM.ApllicationCore.Entity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("HRM.ApllicationCore.Entity.Submission", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("AppliedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<int>("JobRequirementId")
                        .HasColumnType("int");

                    b.Property<int>("JobRequredmentId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("JobRequirementId");

                    b.ToTable("Submission");
                });

            modelBuilder.Entity("HRM.ApllicationCore.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("HRM.ApllicationCore.Entity.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("HRM.ApllicationCore.Entity.Employee", b =>
                {
                    b.HasOne("HRM.ApllicationCore.Entity.EmployeeRole", "EmployeeRole")
                        .WithMany()
                        .HasForeignKey("EmployeeRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRM.ApllicationCore.Entity.EmployeeStatus", "EmployeeStatus")
                        .WithMany()
                        .HasForeignKey("EmployeeStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRM.ApllicationCore.Entity.EmployeeType", "EmployeeType")
                        .WithMany()
                        .HasForeignKey("EmployeeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRM.ApllicationCore.Entity.Employee", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");

                    b.Navigation("EmployeeRole");

                    b.Navigation("EmployeeStatus");

                    b.Navigation("EmployeeType");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("HRM.ApllicationCore.Entity.Feedback", b =>
                {
                    b.HasOne("HRM.ApllicationCore.Entity.Interview", "Interview")
                        .WithMany()
                        .HasForeignKey("InterviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interview");
                });

            modelBuilder.Entity("HRM.ApllicationCore.Entity.Interview", b =>
                {
                    b.HasOne("HRM.ApllicationCore.Entity.InterviewStatus", "InterviewStatus")
                        .WithMany()
                        .HasForeignKey("InterviewStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRM.ApllicationCore.Entity.InterviewType", "InterviewType")
                        .WithMany()
                        .HasForeignKey("InterviewTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRM.ApllicationCore.Entity.Employee", "Interviewer")
                        .WithMany()
                        .HasForeignKey("InterviewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRM.ApllicationCore.Entity.Submission", "Submission")
                        .WithMany()
                        .HasForeignKey("SubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InterviewStatus");

                    b.Navigation("InterviewType");

                    b.Navigation("Interviewer");

                    b.Navigation("Submission");
                });

            modelBuilder.Entity("HRM.ApllicationCore.Entity.JobRequirement", b =>
                {
                    b.HasOne("HRM.ApllicationCore.Entity.JobCategory", "JobCategory")
                        .WithMany()
                        .HasForeignKey("JobCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobCategory");
                });

            modelBuilder.Entity("HRM.ApllicationCore.Entity.Submission", b =>
                {
                    b.HasOne("HRM.ApllicationCore.Entity.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRM.ApllicationCore.Entity.JobRequirement", "JobRequirement")
                        .WithMany()
                        .HasForeignKey("JobRequirementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("JobRequirement");
                });

            modelBuilder.Entity("HRM.ApllicationCore.Entity.UserRole", b =>
                {
                    b.HasOne("HRM.ApllicationCore.Entity.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRM.ApllicationCore.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
