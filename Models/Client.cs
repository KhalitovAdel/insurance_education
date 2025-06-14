namespace insurance.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string Passport { get; set; }

        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        public virtual ICollection<Policy> Policies { get; set; } = new List<Policy>();
    }