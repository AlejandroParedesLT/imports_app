using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace ImportBackend.Models
{
    public class Provider
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; }
        [Required]
        public string Name { get; }
        [Required]
        public string Email { get; }
        [Required]
        public int PhoneNumber { get; }
        [Required]
        public string Country { get; }
        
        public DateTime DateCreated { get; }
        public DateTime DateUpdated { get; }

        // Parameterless constructor required by EF
        private Provider() { }
        
        public Provider(int id, string name, string email, int phoneNumber, string country, DateTime dateCreated, DateTime dateUpdated)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Country = country;
            DateCreated = dateCreated;
            DateUpdated = dateUpdated;
        }
    }
}
