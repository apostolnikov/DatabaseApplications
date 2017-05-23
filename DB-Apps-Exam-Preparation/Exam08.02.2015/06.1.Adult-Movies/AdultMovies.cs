namespace _06._1.Adult_Movies
{
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using _05.Movie_Code_First;

    class AdultMovies
    {
        static void Main(string[] args)
        {
            var context = new MovieContext();

            var adultMovies = context.Movies
                .OrderBy(m => m.Title)
                .ThenBy(m => m.Ratings.Select(r => r.Stars))
                .Select(m => new
                {
                    title = m.Title,
                    ratingsGiven = m.Ratings.Select(r => r.Stars)
                });

            var json = new JavaScriptSerializer().Serialize(adultMovies);



            File.WriteAllText("../../adult-movies.json", json);
        }
    }
}
