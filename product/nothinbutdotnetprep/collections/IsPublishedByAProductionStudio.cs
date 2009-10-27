namespace nothinbutdotnetprep.collections
{
    public class IsPublishedByAProductionStudioAProductionStudio : MovieCriteria
    {
        ProductionStudio studio;

        public IsPublishedByAProductionStudioAProductionStudio(ProductionStudio studio)
        {
            this.studio = studio;
        }

        public bool is_satisfied_by(Movie movie)
        {
            return movie.production_studio == studio;
        }
    }
}