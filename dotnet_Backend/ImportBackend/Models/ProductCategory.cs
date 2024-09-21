using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ImportBackend.Models
{
    public class ProductCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; }
        [Required]
        [MaxLength(50)]
        public string Name { get;}
        [Required]
        public string Description { get;}
        public DateTime DateCreated { get; }
        public DateTime DateUpdated { get; }
        private ProductCategory() { }

        public ProductCategory(int id, string name, string description, DateTime dateCreated, DateTime dateUpdated)
        {
            Id = id;
            Name = name;
            Description = description;
            DateCreated = dateCreated;
            DateUpdated = dateUpdated;
        }

        public ICollection<Product> Products { get; private set; } = new List<Product>();
    }
}
