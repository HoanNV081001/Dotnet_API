using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dotnet_API.Data
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public Guid Id {get; set;}
         [Required]
        [MaxLength(100)]
        public string NameProduct{get; set;}
        public string Descriptions{get; set;}
        [Range(0, double.MaxValue)]
        public double Price{get; set;}
        public byte Sale{get; set;}
        public int? IdCat{get; set;}
        [ForeignKey("IdCat")]
        public Category Category{get; set;}

    }
}