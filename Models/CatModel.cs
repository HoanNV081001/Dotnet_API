using System.ComponentModel.DataAnnotations;

namespace Dotnet_API.Models
{
    public class CatModel
    {
        [Required]
        [MaxLength(50)]
        public string NameCat{get; set;}
    }
}