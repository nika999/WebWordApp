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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Vocabulary>()
                .HasOne<Word>(vocabulary => vocabulary.Word)
                .WithMany(word => word.Vocabularies)
                .HasForeignKey(vocabulary => vocabulary.WordId);


            // відношення "один-до-багатьох"
            builder.Entity<Student>() // сутність, що підлягає налаштуванню
                .HasMany<Vocabulary>(student => student.Vocabularies) // головний клас Customer містить колекцію підпорядкованих об'єктів Purchases
            .WithOne(vocabulary => vocabulary.Student) // кожен такий підпорядкований об'єкт Purchases пов'язаний з одним головним об'єктом Customer
            .HasForeignKey(vocabulary => vocabulary.StudentId);
        }
    }
}
