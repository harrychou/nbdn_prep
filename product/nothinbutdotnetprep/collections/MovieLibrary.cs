using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.extensions;

namespace nothinbutdotnetprep.collections
{
    public delegate bool MovieMatcher(Movie movie);

    public class MovieLibrary
    {
        readonly IList<Movie> movies;


        public MovieLibrary(IList<Movie> list_of_movies)
        {
            movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies.one_at_a_time();
        }

        public void add(Movie movie)
        {
            if (already_contains(movie)) return;

            movies.Add(movie);
        }

        bool already_contains(Movie movie)
        {
            return movies.Contains(movie);
        }


        public IEnumerable<Movie> sort_all_movies_by_title_ascending()
        {
            var orderedMovies = (List<Movie>) movies;
            orderedMovies.Sort(delegate(Movie leftSide, Movie rightSide)
            {
                return leftSide.title.CompareTo(rightSide.title);
            });

            return orderedMovies;
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            var orderedMovies = (List<Movie>) movies;
            //orderedMovies.Sort(delegate(Movie p1, Movie p2) { 
            //    int r = p1.Name.CompareTo(p2.Name); 
            //    if (r == 0) r = p1.Age.CompareTo(p2.Age); 
            //    if (r == 0) r = p1.Level.CompareTo(p2.Level); 
            //    return r; 
            //    }
            // );
            return orderedMovies;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            var orderedMovies = (List<Movie>) movies;
            orderedMovies.Sort(delegate(Movie leftSide, Movie rightSide)
            {
                return rightSide.date_published.CompareTo(leftSide.date_published);
            });

            return orderedMovies;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            var orderedMovies = (List<Movie>) movies;
            orderedMovies.Sort(delegate(Movie leftSide, Movie rightSide)
            {
                return leftSide.date_published.CompareTo(rightSide.date_published);
            });

            return orderedMovies;
        }
    }
}