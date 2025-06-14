namespace insurance.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class Payout
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int InsuranceCaseId { get; set; }
        public virtual InsuranceCase InsuranceCase { get; set; }
    }