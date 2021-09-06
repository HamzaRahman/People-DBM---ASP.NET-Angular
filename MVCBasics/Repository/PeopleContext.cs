using Microsoft.EntityFrameworkCore;
using MVCBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Repository
{
    public class PeopleContext:DbContext
    {
        public PeopleContext():base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PeopleDB;Trusted_Connection=True;");
        }
        public DbSet<Person> People { get; set; }
    }
}
