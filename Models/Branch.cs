namespace insurance.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class Branch
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }