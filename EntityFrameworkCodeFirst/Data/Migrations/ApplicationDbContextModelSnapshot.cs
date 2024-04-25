﻿// <auto-generated />
using EntityFrameworkCodeFirst.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFrameworkCodeFirst.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("EntityFrameworkCodeFirst.Models.DatabaseModels.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FkTeacherId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FkTeacherId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FkTeacherId = 1,
                            Name = "Web applications in C# ASP.NET"
                        },
                        new
                        {
                            Id = 2,
                            FkTeacherId = 2,
                            Name = "Project management and agile methods"
                        });
                });

            modelBuilder.Entity("EntityFrameworkCodeFirst.Models.DatabaseModels.Enrollment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FkCourseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FkStudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FkCourseId");

                    b.HasIndex("FkStudentId");

                    b.ToTable("Enrollments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FkCourseId = 1,
                            FkStudentId = 1
                        },
                        new
                        {
                            Id = 2,
                            FkCourseId = 2,
                            FkStudentId = 2
                        },
                        new
                        {
                            Id = 3,
                            FkCourseId = 1,
                            FkStudentId = 3
                        },
                        new
                        {
                            Id = 4,
                            FkCourseId = 2,
                            FkStudentId = 3
                        },
                        new
                        {
                            Id = 5,
                            FkCourseId = 1,
                            FkStudentId = 4
                        },
                        new
                        {
                            Id = 6,
                            FkCourseId = 2,
                            FkStudentId = 4
                        });
                });

            modelBuilder.Entity("EntityFrameworkCodeFirst.Models.DatabaseModels.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FkTeacherId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FkTeacherId");

                    b.ToTable("Grades");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FkTeacherId = 1,
                            Name = ".NET23"
                        });
                });

            modelBuilder.Entity("EntityFrameworkCodeFirst.Models.DatabaseModels.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Johan",
                            LastName = "Edlund"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Heikki",
                            LastName = "Wallenberg"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Leo",
                            LastName = "Andersson"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Ellen",
                            LastName = "Blixt"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Bengt",
                            LastName = "Östrand"
                        },
                        new
                        {
                            Id = 6,
                            FirstName = "Klara",
                            LastName = "Vi"
                        });
                });

            modelBuilder.Entity("EntityFrameworkCodeFirst.Models.DatabaseModels.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FkGradeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FkPersonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FkGradeId");

                    b.HasIndex("FkPersonId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FkGradeId = 1,
                            FkPersonId = 3
                        },
                        new
                        {
                            Id = 2,
                            FkGradeId = 1,
                            FkPersonId = 4
                        },
                        new
                        {
                            Id = 3,
                            FkGradeId = 1,
                            FkPersonId = 5
                        },
                        new
                        {
                            Id = 4,
                            FkGradeId = 1,
                            FkPersonId = 6
                        });
                });

            modelBuilder.Entity("EntityFrameworkCodeFirst.Models.DatabaseModels.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FkPersonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FkPersonId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FkPersonId = 1
                        },
                        new
                        {
                            Id = 2,
                            FkPersonId = 2
                        });
                });

            modelBuilder.Entity("EntityFrameworkCodeFirst.Models.DatabaseModels.Course", b =>
                {
                    b.HasOne("EntityFrameworkCodeFirst.Models.DatabaseModels.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("FkTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("EntityFrameworkCodeFirst.Models.DatabaseModels.Enrollment", b =>
                {
                    b.HasOne("EntityFrameworkCodeFirst.Models.DatabaseModels.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("FkCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFrameworkCodeFirst.Models.DatabaseModels.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("FkStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EntityFrameworkCodeFirst.Models.DatabaseModels.Grade", b =>
                {
                    b.HasOne("EntityFrameworkCodeFirst.Models.DatabaseModels.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("FkTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("EntityFrameworkCodeFirst.Models.DatabaseModels.Student", b =>
                {
                    b.HasOne("EntityFrameworkCodeFirst.Models.DatabaseModels.Grade", "Grade")
                        .WithMany("Students")
                        .HasForeignKey("FkGradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFrameworkCodeFirst.Models.DatabaseModels.Person", "Person")
                        .WithMany()
                        .HasForeignKey("FkPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grade");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("EntityFrameworkCodeFirst.Models.DatabaseModels.Teacher", b =>
                {
                    b.HasOne("EntityFrameworkCodeFirst.Models.DatabaseModels.Person", "Person")
                        .WithMany()
                        .HasForeignKey("FkPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("EntityFrameworkCodeFirst.Models.DatabaseModels.Course", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("EntityFrameworkCodeFirst.Models.DatabaseModels.Grade", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("EntityFrameworkCodeFirst.Models.DatabaseModels.Student", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("EntityFrameworkCodeFirst.Models.DatabaseModels.Teacher", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
