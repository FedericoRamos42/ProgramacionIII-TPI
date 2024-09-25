using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber {  get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public Adress? Adress { get; set; }
        public int AdressId { get; set; }
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }= string.Empty;
        [Required]
        [MaxLength(20)]
        public string Password { get; set; } = string.Empty;
        [Required]
        public UserRole UserRole { get; set; }
        
    }
}
