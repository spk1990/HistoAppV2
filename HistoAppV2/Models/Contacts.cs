using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HistoAppV2.Models
{
    public class Contacts
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string? ContactName { get; set; }

        [Required]
        [DisplayName("Email")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DisplayName("Phone number")]
        public string? PhoneNumber { get; set; }
    }
}
