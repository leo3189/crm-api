using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("customer")]
    public class Customer : IEntity
    {
        [Key]
        [Column("CustomerId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(60, ErrorMessage = "First Name can't be longer than 60 characters")]
        public string FirstName { get; set; }
        [StringLength(60, ErrorMessage = "Last Name can't be longer than 60 characters")]
        public string LastName { get; set; }
        [StringLength(100, ErrorMessage = "Address cannot be loner then 100 characters")]
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string WorkPhone { get; set; }
        [Required(ErrorMessage = "Main phone is required")]
        public string MainPhone { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime LastUpdated { get; set; }
        [Required(ErrorMessage = "Company name is required")]
        public string CompanyName { get; set; }
    }
}
