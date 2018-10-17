using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredExamDomain.Models;
namespace WiredExamDomain
{
    public class BaseClassContext : DbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<articles> articles { get; set; }
        public DbSet<question> questions { get; set; }
        public DbSet<source> sources { get; set; }
    }
}
