using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Linca_David_Lab2_MasterEB.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int? GenreID { get; set; }
        public Genre? Genre { get; set; }

        public int? AuthorID { get; set; } // Cheie străină
        public Author? Author { get; set; } // Navigation property
        public ICollection<Order>? Orders { get; set; }
    }
}
