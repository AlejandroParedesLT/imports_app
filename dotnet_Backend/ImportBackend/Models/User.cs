using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ImportBackend.Models
{
    public class User
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
        public string Email { get; }
        [Required]
        public string Password { get; }
        public DateTime DateCreated { get; }
        public DateTime DateUpdated { get; }

        // Parameterless constructor required by EF
        private User() { }

        public User(int id, string givenName, string lastName, string userName, string email, string password, DateTime dateCreated, DateTime dateUpdated)
        {
            Id = id;
            GivenName = givenName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            Password = password;
            DateCreated = dateCreated;
            DateUpdated = dateUpdated;
        }
    }
}


/*
 int Id,
        string GivenName,
        string LastName,
        string UserName,
        string Email,
        string Password,
        DateTime DateCreated,
        DateTime DateUpdated
 
 */