namespace _06._2.Rated_Movies_By_User
{
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using _05.Movie_Code_First;

    class RatedMoviesByUser
    {
        static void Main(string[] args)
        {
            var context = new MovieContext();

            var ratedMovies = context.Users
                .Select(u => new
                {
                    username = u.Username,
                    ratedMovies = u.Movies.Select(m => new
                    {
                        title = m.Title,
                        userRating = m.Ratings.Select(r => r.Stars),
                        averageRating = m.Ratings.Select(r => r.Stars + r.Stars / m.Ratings.Count)
                    }),
                });

            var json = new JavaScriptSerializer().Serialize(ratedMovies);



            File.WriteAllText("../../rated-movies-by-jmeyery.json", json);
        }
    }
}
