﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryModel.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int? AuthorId { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public Author? Author { get; set; } 
        public decimal Price { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<PublishedBook>? PublishedBooks { get; set; }

    }
}
