using System.ComponentModel.DataAnnotations;

namespace CafeEmpApi.Data
{
    internal sealed class Cafe
    {
        [Key]
        public int CafeId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        [StringLength(100)]
        public string? Location { get; set; }

        public Guid Id { get; set; }
    }
}
