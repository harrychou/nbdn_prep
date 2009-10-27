using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.collections
{
    public interface MovieCriteria : Criteria<Movie>
    {
    }

    public class IsPublishedAfterACertainYear : Criteria<Movie>
    {
        int year;

        public IsPublishedAfterACertainYear(int year)
        {
            this.year = year;
        }

        public bool is_satisfied_by(Movie movie)
        {
            return movie.date_published.Year > year;
        }
    }
}