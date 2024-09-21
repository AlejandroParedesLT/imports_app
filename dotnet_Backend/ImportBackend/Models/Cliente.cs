using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ImportBackend.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; }
        [Required]
        public string GivenName { get; }
        [Required]
        public string LastName { get; }
        [Required]
        public string UserName { get; }
        [Required]
        public string Password { get; }
        public DateTime DateCreated { get; }
        public DateTime DateUpdated { get; }

        // Parameterless constructor required by EF
        private Cliente() { }

        public Cliente(int id, string givenName, string lastName, string userName, string password, DateTime dateCreated, DateTime dateUpdated)
        {
            Id = id;
            GivenName = givenName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            DateCreated = dateCreated;
            DateUpdated = dateUpdated;
        }
    }
}
