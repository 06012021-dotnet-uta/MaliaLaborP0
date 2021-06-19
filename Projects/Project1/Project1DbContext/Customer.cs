using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Project1DbContext
{
    public partial class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
            PreferredStores = new HashSet<PreferredStore>();
        }

        public int Id { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(20)]
        [MinLength(1)]
        public string FirstName { get; set; }
        
        [Display(Name ="Last Name")]
        [MaxLength(20)]
        [MinLength(1)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "A username is required.")] //make changes to db for UNIQUE username
        [MaxLength(20)]
        public string Username { get; set; }

        [Required(ErrorMessage ="A password is required.")]
        [DataType(DataType.Password)]
        [MaxLength(20)]
        public string Password { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<PreferredStore> PreferredStores { get; set; }
    }
}
