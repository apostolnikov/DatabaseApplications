namespace _05.Movie_Code_First
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MovieContext : DbContext
    {
        public MovieContext()
            : base("name=MovieContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Movie> Movies { get; set; }

        public virtual DbSet<Rating> Ratings { get; set; }
    }


}