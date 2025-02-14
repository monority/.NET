
using Exercice06.Models;

namespace Exercice06.Services;

public interface IMovieService
{
    public IEnumerable<MovieViewModel> GetAll();
    public MovieViewModel? GetById(long id);
    public MovieViewModel? Create(MovieCreateViewModel vm);
    public MovieViewModel? Delete(MovieViewModel vm);
    public MovieViewModel? Update(MovieViewModel vm);
}
