using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebWord.Models;

namespace WebWord.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Word> Words { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Vocabulary> Vocabularies { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
