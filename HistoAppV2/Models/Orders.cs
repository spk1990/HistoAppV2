using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HistoAppV2.Models
{
    public class Orders
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Surname")]
        public string? Surname { get; set; }

        [Required]
        [DisplayName("Case")]
        public string? Case { get; set; }

        [DisplayName("Block")]
        public string? Block { get; set; }

        public int? TestId { get; set; }

        [DisplayName("Test")]
        public string? Test { get; set; }

        //public List<SelectListItem> TestList { get; set; }

        public int? LevelsId { get; set; }

        [DisplayName("Levels")]
        public string? Levels { get; set; }

        [Required]
        [DisplayName("Requested By")]
        public string? RequestedBy { get; set; }

        [Required]
        [DisplayName("Date Created")]
        public DateTime CreatedDate { get; set; }

        [MaxLength(1000)]
        public string? Notes { get; set; }
        
        [DisplayName("Email")]
        [EmailAddress]
        public string? Email { get; set; }

        //public string? UserName { get; set; }

    }
   
}
