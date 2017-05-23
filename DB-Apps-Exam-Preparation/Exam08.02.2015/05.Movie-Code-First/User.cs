using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace _05.Movie_Code_First
{
   public class User
    {
       public User()
       {
           this.Movies = new HashSet<Movie>();
       }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Username { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public int? Age { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

       
    }
}
