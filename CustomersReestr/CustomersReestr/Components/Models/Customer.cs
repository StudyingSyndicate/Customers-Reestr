using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomersReestr.Components.Models
{
   public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        public string Sex { get; set; }

        [MaxLength(30)]
        public string Email { get; set; }

        [MaxLength(30)]
        public string Phone { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public DateTime RegDate { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; set; }


        public DateTime LastModified { get; set; }
        
        [NotMapped]
        public string FullName {
            get {
                return LastName + " " + Name + " " + MiddleName;
            }
        }

        [NotMapped]
        public int Age
        {
            get
            {
                DateTime today = DateTime.Now;
                int age = today.Year - BirthDate.Year;
                if (today < BirthDate.AddYears(age)) // когда текущая дата меньше даты дня рождения, нужно уменьшить получившийся возраст
                    age--;
                return age;
            }
        }

        [NotMapped]
        public DateTime NextBirthDate
        {
            get
            {
                DateTime nextBirthDate = BirthDate.AddYears(DateTime.Today.Year - BirthDate.Year);
                return nextBirthDate > DateTime.Today ? nextBirthDate : nextBirthDate.AddYears(1);
            }
        }
    }
}

