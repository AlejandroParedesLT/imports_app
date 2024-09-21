using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ImportBackend.Models
{
    public class ImportOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; }
        [ForeignKey("User")]
        public int UserId { get; }
        [ForeignKey("UserId")]
        public User User { get; }
        [ForeignKey("Product")]
        public int ProductId { get; }
        [ForeignKey("ProductId")]
        public Product Product { get; }
        //[ForeignKey("Provider")]
        public int ProviderId { get; }
        //[ForeignKey("ProviderId")]
        //public Provider Provider { get; }
        public int Quantity { get; }
        public float Individualprice { get; }
        public string? Description { get; }
        public DateTime DateCreated { get; }
        public DateTime DateUpdated { get; }
        public byte[]? Image { get; }
        // Parameterless constructor required by EF
        private ImportOrder() { }
        public ImportOrder(int id, int userId,int productId,int providerId, int quantity, float individualprice, string? description, DateTime dateCreated, DateTime dateUpdated)
        {
            Id = id;
            UserId = userId;
            ProductId = productId;
            ProviderId = providerId;
            Quantity = quantity;
            Individualprice = individualprice;
            Description = description;
            DateCreated = dateCreated;
            DateUpdated = dateUpdated;
        }
    }
}
