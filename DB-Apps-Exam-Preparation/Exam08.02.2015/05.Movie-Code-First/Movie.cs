using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace _05.Movie_Code_First
{
   public class Movie
    {
       public Movie()
       {
           this.Users = new HashSet<User>();
       }

       [Key]
       public int Id { get; set; }

       [Required]
       public string Isbn { get; set; }

       [Required]
       [MinLength(2)]
       [MaxLength(100)]
       public string Title { get; set; }

       public AgeGroup AgeRestriction { get; set; }

       public virtual ICollection<Rating> Ratings { get; set; }

       public virtual ICollection<User> Users  { get; set; }


    }
}
