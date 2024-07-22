using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Product
    {
        internal bool IsActive;

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }
        [Required]
        public int Qty { get; set; }


        [ForeignKey("Categories")]
        public int CategoryId {  get; set; }

        public virtual Category Categories { get; set; }


    }
}
