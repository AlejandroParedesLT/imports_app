using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ImportBackend.Models
{
    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; }
        [ForeignKey("User")]
        public int UserId { get; }
        [ForeignKey("UserId")]
        public User User { get; }
        [ForeignKey("Client")]
        public int ClientId { get; }
        [ForeignKey("ClientId")]
        public Cliente Cliente { get; }
        [ForeignKey("Product")]
        public int ProductId { get; }
        [ForeignKey("ProductId")]
        public Product Product { get; }
        public int Quantity { get; }
        public float Individualprice { get; }
        public string? Description { get; }
        public DateTime DateCreated { get; }
        public DateTime DateUpdated { get; }
        public byte[]? Image { get; }
        // Parameterless constructor required by EF
        private Sale() { }
        public Sale(int id, int userId, int productId, int clientId, int quantity, float individualprice, string? description, DateTime dateCreated, DateTime dateUpdated)
        {
            Id = id;
            UserId = userId;
            ClientId = clientId;
            ProductId = productId;
            Quantity = quantity;
            Individualprice = individualprice;
            Description = description;
            DateCreated = dateCreated;
            DateUpdated = dateUpdated;
        }
    }
}
