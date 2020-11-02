using Microsoft.EntityFrameworkCore;
using System;

namespace Dal
{
    public class UserContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=True;Initial Catalog=Questionnair_form;Data Source=NARGES");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> users { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<Answer> answers { get; set; }

        public DbSet<Choice> choices { get; set; }


    }
}
