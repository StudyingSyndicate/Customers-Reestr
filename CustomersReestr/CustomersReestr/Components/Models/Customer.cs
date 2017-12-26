using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomersReestr.Components.Models
{
   public class Customers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required] [MaxLength(4)]
        public string sex { get; set; }
        [Required] [MaxLength(30)]
        public string email { get; set; }
        [Required] [MaxLength(15)]
        public string phone { get; set; }
       
        public DateTime? birthDate { get; set; }
        

        public DateTime regDate { get; set; }
    }
}

