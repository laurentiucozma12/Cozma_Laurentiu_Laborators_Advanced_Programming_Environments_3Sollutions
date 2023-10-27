﻿using System.ComponentModel.DataAnnotations;

namespace Cozma_Laurentiu_Lab2.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Publisher Name")]
        [StringLength(50)]
        public string PublisherName { get; set; }

        [StringLength(70)]
        public string Address { get; set; }
        public ICollection<PublishedBook>? PublishedBooks { get; set; }
    }
}
