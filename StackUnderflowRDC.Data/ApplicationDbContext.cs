﻿using Microsoft.EntityFrameworkCore;
using StackUnderflowRDC.Entities;
using System;

namespace StackUnderflowRDC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Question> Questions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
                Data Source=(localdb)\mssqllocaldb; 
                Initial Catalog=StackUnderflowRDC;
                Integrated Security=True");
        }
    }
}
