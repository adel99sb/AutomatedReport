using AutomatedReportAPI.AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomatedReportAPI.AppData.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        #region DbSets
        public DbSet<_Class> Classes { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Sessions_Record> Sessions_Records { get; set; }
        public DbSet<DailySessions_Record> DailySessions_Records { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Test_Mark> Test_Marks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<GratitudeStudent> GratitudeStudents { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Remove cascade delete convention for all relationships
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.Entity<Subject>()
            .HasOne(s => s.Certificate)
            .WithMany()
            .HasForeignKey(s => s.CertificateId);
            // Data Seeds
            #region Certificate   
            Certificate[] certificates = new Certificate[] {
                new Certificate()
                {
                    Name = "الشهادة الإعدادية"
                },
                new Certificate()
                {
                    Name = "الشهادة الثانوية - أدبي"
                },
                new Certificate()
                {
                    Name = "الشهادة الثانوية - علمي"
                }
             };
            modelBuilder.Entity<Certificate>()
                .HasData(certificates);
            #endregion
            #region Subjects
            #region NinthSubjects            
            Subject[] NinthSubjects = new Subject[]
            {
                new Subject()
                    {
                        Name = "رياضيات"
                    },
                    new Subject()
                    {
                        Name = "فيزياء و كيمياء"
                    },
                    new Subject()
                    {
                        Name = "علوم"
                    },
                    new Subject()
                    {
                        Name = "لغة انكليزية"
                    },
                    new Subject()
                    {
                        Name = "لغة فرنسية"
                    },
                    new Subject()
                    {
                        Name = "لغة عربية"
                    },
                    new Subject()
                    {
                        Name = "اجتماعيات"
                    },
                    new Subject()
                    {
                        Name = "ديانة"
                    }
            };
            foreach (var NS in NinthSubjects)
            {
                NS.CertificateId = certificates[0].Id;
            }
            modelBuilder.Entity<Subject>()
                .HasData(NinthSubjects);
            #endregion
            #region Literary_SecondarySubjects
            Subject[] Literary_SecondarySubjects = new Subject[]
                {
                    new Subject()
                    {
                        Name = "جغرافيا"
                    },
                    new Subject()
                    {
                        Name = "لغة عربية"
                    },
                    new Subject()
                    {
                        Name = "لغة فرنسية"
                    },
                    new Subject()
                    {
                        Name = "وطنية"
                    },
                    new Subject()
                    {
                        Name = "فلسفة"
                    },
                    new Subject()
                    {
                        Name = "لغة انكليزية"
                    },
                    new Subject()
                    {
                        Name = "ديانة"
                    },
                    new Subject()
                    {
                        Name = "تاريخ"
                    }
                };
            foreach (var LS in Literary_SecondarySubjects)
            {
                LS.CertificateId = certificates[1].Id;
            }
            modelBuilder.Entity<Subject>()
                .HasData(Literary_SecondarySubjects);
            #endregion
            #region Scientific_SecondarySubjects
            Subject[] Scientific_SecondarySubjects = new Subject[]
                {
                    new Subject()
                    {
                        Name = "فيزياء"
                    },
                    new Subject()
                    {
                        Name = "لغة عربية"
                    },
                    new Subject()
                    {
                        Name = "لغة فرنسية"
                    },
                    new Subject()
                    {
                        Name = "وطنية"
                    },
                    new Subject()
                    {
                        Name = "رياضيات"
                    },
                    new Subject()
                    {
                        Name = "لغة انكليزية"
                    },
                    new Subject()
                    {
                        Name = "ديانة"
                    },
                    new Subject()
                    {
                        Name = "علم أحياء"
                    },
                    new Subject()
                    {
                        Name = "كيمياء"
                    }
                };
            foreach (var SS in Scientific_SecondarySubjects)
            {
                SS.CertificateId = certificates[2].Id;
            }
            modelBuilder.Entity<Subject>()
                .HasData(Scientific_SecondarySubjects);
            #endregion
            #endregion
            #region Classes
            modelBuilder.Entity<_Class>().HasData(
                new _Class()
                {
                    Name = "الحصة الأولى",
                    From_Time = "08:30",
                    To_Time = "10:00"
                },
                new _Class()
                {
                    Name = "الحصة الثانية",
                    From_Time = "10:00",
                    To_Time = "11:30"
                },
                new _Class()
                {
                    Name = "الحصة الثالثة",
                    From_Time = "11:30",
                    To_Time = "01:00"
                },
                new _Class()
                {
                    Name = "الحصة الرابعة",
                    From_Time = "01:00",
                    To_Time = "02:30"
                },
                new _Class()
                {
                    Name = "الحصة الخامسة",
                    From_Time = "02:30",
                    To_Time = "03:00"
                },
                new _Class()
                {
                    Name = "الحصة السادسة",
                    From_Time = "03:00",
                    To_Time = "04:30"
                });
            #endregion
            #region Useres
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Type = "مدير",
                    Password = "AaBbCc@112233"
                },
                new User()
                {
                    Type = "مشرف",
                    Password = "Aa@112233"
                });
            #endregion
        }
    }
}
