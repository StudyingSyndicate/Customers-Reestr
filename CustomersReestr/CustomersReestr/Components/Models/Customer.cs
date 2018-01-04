using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomersReestr.Components.Models

    /*тут задается структура нашей таблицы или таблиц
     * можно прописать почти все, что создается в SQL*/

{
   public class Customers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //автогенерация ИД
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required] [MaxLength(10)]
        public string Sex { get; set; }

        [Required] [MaxLength(30)]
        public string Email { get; set; }

        [Required] [MaxLength(15)]
        public string Phone { get; set; }
       
        public DateTime? BirthDate { get; set; }
        
        public DateTime RegDate { get; set; }
    }
}

