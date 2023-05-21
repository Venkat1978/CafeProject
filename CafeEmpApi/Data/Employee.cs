using System.ComponentModel.DataAnnotations;

namespace CafeEmpApi.Data
{
    internal sealed class Employee
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Email_address { get; set; }

        [Required]
        public string? Phone_number { get; set; }

        [Required]
        public string? Gender { get; set; }
    }
}
