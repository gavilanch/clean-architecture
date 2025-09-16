using System.ComponentModel.DataAnnotations;

namespace CleanTeeth.API.DTOs.Patients
{
    public class CreatePatientDTO
    {
        [Required]
        [StringLength(250)]
        public required string Name { get; set; }
        [Required]
        [StringLength(254)]
        [EmailAddress]
        public required string Email { get; set; }
    }
}
