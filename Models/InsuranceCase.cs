namespace insurance.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class InsuranceCase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public int PolicyId { get; set; }
        public virtual Policy Policy { get; set; }

        public virtual Payout Payout { get; set; }
    }
