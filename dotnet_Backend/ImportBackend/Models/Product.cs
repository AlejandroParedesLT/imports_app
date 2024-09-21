using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ImportBackend.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get;  }
        [Required]
        [MaxLength(50)]
        public string Name { get;  }
        public string? Description { get;  }
        public DateTime DateCreated { get;  }
        public DateTime DateUpdated { get; }
        [ForeignKey("ProductCategory")]
        public int ProductCategoryId { get; }
        [ForeignKey("ProductCategoryId")]
        public ProductCategory ProductCategory { get; }
        public byte[]? Image { get; }
        // Parameterless constructor required by EF
        private Product() { }
        public Product(int id, string name, string? description, DateTime dateCreated, DateTime dateUpdated, int productCategoryId, byte[] image)
        {
            Id = id;
            Name = name;
            Description = description;
            DateCreated = dateCreated;
            DateUpdated = dateUpdated;
            ProductCategoryId = productCategoryId;
            Image = image;
        }
    }
}
