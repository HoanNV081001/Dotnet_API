
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Dotnet_API.Data
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int IdCat{get; set;}

        [Required]
        [MaxLength(50)]
        public string NameCat{get; set;}
        public virtual ICollection<Product> Products { get; set; }
    }
}