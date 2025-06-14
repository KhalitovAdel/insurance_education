namespace insurance.Models;

using System.ComponentModel.DataAnnotations;

public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [StringLength(50)]
        public string Position { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
    }