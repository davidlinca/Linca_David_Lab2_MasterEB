using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Linca_David_Lab2_MasterEB.Models;

namespace Linca_David_Lab2_MasterEB.Data
{
    public class Linca_David_Lab2_MasterEBContext : DbContext
    {
        public Linca_David_Lab2_MasterEBContext (DbContextOptions<Linca_David_Lab2_MasterEBContext> options)
            : base(options)
        {
        }

        public DbSet<Linca_David_Lab2_MasterEB.Models.Book> Book { get; set; } = default!;
        public DbSet<Linca_David_Lab2_MasterEB.Models.Customer> Customer { get; set; } = default!;
        public DbSet<Linca_David_Lab2_MasterEB.Models.Genre> Genre { get; set; } = default!;

        public DbSet<Linca_David_Lab2_MasterEB.Models.Author> Author { get; set; } = default!;
        public DbSet<Linca_David_Lab2_MasterEB.Models.Order> Order { get; set; } = default!;
    }
}
