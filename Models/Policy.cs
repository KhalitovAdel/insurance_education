namespace insurance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Policy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public virtual ICollection<InsuranceCase> InsuranceCases { get; set; } = new List<InsuranceCase>();
    }
